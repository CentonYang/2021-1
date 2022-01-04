using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Player;
    public float Speed = 2;
    public ParticleSystem Particle;
    public Transform Spawn;
    bool Bs = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player.transform);
        transform.Translate(0, GetComponent<Rigidbody>().velocity.z < 0.1f ? Time.deltaTime : 0, Speed * Time.deltaTime);
        if (GameManager.Score >= GameManager.MaxScore)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision Other)
    {
        if (Other.transform.tag == "Bullet" && !Bs)
        {
            Bs = true;
            Instantiate(transform, Spawn.position, Spawn.rotation);
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(Particle, transform.position, transform.rotation);
    }
}
