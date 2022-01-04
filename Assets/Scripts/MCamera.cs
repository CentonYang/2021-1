using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCamera : MonoBehaviour
{
    public float verticalSpeed = 1.0F;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x + Input.GetAxis("Mouse Y") * -verticalSpeed, transform.eulerAngles.y, 0);
    }
}
