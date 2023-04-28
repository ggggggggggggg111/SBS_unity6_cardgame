using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] card;


    public Sprite[] my_sprites;


    List<string> card_list = new List<string>();
    List<int> card_list_numOnly = new List<int>();
    List<string> card_list_shapeOnly = new List<string>();



    [SerializeField] SpriteRenderer[] sr_array;




    SpriteRenderer card_renderer;
    void Start()
    {

        for (int i = 0; i < card.Length; i++)
        {

            sr_array[i] = card[i].GetComponent<SpriteRenderer>();
            sr_array[i].sprite = my_sprites[i];



            card_renderer = card[i].GetComponent<SpriteRenderer>();

            card_renderer.sprite = my_sprites[i];

            card_list.Add(card_renderer.sprite.name);
            card_list_numOnly.Add(int.Parse(card_renderer.sprite.name.Substring(0, 2)));
            card_list_shapeOnly.Add(card_renderer.sprite.name.Substring(2, 1));



            /*Debug.Log("sr_array" + sr_array[i].sprite.name);
            Debug.Log(card_list[i]);
            Debug.Log(card_list_numOnly[i]);
            Debug.Log(card_list_shapeOnly[i]);*/
        }


        card_list_numOnly.Sort();
        card_list_shapeOnly.Sort();

        Batting();
    }


    // Update is called once per frame
    void Update()
    {

    }
    public void Batting()
    {

        int paircount = 0;

        for (int i = 0; i < card_list_numOnly.Count; i++)
        {
            for (int j = i; j < card_list_numOnly.Count; j++)
            {

                if (i == j)
                    continue;

                if (card_list_numOnly[i] == card_list_numOnly[j])
                {
                    paircount++;
                }

            }

        }
        bool isStraight = false;
        int strightcount = 0;
        bool isRoyalStraight = false;
        bool isflush = false;
        int a = card_list_numOnly[card_list_numOnly.Count - 1] - card_list_numOnly[0];

        if ((card_list_numOnly[0] == 6) && (card_list_numOnly[1] == 10) && (card_list_numOnly[2] == 11)
            && (card_list_numOnly[3] == 12) && (card_list_numOnly[4] == 13))
        {
            isRoyalStraight = true;
        }

        for (int i = 0; i < card_list_numOnly.Count - 1; i++)
        {
            isStraight = (card_list_numOnly[i + 1] - card_list_numOnly[i]) == 1;
            if (isStraight)
                strightcount++;
        }


        if (card_list_shapeOnly[0] == card_list_shapeOnly[card_list_shapeOnly.Count - 1])
        {
            isflush = true;
        }
        if (isRoyalStraight && isflush)
            Debug.Log("Royal Straight Flush");

        else if (strightcount == 4 && isflush)
            Debug.Log("Straight Flush");

        else if (isRoyalStraight)
            Debug.Log(" Royal Flush");

        else if (isflush)
            Debug.Log("Flush");

        else if (strightcount == 4)
            Debug.Log("Straight");

        else if (paircount == 6)
            Debug.Log("Four Card");

        else if (paircount == 4)
            Debug.Log("Full House");

        else if (paircount == 3)
            Debug.Log("Three Pair");

        else if (paircount == 2)
            Debug.Log("Two Pair");

        else if (paircount == 1)
            Debug.Log("One Pair");

        else
            Debug.Log("Top Card");
    }


}
