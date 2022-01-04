using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMe : MonoBehaviour
{
    public float speed = 1.0f;
    public Transform target;
    public GameObject Player;

    void Awake()
    {
        // Position the cube at the origin.
        //transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        target = GameObject.Find("Player").transform;
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    private void OnCollisionEnter(Collision Other)
    {
        if (Other.gameObject.tag == "Bullet")
        {
            GameManager.Score++;
            Destroy(Other.gameObject);
        }
        Destroy(gameObject);
    }
}
