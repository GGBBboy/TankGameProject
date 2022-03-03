using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10;
    public bool isPlayer;
    public AudioClip hitAudio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Tank":
                if (!isPlayer)  
                {
                    collision.SendMessage("die");
                    Destroy(gameObject);
                }
                
                break;
            case "Home":
                collision.SendMessage("destory");
                Destroy(gameObject);
                break;
            case "Enemy":
                if (isPlayer)
                {
                    collision.SendMessage("die");
                    Destroy(gameObject);
                }
                break;                
            case "Wall":
                if(isPlayer)
                    AudioSource.PlayClipAtPoint(hitAudio, gameObject.transform.position);
                Destroy(collision.gameObject);
                Destroy(gameObject);
               break;
            case "Barrier":
                if (isPlayer)
                    AudioSource.PlayClipAtPoint(hitAudio, gameObject.transform.position);
                Destroy(gameObject);
                break;
            default:
               break;
        }
    }
}
