using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public Vector2 input_vec;
    public Vector2 next_vec;
    

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    
    // Update is called once per frame
    void Update()
    {
        input_vec.x = Input.GetAxisRaw("Horizontal");
        input_vec.y = Input.GetAxisRaw("Vertical");

        next_vec = input_vec.normalized;
        
    }
    private void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + next_vec * Time.fixedDeltaTime);
    }
}
