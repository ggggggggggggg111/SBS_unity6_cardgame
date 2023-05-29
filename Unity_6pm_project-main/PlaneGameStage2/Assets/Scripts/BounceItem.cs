using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceItem : MonoBehaviour
{
    Rigidbody2D my_rigid;

    void Start()
    {
        my_rigid= GetComponent<Rigidbody2D>();
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);

        Vector2 nextDir = new Vector2(randomX, randomY).normalized;
        my_rigid.AddForce(nextDir*500);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
