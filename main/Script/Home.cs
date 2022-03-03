using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{

    private SpriteRenderer rs;

    public Sprite sprite;
    public GameObject explosion;
    public AudioClip dieAudio;

    // Start is called before the first frame update
    void Start()
    {
        rs = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void destory()
    {
        Instantiate(explosion, transform.position, transform.rotation);

        rs.sprite = sprite;
        PlayerManager.Instanse.lifeValue = 0;
        PlayerManager.Instanse.Recover();
        AudioSource.PlayClipAtPoint(dieAudio, transform.position);
    }
}
