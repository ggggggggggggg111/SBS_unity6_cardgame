using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    float cur_timer = 0;
    float destroy_timer = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cur_timer += Time.deltaTime;

        if (cur_timer > destroy_timer)
        {
            Destroy(gameObject);
            cur_timer = 0;
        }
        
    }
}
