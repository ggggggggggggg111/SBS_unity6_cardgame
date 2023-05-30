using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    
    public GameObject enemy;

    GameObject[] enemy_arr;
    
    void Start()
    {

        enemy_arr= new GameObject[30];
       
        
        InitObj();

    }

    void InitObj()
    {
        for(int i =0; i<enemy_arr.Length; i++)
        {
            enemy_arr[i] = Instantiate(enemy);
            enemy_arr[i].SetActive(false);

        }

    }

    public GameObject Selectobj()
    {

        for (int i = 0; i < enemy_arr.Length; i++)
        {
            if (!enemy_arr[i].activeSelf)
            {
                enemy_arr[i].SetActive(true);
                return enemy_arr[i];
            }

        }
        return null;
    }

}
