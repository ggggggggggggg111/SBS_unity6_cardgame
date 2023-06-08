using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D my_rigid;
    Animator my_animatior;
    SpriteRenderer my_SR;

    public List<GameObject> enemy_arr = new List<GameObject>();
    public Vector2 input_vec;
    public Vector2 next_vec;
    

    // Start is called before the first frame update
    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        my_animatior= GetComponent<Animator>();
        my_SR = GetComponent<SpriteRenderer>();
    }

    
    // Update is called once per frame
    void Update()
    {
        input_vec.x = Input.GetAxisRaw("Horizontal");
        input_vec.y = Input.GetAxisRaw("Vertical");

        next_vec = input_vec.normalized;
        if (enemy_arr.Count !=0)
        {
            for (int i = 0; i < enemy_arr.Count; i++)
            {
                Debug.DrawRay(transform.position,
                    enemy_arr[i].transform.position - transform.position, Color.red);
            }
            

            Vector2 dir = enemy_arr[0].transform.position - transform.position;

            //Debug.Log( Mathf.Sqrt(dir.x*dir.x + dir.y*dir.y));

            //Debug.Log(Vector2.Distance(transform.position, enemy_arr[0].transform.position));
        }
        
    }
    private void FixedUpdate()
    {
        my_rigid.MovePosition(my_rigid.position + next_vec * Time.fixedDeltaTime);
        my_animatior.SetFloat("speed", next_vec.magnitude);

        if (next_vec.x<0)
        {
            my_SR.flipX= true;
        }
        else if (next_vec.x>0)
        {
            my_SR.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("parent¸Â´Ù");
        }
    }
}
