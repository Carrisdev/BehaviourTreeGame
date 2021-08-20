using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioFiles;
    // Start is called before the first frame update
    void Start()
    {
        //we want the sound to be managed in between scenes
        //we also want to make sure only one of these are created
        DontDestroyOnLoad(gameObject);
        //if we already have a soundManager script around, like if the player loads back into the main menu, destroy the extra object
        if(FindObjectsOfType<soundManager>().Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void playClip(string clipName)
    {
        for(int i = 0; i < audioFiles.Length; i++)
        {
            if(audioFiles[i].name == clipName)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(audioFiles[i]);
            }
        }
    }
}
