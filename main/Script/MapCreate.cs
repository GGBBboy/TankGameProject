using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    //0.�ϼ� 1.ǽ 2.�ϰ� 3����Ч�� 4���� 5 �� 6����ǽ
    public GameObject[] item;
    Dictionary<Vector3,bool> itemPosition=new Dictionary<Vector3, bool>();
    private void Awake()
    {
        InitMap();

    }
    
   
    
    private void InitMap()
    {
        //�ϼ�
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        //Χ�����ϼ�
        int i, j;
        for (i = -1; i <= 1; i++)
        {
            for (j = -8; j <= -7; j++)
            {
                if (j == -8 && i == 0)
                {
                    continue; ;
                }
                else
                    CreateItem(item[1], new Vector3(i, j, 0), Quaternion.identity);
            }
        }
        //ʵ��������ǽ
        for (i = -11; i <= 11; i++)
        {
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (i = -8; i <= 8; i++)
        {
            CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
        }
        //
        for (i = 0; i < 60; i++)
        {
            CreateItem(item[1], createRandomPosition(), Quaternion.identity);
        }
        for (i = 0; i < 20; i++)
        {
            CreateItem(item[2], createRandomPosition(), Quaternion.identity);
        }
        for (i = 0; i < 20; i++)
        {
            CreateItem(item[4], createRandomPosition(), Quaternion.identity);
        }
        for (i = 0; i < 20; i++)
        {
            CreateItem(item[5], createRandomPosition(), Quaternion.identity);

        }
        //���
        GameObject go = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<Born>().isplay = true;
        //����
        CreateItem1(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem1(item[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem1(item[3], new Vector3(10, 8, 0), Quaternion.identity);
        InvokeRepeating("CreateEnemy", 4, 5);
    }
    private void CreateItem(GameObject gameObject1, Vector3 v3,Quaternion quaternion)
    {
        GameObject itemGo = Instantiate(gameObject1, v3, quaternion);
        itemGo.transform.SetParent(gameObject.transform);
        itemPosition.Add(v3,true);
    }
    private void CreateItem1(GameObject gameObject1, Vector3 v3, Quaternion quaternion)
    {
        GameObject itemGo = Instantiate(gameObject1, v3, quaternion);
        itemGo.transform.SetParent(gameObject.transform);
    }

    private Vector3 createRandomPosition()
    {
        while (true)
        {
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if(!itemPosition.ContainsKey(createPosition))
            return createPosition;
        }
    }
    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        Vector3 EnemyPos = new Vector3();
        if (num == 0)
        {
            EnemyPos = new Vector3(-10, 8, 0);
        }
        else if (num == 1)
        {
            EnemyPos = new Vector3(0, 8, 0);
        }
        else if (num == 2)
        {
            EnemyPos = new Vector3(10, 8, 0);
        }
        CreateItem1(item[3], EnemyPos, Quaternion.identity);
    }
}
