using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_card : MonoBehaviour
{
    Rigidbody2D my_rigid;

    Vector2 my_position;
    Vector2 goal_position;
    Vector2 hang_position;
    [SerializeField] GameObject goal;
    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();

        my_position= transform.position;
        goal_position = goal.transform.position;
        hang_position = goal_position - my_position;

        Debug.Log("my_position : " +my_position);
        Debug.Log("goal_position : " + goal_position);
        Debug.Log("Add_position : "+hang_position);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
