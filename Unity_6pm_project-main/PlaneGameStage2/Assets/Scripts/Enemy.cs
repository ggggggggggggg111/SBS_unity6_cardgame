using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    float cur_timer=0;
    float destory_timer=5;

    float hp = 3;

    public GameObject item;
    public GameObject playerobj;
    public Player playercs;
    public GameObject particleEffect;

    public ParticleSystem particle;
    
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

        cur_timer += Time.deltaTime;
        //cur_timer = cur_timer + Time.deltaTime;

        if(cur_timer> destory_timer)
        {
            Destroy(gameObject);
            cur_timer= 0;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "PlayerBullet")
        {
            hp = hp - 1;

            particle.Play();
            Destroy(collision.gameObject);

            Instantiate(particleEffect, collision.transform.position,
                collision.transform.rotation);


            if (hp <= 0)
            {
                int randnum = Random.Range(0,10);

                if (randnum > 5)
                {
                    Instantiate(item, collision.transform.position,
                    collision.transform.rotation);
                }


                Destroy(gameObject);
                playercs.score += 100;
                
                
            }



        }

        
    }
    


}
