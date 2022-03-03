using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Born : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemy;

    public bool isplay;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("bornTank", 1.5f);
        Destroy(gameObject, 1.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void bornTank()
    {
        if (isplay)
        {
            Instantiate(player, transform.position, Quaternion.identity);
        }
        else
        {
            int num = Random.Range(0, 2);
            Instantiate(enemy[num], transform.position, Quaternion.identity);
        }

    }
}
