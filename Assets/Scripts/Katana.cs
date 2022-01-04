using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    public float CD = 1f;
    public AudioClip KatanaWave;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CD = CD < 1f ? CD + Time.deltaTime : 1f;
        if (Input.GetMouseButtonDown(0) && CD >= 1f)
        {
            CD = 0;
            GetComponent<Animator>().Play("KatanaWave");
            GetComponent<AudioSource>().PlayOneShot(KatanaWave);
        }
    }
}
