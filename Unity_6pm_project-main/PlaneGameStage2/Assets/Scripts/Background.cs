using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Background : MonoBehaviour
{
    Rigidbody2D my_rigid;
    float back_speed = 2.0f;

    void Start()
    {
        my_rigid= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        my_rigid.MovePosition(my_rigid.position + (Vector2.down * back_speed * Time.fixedDeltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BackGroundBoundary")
        {

            transform.position = transform.position + new Vector3(0, 20.48f * 3, 0);

        }
        





    }


}
