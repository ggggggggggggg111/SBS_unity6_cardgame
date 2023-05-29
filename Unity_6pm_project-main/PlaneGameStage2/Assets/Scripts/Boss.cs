using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;

    public GameObject[] barrels; 

    int patten_select = 0;

    List<GameObject> bullet_arr = new List<GameObject>();
    List<Rigidbody2D> rigid_arr = new List<Rigidbody2D>();

    float cur_timer;
    float delay_timer = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BossPatten", 3);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            new Vector3(0, 5.2f, 0), 2*Time.deltaTime);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(collision.gameObject);
            
        }
    }

    void BossPatten()
    {



        

        patten_select += 1;
        if (patten_select >= 4)
        {
            patten_select = 0;
        }
        
        switch (patten_select)
        {
            case 0:
                StartCoroutine(FireCross());
                break;
            case 1:
                StartCoroutine(FireX());
                break;
            case 2: StartCoroutine(FireCircle());
                break;
            case 3:
                StartCoroutine(FireSin());
                break;


        }



    }

    IEnumerator FireCross()
    {
    
        for (int i = 0; i < 4; i++)
        {
            bullet_arr.Add(Instantiate(bullet, transform.position, transform.rotation));

            rigid_arr.Add( bullet_arr[i].GetComponent<Rigidbody2D>() );

            Vector2 bullet_dir = player.transform.position - transform.position;
            bullet_dir = bullet_dir.normalized;

            rigid_arr[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.5f);

        int index = 0;
        Vector2 bullet_dir2 = new Vector2(1, 0);
        for (int i = 0; i < 4; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir2 = new Vector2(1, 0);
                    break;

                case 1:
                    bullet_dir2 = new Vector2(-1, 0);
                    break;

                case 2:
                    bullet_dir2 = new Vector2(0, 1);
                    break;

                case 3:
                    bullet_dir2 = new Vector2(0, -1);
                    break;
            }

            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir2 * 5, ForceMode2D.Impulse);
            index++;            //ÃÑ¾Ë 1tpxm qkftk

        }

        for (int i = 4; i < 8; i++)
        {
            bullet_arr.Add(Instantiate(bullet, transform.position, transform.rotation));

            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());

            Vector2 bullet_dir = player.transform.position - transform.position;
            bullet_dir = bullet_dir.normalized;

            rigid_arr[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.5f);

        index = 0;
        for (int i = 8; i < 12; i++)
        {
            bullet_arr.Add(Instantiate(bullet, transform.position, transform.rotation));

            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());

            Vector2 bullet_dir = player.transform.position - transform.position;
            bullet_dir = bullet_dir.normalized;

            rigid_arr[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.5f);
        index = 0;
        for (int i = 0; i < 4; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir2 = new Vector2(1, 0);
                    break;

                case 1:
                    bullet_dir2 = new Vector2(-1, 0);
                    break;

                case 2:
                    bullet_dir2 = new Vector2(0, 1);
                    break;

                case 3:
                    bullet_dir2 = new Vector2(0, -1);
                    break;
            }

            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir2 * 5, ForceMode2D.Impulse);
            index++;

        }

        rigid_arr.Clear();
        bullet_arr.Clear();


        Invoke("BossPatten", 1);

    }


    IEnumerator FireX()
    {


        for (int i = 0; i < 4; i++)
        {
            bullet_arr.Add(Instantiate(bullet, transform.position, transform.rotation));

            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());

            Vector2 bullet_dir = player.transform.position - transform.position;
            bullet_dir = bullet_dir.normalized;

            rigid_arr[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.5f);

        int index = 0;
        Vector2 bullet_dir2 = new Vector2(1, 0);
        for (int i = 0; i < 4; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir2 = new Vector2(1, 1);
                    break;

                case 1:
                    bullet_dir2 = new Vector2(-1, 1);
                    break;

                case 2:
                    bullet_dir2 = new Vector2(1, -1);
                    break;

                case 3:
                    bullet_dir2 = new Vector2(-1, -1);
                    break;
            }

            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir2 * 5, ForceMode2D.Impulse);
            index++;            //ÃÑ¾Ë 1tpxm qkftk

        }

        for (int i = 4; i < 8; i++)
        {
            bullet_arr.Add(Instantiate(bullet, transform.position, transform.rotation));

            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());

            Vector2 bullet_dir = player.transform.position - transform.position;
            bullet_dir = bullet_dir.normalized;

            rigid_arr[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.5f);

        index = 0;
        for (int i = 8; i < 12; i++)
        {
            bullet_arr.Add(Instantiate(bullet, transform.position, transform.rotation));

            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());

            Vector2 bullet_dir = player.transform.position - transform.position;
            bullet_dir = bullet_dir.normalized;

            rigid_arr[i].AddForce(bullet_dir * 10, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(.5f);
        index = 0;
        for (int i = 0; i < 4; i++)
        {
            switch (index)
            {
                case 0:
                    bullet_dir2 = new Vector2(1, 1);
                    break;

                case 1:
                    bullet_dir2 = new Vector2(-1, 1);
                    break;

                case 2:
                    bullet_dir2 = new Vector2(1, -1);
                    break;

                case 3:
                    bullet_dir2 = new Vector2(-1, -1);
                    break;
            }

            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir2 * 5, ForceMode2D.Impulse);
            index++;            //ÃÑ¾Ë 1tpxm qkftk

        }

        rigid_arr.Clear();
        bullet_arr.Clear();


        Invoke("BossPatten", 1);
    }


    IEnumerator FireCircle()
    {
        Vector2 dir;
        for (int i = 0; i < 30; i++)
        {


            bullet_arr.Add(Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation));
            rigid_arr.Add(bullet_arr[i].GetComponent<Rigidbody2D>());
           dir = player.transform.position - transform.position;          
            rigid_arr[i].AddForce(dir.normalized * 4, ForceMode2D.Impulse);

        }
        yield return new WaitForSeconds(1);

        
        
        for (int i = 0; i < 30; i++)
        {

            Vector2 bullet_dir = new Vector2(Mathf.Cos(Mathf.PI * 2 * i / 30), Mathf.Sin(Mathf.PI * 2 * i / 30));
            rigid_arr[i].velocity = Vector2.zero;
            rigid_arr[i].AddForce(bullet_dir.normalized * 3, ForceMode2D.Impulse);
                    

        }
        

       

        rigid_arr.Clear();
        bullet_arr.Clear();


        Invoke("BossPatten", 1);
    }


    IEnumerator FireSin()
    {
        for (int i = 0; i < 30; i++)
        {
            GameObject bullet_info1 = Instantiate(bullet, barrels[0].transform.position, barrels[0].transform.rotation);
            GameObject bullet_info2 = Instantiate(bullet, barrels[1].transform.position, barrels[1].transform.rotation);

            Rigidbody2D bullet_rigid1 = bullet_info1.GetComponent<Rigidbody2D>();
            Rigidbody2D bullet_rigid2 = bullet_info2.GetComponent<Rigidbody2D>();

            Vector2 bullet_dir1 = new Vector2(Mathf.Sin(Mathf.PI * 3 * i/30), -1);
            Vector2 bullet_dir2 = new Vector2(Mathf.Sin(Mathf.PI * 3 * i/30), -1);

            bullet_rigid1.AddForce(bullet_dir1.normalized * 5, ForceMode2D.Impulse);
            bullet_rigid2.AddForce(bullet_dir2.normalized * 5, ForceMode2D.Impulse);

            yield return new WaitForSeconds(.3f);
        }

        Invoke("BossPatten", 1);
    }
}


