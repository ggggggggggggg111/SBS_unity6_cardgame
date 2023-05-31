using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject sparkle_expl;
    public GameObject enemy;
    public GameObject playerBullet;

    GameObject[] enemy_arr;
    GameObject[] playerBullet_arr;
    GameObject[] sparkle_expl_arr;

    GameObject[] obj_arr;

    void Start()
    {

        enemy_arr= new GameObject[30];
        playerBullet_arr = new GameObject[50];
        sparkle_expl_arr = new GameObject[30];


        InitObj();

    }

    void InitObj()
    {
        for(int i =0; i<enemy_arr.Length; i++)
        {
            enemy_arr[i] = Instantiate(enemy);
            enemy_arr[i].SetActive(false);

        }
        for(int i=0; i<playerBullet_arr.Length; i++)
        {
            playerBullet_arr[i] = Instantiate(playerBullet);
            playerBullet_arr[i].SetActive(false);

        }
        for (int i = 0; i < sparkle_expl_arr.Length; i++)
        {
            sparkle_expl_arr[i] = Instantiate(sparkle_expl);
            sparkle_expl_arr[i].SetActive(false);
        }

    }

    public GameObject SelectObj(string name)
    {

        switch (name)
        {
            case "Enemy":
                obj_arr = enemy_arr;
                break;

            case "PlayerBullet":
                obj_arr = playerBullet_arr;
                break;

            case "Sparkle_expl":
                obj_arr = sparkle_expl_arr;
                break;


        }


        for(int i =0; i<obj_arr.Length; i++)
        {

            if (!obj_arr[i].activeSelf)
            {
                obj_arr[i].SetActive(true);
                return obj_arr[i];
            }

        }

        return null;

    }


}
