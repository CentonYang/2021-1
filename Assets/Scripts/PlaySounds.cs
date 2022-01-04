using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSounds : MonoBehaviour
{
    public AudioClip AC;
    public void Play()
    {
        GetComponent<AudioSource>().PlayOneShot(AC);
    }
}
