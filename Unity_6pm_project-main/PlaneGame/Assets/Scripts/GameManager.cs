using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject astroid;
    public GameObject[] spawn_pos;
    
    float cur_timer = 0;
    float spawn_delay = .7f;

    Enemy enemycs;

    public ObjectManager obj_manager;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        cur_timer = cur_timer + Time.deltaTime;
        //cur_timer += Time.deltaTime; // À§¶û °°Àº°Å

        if(cur_timer> spawn_delay)
        {
            SpawnEnumy();
            cur_timer = 0;

        }



       
    }


    void SpawnEnumy()
    {
        int randnum = Random.Range(0, 4);
        GameObject enemy_info
            = obj_manager.Selectobj();
         enemy_info.transform.position = spawn_pos[randnum].transform.position;
        enemycs = enemy_info.GetComponent<Enemy>();
        enemycs.hp = 3;

        Rigidbody2D astroid_rigid = enemy_info.GetComponent<Rigidbody2D>();
        astroid_rigid.AddForce(Vector2.down * 3, ForceMode2D.Impulse);
    }
}
