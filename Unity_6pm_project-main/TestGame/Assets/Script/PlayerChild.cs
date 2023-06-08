using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerChild : MonoBehaviour
{
    BoxCollider2D box;

    public Vector2 center;
    public Vector2 size;

    public Player playercs;
    void Start()
    {
       
        box = GetComponent<BoxCollider2D>();
        size = box.size;
        center = box.offset;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        center = transform.position + new Vector3(0, 2, 0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.transform.tag == "Enemy")
        {
            playercs.enemy_arr.Add(collision.gameObject);
        }
        Debug.Log("Ãæµ¹ ÇÔ:."+collision.gameObject.name);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            playercs.enemy_arr.Remove(collision.gameObject);
        }
       
    }
}
