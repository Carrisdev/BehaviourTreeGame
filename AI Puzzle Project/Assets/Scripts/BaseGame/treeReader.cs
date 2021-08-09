using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeReader : MonoBehaviour
{
    GameObject parentGrid;
    private void Start()
    {
        parentGrid = GameObject.Find("Grid");
    }
    List<int> readTree(Transform currentObject, List<int> treeInstructions)
    {
        Transform nextStep = transform.Find("nextStep");
        List<Transform> objects = new List<Transform>();
        List<Transform> possibleStep = new List<Transform>();
        parentGrid.GetComponentsInChildren(objects);
        for(int i = 0; i < objects.Count; i++)
        {
            if(objects[i].name != "arrow" && objects[i].name != "nextStep" && objects[i].name != "Grid")
            {
                possibleStep.Add(objects[i]);
            }
        }
        GameObject nextPiece = null;
        Transform nextStepCheck = currentObject.Find("nextStep").transform;
        for(int i = 0; i < possibleStep.Count; i++)
        {
            if (Mathf.Abs(nextStepCheck.position.x - possibleStep[i].position.x) < 0.225 && 
            Mathf.Abs(nextStepCheck.position.y - possibleStep[i].position.y) < 0.225)
            {
                nextPiece = possibleStep[i].gameObject;
            }
        }
        if(nextPiece == null)
        {
            return treeInstructions;
        }
        treeInstructions.Add(nextPiece.GetComponent<treeCommand>().treeCommandNumber);
        treeInstructions = readTree(nextPiece.transform, treeInstructions);
        return treeInstructions;
    }
    public void startRead()
    {
        List<int> finalInstructions = readTree(parentGrid.transform.Find("Start"), new List<int>());
        for(int i = 0; i < finalInstructions.Count; i++)
        {
            Debug.Log(finalInstructions[i]);
        }
        StartCoroutine(gameObject.GetComponent<treeTranslation>().runThroughTree(finalInstructions));
    }
    public void stopRead()
    {
        StopAllCoroutines();
        gameObject.GetComponent<treeTranslation>().turtle.returnToStart();
        gameObject.GetComponent<treeTranslation>().iteration = 0;
    }
}
