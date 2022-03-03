using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 3;
   
    public Vector3 angle;
    public float timeVal;
    public float defendTimeVal=3;
    public bool isdefend = true;


    //引用
    private SpriteRenderer sr;
    public Sprite[] tanksprites; 
    public GameObject bullet;
    public GameObject explosion;
    public GameObject shield;


 

    
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isdefend)
        {
            shield.SetActive(true);
            defendTimeVal -= Time.deltaTime;
            if (defendTimeVal <=0)
            {
                isdefend = false;
                shield.SetActive(false);
            }
            
        }
            

        //攻击时间间隔
        if (timeVal >= 0.4f)
        {
            attack();
            
        }
        else timeVal += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        move();
        
    }
    
    //坦克的攻击方法
    private void attack()
    {
;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position,Quaternion.Euler(transform.eulerAngles+angle));
            timeVal = 0;
        }
    }
    //坦克移动方法
    private void move()
    {
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * Speed * Time.fixedDeltaTime, Space.World);
        if (v < 0)
        {
            sr.sprite = tanksprites[2];
            angle = new Vector3(0, 0, 180);
        }
        else if (v > 0)
        {
            sr.sprite = tanksprites[0];
            angle = new Vector3(0, 0, 0);
        };
        if (v != 0)
        {
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * Speed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tanksprites[3];
            angle = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tanksprites[1];
            angle = new Vector3(0, 0, -90);
        }
    }

    //坦克死亡方法
    private void die()
    {
        if(isdefend)
            return;


        Instantiate(explosion, transform.position, transform.rotation);

        Destroy(gameObject);

        PlayerManager.Instanse.Recover();
    }
}
