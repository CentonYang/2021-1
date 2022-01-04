using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEffect : MonoBehaviour
{
    public float Dtime = 0.5f;
    void Start()
    {
        Destroy(gameObject, Dtime);
    }
}
