using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallAudioHandler : MonoBehaviour
{
    Draggable draggable;

    AudioSource audioSource;
    [SerializeField] AudioClip[] tennisAudioClips;
    [SerializeField] GameObject objectToPop;

    bool tennisIsPlayed = false;
    bool forThis = false;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        draggable = GetComponent<Draggable>();
    }

    void Update()
    {
        PlayAudio();

    }

    // To Play the Audios
    void PlayAudio()

    //Condition to play the first voice Over
    {
        if (draggable._isBeingDragged == true && !tennisIsPlayed)
        {

            Debug.Log("function called");
            audioSource.PlayOneShot(tennisAudioClips[0]);
            tennisIsPlayed = true;
        }

        // Condition to play the second voice over

        if (draggable.numberOfDrags == 4 && !forThis)
        {

            Debug.Log("Second audio is on");
            audioSource.PlayOneShot(tennisAudioClips[1]);
            forThis = true;
        }
        //For the Video to pop , Invoking for 10 seconds for the player to think for 10 seconds
        if (forThis == true)
        {
            Invoke("PopVideo", 10f);
        }
    }


    void PopVideo()
    {
        objectToPop.SetActive(true);
    }
}
        
    








     
    

















