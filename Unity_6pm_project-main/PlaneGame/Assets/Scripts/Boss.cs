using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Rigidbody2D my_rigid;

    public ObjectManager obj_manager_in_bosscs;
    public GameObject barrel;

    float cur_timer=0;
    float delay_timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        my_rigid= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        cur_timer = cur_timer+ Time.deltaTime;
        transform.position = 
            Vector3.MoveTowards(transform.position,new Vector3(0,5,0),2*Time.deltaTime);
        if (cur_timer>delay_timer)
        {
            GameObject bossbullet = obj_manager_in_bosscs.SelectObj("BossBullet");
            bossbullet.transform.position = barrel.transform.position;
            Rigidbody2D bullet_rigid =bossbullet.GetComponent<Rigidbody2D>();
            bullet_rigid.AddForce(Vector2.down * 3, ForceMode2D.Impulse);

            cur_timer = 0;
        }
    }
    
}
