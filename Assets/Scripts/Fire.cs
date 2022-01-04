using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public GameObject Bullet;
    public ParticleSystem Particle;
    public Transform FirePoint;
    public float CD = 0.5f;
    public float BCCD = 4;
    public Image BCCDimg;
    bool BCCDm = false;
    public float BC = 5;
    public float MaxBC = 5;
    public Text BCtxt;
    public AudioClip Gunshot;
    public AudioClip GunReload;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CD = CD < 0.5f ? CD + Time.deltaTime : 0.5f;
        BCCD = BCCD < 2 ? BCCD + Time.deltaTime : 2;
        BCCDimg.fillAmount = BCCD / 2;
        BCtxt.text = string.Format("子彈：{0}/{1}", (int)BC, MaxBC.ToString());
        if (Input.GetMouseButtonDown(0) && CD >= 0.5f && BC >= 1 && BCCD >= 2)
        {
            CD -= 0.5f;
            BC--;
            Instantiate(Particle, FirePoint.position, FirePoint.rotation);
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            GetComponentInChildren<Animator>().Play("Fire");
            GetComponent<AudioSource>().PlayOneShot(Gunshot);            
        }
        if (Input.GetMouseButtonDown(1) && BCCD >= 2 && BC < MaxBC)
        {
            BCCD -= 2;
            GetComponent<AudioSource>().PlayOneShot(GunReload);
            BCCDm = true;
        }
        if (BCCDm && BCCD >= 2)
        {
            BCCDm = false;
            BC = MaxBC;
        }
    }
}
