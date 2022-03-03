using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int lifeValue = 3;
    public int playerScore = 0;
    public GameObject born;
    public Text PlayerScoreText;
    public Text LifeValueText;

    public GameObject gameover;


    //µ¥Àý
    private static PlayerManager instanse;

    public static PlayerManager Instanse
    {
        get
        {
            return instanse;
        }
        set
        {
            instanse = value;
        }
    }

    private void Awake()
    {
        Instanse = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScoreText.text = playerScore.ToString();
        LifeValueText.text = lifeValue.ToString();
    }

    public void Recover()
    {
        if (lifeValue <= 0)
        {
            gameover.SetActive(true);
            Invoke("ReturnTitle", 3);
            return;
        }
        else
        {
            lifeValue--;
            GameObject go = Instantiate(born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<Born>().isplay = true;

        }
    }

    private void ReturnTitle()
    {
        SceneManager.LoadScene(0);
        
    }
}
