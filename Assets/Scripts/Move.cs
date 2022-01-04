using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float movSpeed = 2f;
    public float JumpHeight = 2000f;
    public float horizontalSpeed = 2.0F;
    public GameObject Terrain;
    public GameObject Panel;
    public Text Results;
    public Text UseTime;
    public float HP = 100;
    public float MaxHP = 100;
    public Image HPimg;
    public Text HPtxt;
    public GameObject Gun;
    public GameObject GunIcon;
    public GameObject Katana;
    public GameObject KatanaIcon;
    public float[] SkillVal;
    public Image Skillimg;
    public Text Skilltxt;
    public float[] Acce;
    public Image Acceimg;
    public Text Accetxt;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (Results.text != "失敗了！")
        {
            GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal") * movSpeed, GetComponent<Rigidbody>().velocity.y, Input.GetAxis("Vertical") * movSpeed));
            SkillVal[0] = SkillVal[0] > 0 ? SkillVal[0] - Time.deltaTime : 0;
            Skillimg.fillAmount = SkillVal[0] / SkillVal[1];
            Acce[0] = Acce[0] < 5 ? Acce[0] + 0.4f * Time.deltaTime : 5;
            Acceimg.fillAmount = Acce[0] / Acce[1];
            Accetxt.text = (int)(Acce[0] * 100) + "／" + (int)(Acce[1] * 100) + "\n（LShift衝刺）";
            if (SkillVal[0] <= 0)
            {
                Skilltxt.text = "補血(E)";
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SkillVal[0] = SkillVal[1];
                    HP = MaxHP;
                }
            }
            else
                Skilltxt.text = "冷卻：" + SkillVal[0].ToString("0.0");
            if (Acce[0] >= 0 && Input.GetKey(KeyCode.LeftShift))
            {
                movSpeed = 12;
                Acce[0] -= Time.deltaTime;
            }
            else
                movSpeed = 6;
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Gun.SetActive(true); Katana.SetActive(false);
                GunIcon.transform.localScale=new Vector3(1, 1, 1);                
                KatanaIcon.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Katana.SetActive(true); Gun.SetActive(false);
                KatanaIcon.transform.localScale = new Vector3(1, 1, 1);
                GunIcon.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + Input.GetAxis("Mouse X") * horizontalSpeed, 0);
        HPimg.fillAmount = HP / MaxHP;
        HPtxt.text = string.Format("{0}／{1}", HP.ToString("0"), MaxHP.ToString());
    }

    void OnCollisionStay(Collision Other)
    {
        if (Other.gameObject == Terrain && Results.text != "失敗了！")
            GetComponent<Rigidbody>().AddForce(Input.GetKey(KeyCode.Space) ? Vector3.up * JumpHeight : default);
        if (Other.gameObject.tag == "Enemy")
        {
            HP = HP > 0 ? HP - 1 : 0;
            if (HP <= 0)
            {
                Results.text = "失敗了！";
                Camera.main.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
