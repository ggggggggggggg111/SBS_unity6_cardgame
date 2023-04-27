using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_card : MonoBehaviour
{
    Rigidbody2D my_rigid;

    Vector3 my_position;
    Vector3 goal_position;
    Vector3 hang_position;
    Vector3 home_position;
    [SerializeField] GameObject goal;
    [SerializeField] GameObject home;

    public bool HomeMove_bool = false;
    void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();

        my_position= transform.position;
        goal_position = goal.transform.position;
        hang_position = goal_position - my_position;
        home_position = home.transform.position;
        /*Debug.Log("my_position : " +my_position);
        Debug.Log("goal_position : " + goal_position);
        Debug.Log("Add_position : "+hang_position);
        Debug.Log("hang_positionAc normal" + hang_position.normalized);*/

    }
    void HomeMove()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (HomeMove_bool == true)
            {
                HomeMove_bool = false;
            }
            else
            {
                HomeMove_bool = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        HomeMove();
        if (HomeMove_bool == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, home_position, 10 * Time.deltaTime);
        }
        else
        {
            hang_position = goal_position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, goal_position, 3 * Time.deltaTime);
        }

        
    }
}
