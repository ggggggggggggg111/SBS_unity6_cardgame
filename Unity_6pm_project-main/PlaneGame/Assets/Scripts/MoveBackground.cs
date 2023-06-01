using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    Rigidbody2D my_rigid;

    
    void Start()
    {
        my_rigid= GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        my_rigid.MovePosition(transform.position + Vector3.down*Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "BGBoundary")
        {
            transform.position = new Vector3(0,104.5472f,0);
        }
    }
}
