using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    float cur_timer;
    float destroy_timer=7;

    public int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cur_timer += Time.deltaTime;

        if(cur_timer> destroy_timer) 
        {

            gameObject.SetActive(false);
            cur_timer= 0;
        }

        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag=="PlayerBullet")
        {
            hp = hp - 1;
            Debug.Log("�Ѿ��� ��ҽ��ϴ�.");

            collision.gameObject.SetActive(false);


            if (hp <=0)
            {
                cur_timer = 0;
                gameObject.SetActive(false);
            }
        }
    
        
    }


}
