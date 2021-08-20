using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class treeReader : MonoBehaviour
{
    GameObject parentGrid;
    [SerializeField]
    snakeScore scoreText;
    Scene scene;
    private void Start()
    {
        parentGrid = GameObject.Find("Grid");
        scene = SceneManager.GetActiveScene();
    }
    List<int> readTree(Transform currentObject, List<int> treeInstructions)
    {
        List<Transform> objects = new List<Transform>();
        List<Transform> possibleStep = new List<Transform>();
        //grab all the pieces that have been placed by the player
        parentGrid.GetComponentsInChildren(objects);
        //remove anything that's not the base node, including arrows, next step markers, or the parent grid
        for(int i = 0; i < objects.Count; i++)
        {
            if(objects[i].name != "arrow" && !objects[i].name.Contains("nextStep") && !objects[i].name.Contains("Canvas") && objects[i].name != "Grid" &&
            !objects[i].name.Contains("InputField") && objects[i].name != "Placeholder" && objects[i].name != "Text")
            {
                possibleStep.Add(objects[i]);
            }
        }
        //if the node is a simple instruction, just move forward along the tree
        if (!currentObject.name.Contains("Check") && !currentObject.name.Contains("Compare"))
        {
            GameObject nextPiece = null;
            Transform nextStepCheck = currentObject.Find("nextStep").transform;
            for (int i = 0; i < possibleStep.Count; i++)
            {
                if (Mathf.Abs(nextStepCheck.position.x - possibleStep[i].position.x) < 0.225 &&
                    //subtracting an extra 0.25 here due to a problem with how large i made the nodes
                    //rather than moving every nextStep, i'm just pushing them all down in the code itself
                Mathf.Abs(nextStepCheck.position.y - possibleStep[i].position.y - 0.25f) < 0.225)
                {
                    nextPiece = possibleStep[i].gameObject;
                }
            }
            //if there's an input field, we need to add that to the value first, before adding the addresses for the next steps
            if (currentObject.name.Contains("Input"))
            {
                treeInstructions[treeInstructions.Count - 1] *= 100;
                treeInstructions[treeInstructions.Count - 1] += int.Parse(currentObject.gameObject.GetComponentInChildren<InputField>().text);
            }
            if (nextPiece == null)
            {
                //when we reach the end, put in the kill number so the translater knows where to stop reading from
                treeInstructions.Add(-1);
                return treeInstructions;
            }
            treeInstructions.Add(nextPiece.GetComponent<treeCommand>().treeCommandNumber);
            treeInstructions = readTree(nextPiece.transform, treeInstructions);
            return treeInstructions;
        }
        //if the node would return a boolean value, include it in the tree, while marking where the tree should branch to
        if (currentObject.name.Contains("Check"))
        {
            GameObject nextPiece1 = null;
            GameObject nextPiece2 = null;
            //the next step if the value returns true
            Transform nextStepCheck1 = currentObject.Find("nextStep1").transform;
            //the nextstepif the value returns false
            Transform nextStepCheck2 = currentObject.Find("nextStep2").transform;
            //find the next nodes for all paths
            for (int i = 0; i < possibleStep.Count; i++)
            {
                if (Mathf.Abs(nextStepCheck1.position.x - possibleStep[i].position.x) < 0.225 &&
                Mathf.Abs(nextStepCheck1.position.y - possibleStep[i].position.y) < 0.225)
                {
                    nextPiece1 = possibleStep[i].gameObject;
                }
                if (Mathf.Abs(nextStepCheck2.position.x - possibleStep[i].position.x) < 0.225 &&
                Mathf.Abs(nextStepCheck2.position.y - possibleStep[i].position.y) < 0.225)
                {
                    nextPiece2 = possibleStep[i].gameObject;
                }
            }
            int currentAddress = treeInstructions.Count-1;
            //if there's an input field, we need to add that to the value first, before adding the addresses for the next steps
            if(currentObject.name.Contains("Input"))
            {
                treeInstructions[currentAddress] *= 100;
                treeInstructions[currentAddress] += int.Parse(currentObject.gameObject.GetComponentInChildren<InputField>().text);
            }
            //create 4 0s that you can use to store the two indexes of the yes/no tree path
            treeInstructions[currentAddress] *= 10000;
            //if the tree is continued along the yes path
            if (nextPiece1 != null)
            {
                //add the next step along the tree
                treeInstructions.Add(nextPiece1.GetComponent<treeCommand>().treeCommandNumber);
                //mark the next step's index in this step's value
                //so it would be (instruction #)(index of next step in yes tree)(index of next step in no tree)
                //for example, 40305
                treeInstructions[currentAddress] += ((treeInstructions.Count-1) * 100);
                treeInstructions = readTree(nextPiece1.transform, treeInstructions);
                //don't wanna return just yet. need to read the other tree path first
            }
            if(nextPiece2 != null)
            {
                //add the next step along the tree
                treeInstructions.Add(nextPiece2.GetComponent<treeCommand>().treeCommandNumber);
                //mark the next step's index in this step's value
                treeInstructions[currentAddress] += treeInstructions.Count-1;
                treeInstructions = readTree(nextPiece2.transform, treeInstructions);
                //we can return now since there's no other steps past this
                return treeInstructions;
            }
        }
        if(currentObject.name.Contains("Compare"))
        {
            GameObject nextPiece1 = null;
            GameObject nextPiece2 = null;
            GameObject nextPiece3 = null;
            //the next step if the value returns 0
            Transform nextStepCheck1 = currentObject.Find("nextStep1").transform;
            //the next step if the value returns 1
            Transform nextStepCheck2 = currentObject.Find("nextStep2").transform;
            //the next step if the value returns 2
            Transform nextStepCheck3 = currentObject.Find("nextStep3").transform;
            //find the next nodes for all paths
            for(int i = 0; i < possibleStep.Count; i++)
            {
                if (Mathf.Abs(nextStepCheck1.position.x - possibleStep[i].position.x) < 0.225 &&
                Mathf.Abs(nextStepCheck1.position.y - possibleStep[i].position.y) < 0.225)
                {
                    nextPiece1 = possibleStep[i].gameObject;
                }
                if (Mathf.Abs(nextStepCheck2.position.x - possibleStep[i].position.x) < 0.225 &&
                Mathf.Abs(nextStepCheck2.position.y - possibleStep[i].position.y) < 0.225)
                {
                    nextPiece2 = possibleStep[i].gameObject;
                }
                if (Mathf.Abs(nextStepCheck3.position.x - possibleStep[i].position.x) < 0.225 &&
                Mathf.Abs(nextStepCheck3.position.y - possibleStep[i].position.y) < 0.225)
                {
                    nextPiece3 = possibleStep[i].gameObject;
                }
            }
            int currentAddress = treeInstructions.Count - 1;
            //create 6 spaces to store the indexes of the paths
            treeInstructions[currentAddress] *= 1000000;
            //if the tree carries along the 0 path
            if (nextPiece1 != null)
            {
                //add the next step along the tree
                treeInstructions.Add(nextPiece1.GetComponent<treeCommand>().treeCommandNumber);
                //mark the next step's index in this step's value
                treeInstructions[currentAddress] += (treeInstructions.Count-1) * 10000;
                treeInstructions = readTree(nextPiece1.transform, treeInstructions);
                //don't wanna return just yet. need to read the other tree path first
            }
            //if the tree carries along the 1 path
            if (nextPiece2 != null)
            {
                //add the next step along the tree
                treeInstructions.Add(nextPiece2.GetComponent<treeCommand>().treeCommandNumber);
                //mark the next step's index in this step's value
                treeInstructions[currentAddress] += (treeInstructions.Count-1) * 100;
                treeInstructions = readTree(nextPiece2.transform, treeInstructions);
            }
            //if the tree carries along the 2 path
            if (nextPiece3 != null)
            {
                //add the next step along the tree
                treeInstructions.Add(nextPiece3.GetComponent<treeCommand>().treeCommandNumber);
                //mark the next step's index in this step's value
                treeInstructions[currentAddress] += treeInstructions.Count-1;
                treeInstructions = readTree(nextPiece3.transform, treeInstructions);
                //we can return now since there's no other steps past this
                return treeInstructions;
            }
        }
        //if something goes wrong, this will make sure something is returned and will just stop reading the tree
        return treeInstructions;

    }
    public void startRead()
    {
        List<int> finalInstructions = readTree(parentGrid.transform.Find("Start"), new List<int>());
        int instructionLengthScore = 0;
        string output = "";
        for(int i = 0; i < finalInstructions.Count; i++)
        {
            output += finalInstructions[i];
            //exclude all the blank nodes used for structuring and end of branch markers
            if(finalInstructions[i] >= 0)
            {
                instructionLengthScore++;
            }
            output += ", ";
        }
        //update the score if the score needs it
        if(scoreText != null)
        {
            scoreText.updateScore1(instructionLengthScore);
        }
        StartCoroutine(gameObject.GetComponent<treeTranslation>().runThroughTree(finalInstructions));
    }
    public void stopRead()
    {
        //stop the tree from reading
        StopAllCoroutines();
        if(scene.name == "Level 1" || scene.name == "Level 2" || scene.name == "Level 3")
        {
            gameObject.GetComponent<treeTranslation>().turtle.returnToStart();
        }
        gameObject.GetComponent<treeTranslation>().iteration = 0;
    }
}
