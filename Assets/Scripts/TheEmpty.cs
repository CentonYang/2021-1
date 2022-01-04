using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TheEmpty : MonoBehaviour
{
    void Start()
    {
        GameManager.Score = 0;
    }

    void Update()
    {
        float Rtt = 45 * Time.deltaTime;
        transform.Rotate(Rtt, Rtt, Rtt);
        Vector3 Mp = Input.mousePosition;
        Mp.z = 10;
        transform.position = Camera.main.ScreenToWorldPoint(Mp);
    }
}
