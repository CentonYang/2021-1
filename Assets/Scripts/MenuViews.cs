using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuViews : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3(250, 200, 250));
        transform.RotateAround(new Vector3(250, 200, 250), transform.up, Time.deltaTime * ((Screen.width / 2) - Input.mousePosition.x) / 40);
    }
}
