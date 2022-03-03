using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 3;

    public Vector3 angle;
    public float timeVal=2;
    public float timeVal1;
    public float v=-1;
    public float h;


    //引用
    private SpriteRenderer sr;
    public Sprite[] tanksprites;
    public GameObject bullet;
    public GameObject explosion;





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
        //攻击时间间隔
        if (timeVal >= 3.0f)
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

            Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles + angle));
            timeVal = 0;
    }
    //坦克移动方法
    private void move()
    {
        if (timeVal1 >= 4)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = 1;
                h = 0;
            }
            else if (num>0&&num<=2)
            {
                v = 0;
                h = -1;
            }
            else if (num >0&&num<=4)
            {
                v = 0;
                h = 1;
            }
            timeVal1 = 0;
        }
        else
        {
            timeVal1 += Time.fixedDeltaTime;
        }

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
        PlayerManager.Instanse.playerScore++;
        Instantiate(explosion, transform.position, transform.rotation);
        
        Destroy(gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            timeVal1 = 4;
        }
    }
}
