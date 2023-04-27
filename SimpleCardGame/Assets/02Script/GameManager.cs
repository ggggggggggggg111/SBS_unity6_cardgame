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




    SpriteRenderer card_renderer;
    void Start()
    {

        for (int i = 0; i < card.Length; i++)
        {
            card_renderer = card[i].GetComponent<SpriteRenderer>();

            card_renderer.sprite = my_sprites[i];

            card_list.Add(card_renderer.sprite.name);
            card_list_numOnly.Add(int.Parse(card_renderer.sprite.name.Substring(0,2)));
            card_list_shapeOnly.Add(card_renderer.sprite.name.Substring(2,1));

            Debug.Log(card_list[i]);
            Debug.Log(card_list_numOnly[i]);
            Debug.Log(card_list_shapeOnly[i]);
        }

        if (card_list_numOnly[1] == card_list_numOnly[2] ||
            card_list_numOnly[1] == card_list_numOnly[3] ||
            card_list_numOnly[1] == card_list_numOnly[4] ||
            card_list_numOnly[1] == card_list_numOnly[5] )
        {

        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
