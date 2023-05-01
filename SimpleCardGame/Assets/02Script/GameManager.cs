using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{
    public GameObject[] card;

    public Text chnageText;

    public Sprite[] my_sprites;


    List<string> card_list = new List<string>();
    List<int> card_list_numOnly = new List<int>();
    List<string> card_list_shapeOnly = new List<string>();
    List<int> card_list_rendnum= new List<int>();


    [SerializeField] SpriteRenderer[] sr_array;


    

    SpriteRenderer card_renderer;
    void Start()
    {
        UnduplicateRandom(card_list_rendnum);
        chnageText.text = "게임 시작합니다.";
        for (int i = 0; i < card.Length; i++)
        {

            sr_array[i] = card[i].GetComponent<SpriteRenderer>();
            sr_array[i].sprite = my_sprites[i];



            card_renderer = card[i].GetComponent<SpriteRenderer>();

            card_renderer.sprite = my_sprites[card_list_rendnum[i]];

            card_list.Add(my_sprites[card_list_rendnum[i]].name);
            card_list_numOnly.Add(int.Parse(my_sprites[card_list_rendnum[i]].name.Substring(0, 2)));
            card_list_shapeOnly.Add(my_sprites[card_list_rendnum[i]].name.Substring(2, 1));



            /*Debug.Log("sr_array" + sr_array[i].sprite.name);
            Debug.Log(card_list[i]);
            Debug.Log(card_list_numOnly[i]);
            Debug.Log(card_list_shapeOnly[i]);*/
        }


        card_list_numOnly.Sort();
        card_list_shapeOnly.Sort();

        

        
    }

    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void UnduplicateRandom(List<int> card_list_rendnum)
    {
        int tmp_random = UnityEngine.Random.Range(0, 32);

        for (int i = 0; i < 7;)
        {
            if (card_list_rendnum.Contains(tmp_random))
            {
                tmp_random = UnityEngine.Random.Range(0, 32);
            }
            else
            {
                card_list_rendnum.Add(tmp_random);
                i++;
            }
        }

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
            chnageText.text ="Royal Straight Flush";

        else if (strightcount == 4 && isflush)
            chnageText.text = "Straight Flush";

        else if (isRoyalStraight)
            chnageText.text = " Royal Flush";

        else if (isflush)
            chnageText.text = "Flush";

        else if (strightcount == 4)
            chnageText.text = "Straight";

        else if (paircount == 6)
            chnageText.text = "Four Card";

        else if (paircount == 4)
            chnageText.text = "Full House";

        else if (paircount == 3)
            chnageText.text = "Three Pair";

        else if (paircount == 2)
            chnageText.text = "Two Pair";

        else if (paircount == 1)
            chnageText.text = "One Pair";

        else
            chnageText.text = "Top Card";
    }


}
