using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulEffect : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position, 20 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Score += GameManager.Score < 10 ? 1 : 0;
            Destroy(gameObject, 1);
        }
    }
}
