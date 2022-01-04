using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 1000;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision Other)
    {
        if (Other.transform.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
