using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public GameObject target;

    public Vector2 radius;
    public Vector2 cube_size;
    // Start is called before the first frame update

    float cam_height;
    float cam_width;
    void Start()
    {
        cam_height = Camera.main.orthographicSize;
        cam_width = cam_height * Screen.width / Screen.height;

        Debug.Log(cam_height);
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(radius, cube_size);


    }


    private void FixedUpdate()
    {
        transform.position =
            new Vector3(target.transform.position.x,
                        target.transform.position.y,
                        -10);

        float camBoundaryX = cube_size.x * 0.5f - cam_width;
        float camBoundaryY = cube_size.y * 0.5f - cam_height;

        float clampX = Mathf.Clamp(transform.position.x, -camBoundaryX + radius.x,
                                                        camBoundaryX + radius.x);
        float clampY = Mathf.Clamp(transform.position.y, -camBoundaryY + radius.y,
                                                        camBoundaryY + radius.y);

        transform.position = new Vector3(clampX,clampY,-10);
    }


}
