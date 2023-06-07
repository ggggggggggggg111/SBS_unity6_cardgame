using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Bossobj;
    public GameObject playerobj;
    public GameObject astroid;
    public GameObject[] spawn_pos;
    public GameObject player_spawn_pos;
    

    public GameObject boss_spawn_pos;
    public GameObject boss_hp_bar_obj;
    public GameObject player_hpbar_obj;

    public GameObject game_over_obj;
    public GameObject game_Win_obj;

    GameObject player_info;
    GameObject boss_info;

    float cur_timer = 0;
    float spawn_delay = .7f;

    bool isBossSpawn = true;
    bool isBossAlive = false;

    Enemy enemycs;
    Player playercs_in_gm;
    Boss bosscs;
    Slider boss_hp_slider;
    Slider player_hpdar;

    float cur_hp = 100;
    float max_hp = 100;


    
    public Text score_text;
    public Text game_over_text;
    public Text game_win_text;
    public float score = 0;
    

    public ObjectManager obj_manager_in_gm;
    public GameManager playercs;
    public GameObject player_hit_damage;
    

    private void Awake()
    {
        player_info = Instantiate(playerobj, player_spawn_pos.transform.position,
                        player_spawn_pos.transform.rotation);
        playercs_in_gm = player_info.GetComponent<Player>();
        playercs_in_gm.obj_manager = obj_manager_in_gm;
        
        boss_hp_slider = boss_hp_bar_obj.GetComponent<Slider>();

        player_hpdar = player_hpbar_obj.GetComponent<Slider>();



    }

    private void LateUpdate()
    {
        score_text.text = playercs_in_gm.score.ToString();
        if(isBossAlive) 
        {
            boss_hp_slider.value = bosscs.cur_hp / bosscs.max_hp;
        }
        if (bosscs.cur_hp <= 0)
        {
            game_Win_obj.SetActive(true);
            game_win_text.text = "!!!!YOU WIN!!!!";

            isBossAlive= false;
            Invoke("StopTime", 1);
        }

        player_hpdar.value = playercs_in_gm.cur_hp / playercs_in_gm.max_hp;
        if (playercs_in_gm.cur_hp <=0)
        {
            game_over_obj.SetActive(true);
            game_over_text.text = "!!!!GameOver!!!!";
        }
    }
    void Start()
    {

        Time.timeScale = 1.0f;
    }
    
    // Update is called once per frame
    void Update()
    {
        cur_timer = cur_timer + Time.deltaTime;
        //cur_timer += Time.deltaTime; // ���� ������


        if ((cur_timer > spawn_delay) && isBossSpawn)
        {
            SpawnBoss();

        }

        if (isBossAlive)
        {
            boss_hp_slider.value = bosscs.cur_hp / bosscs.max_hp;
        }

        if (cur_timer> spawn_delay)
        {
            SpawnEnemy();

            cur_timer = 0;

            cur_hp = cur_hp - 1;
            

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
        enemycs.playercs = playercs_in_gm;
        Rigidbody2D astroid_rigid = enemy_info.GetComponent<Rigidbody2D>();
        astroid_rigid.AddForce(Vector2.down * 7, ForceMode2D.Impulse);

    }

    void SpawnBoss()
    {

        boss_info = Instantiate(Bossobj, boss_spawn_pos.transform.position,
                boss_spawn_pos.transform.rotation);
        bosscs = boss_info.GetComponent<Boss>();

        bosscs.obj_manger_in_bosscs = obj_manager_in_gm;
        bosscs.player = player_info;

        isBossSpawn = false;
        isBossAlive = true;

    }
    public void Restart()
    {
        SceneManager.LoadScene("Stage1");
        
    }
    public void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
     void StopTime()
    {
            Time.timeScale = 0;

    }


}
