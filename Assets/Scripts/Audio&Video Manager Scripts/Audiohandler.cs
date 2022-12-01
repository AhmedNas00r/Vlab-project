using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiohandler : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    AudioSource audioSource;
    private bool hasPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tennis")
        {
            if (!hasPlayed)
            {
                audioSource.PlayOneShot(audioClips[0]);
                hasPlayed = true;
            }
        }
    }
}
