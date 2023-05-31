using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public GameObject playerobj;
    public GameObject astroid;
    public GameObject[] spawn_pos;
    public GameObject player_spawn_pos;

    GameObject player_info;
    
    float cur_timer = 0;
    float spawn_delay = .7f;

    Enemy enemycs;
    Player playercs;

    

    public ObjectManager obj_manager_in_gm;

    private void Awake()
    {
        player_info = Instantiate(playerobj, player_spawn_pos.transform.position,
                        player_spawn_pos.transform.rotation);
        playercs = player_info.GetComponent<Player>();
        playercs.obj_manager = obj_manager_in_gm;


    }

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
            SpawnEnemy();

            cur_timer = 0;

        }



       
    }


    

    void SpawnEnemy()
    {
        int randnum = Random.Range(0, 4);

        GameObject enemy_info
            = obj_manager_in_gm.SelectObj("Enemy");

        enemy_info.transform.position = spawn_pos[randnum].transform.position;
        enemycs = enemy_info.GetComponent<Enemy>();
        enemycs.hp = 3;
        enemycs.obj_manager = obj_manager_in_gm;

        Rigidbody2D astroid_rigid = enemy_info.GetComponent<Rigidbody2D>();
        astroid_rigid.AddForce(Vector2.down * 7, ForceMode2D.Impulse);

    }



}
