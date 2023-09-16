using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovementRed : MonoBehaviour
{

    public float gridSize;

    // Start is called before the first frame update
    void Start()
    {
        //test
    }

    public LayerMask layerMask;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !HitRaycast(Vector2.up))
        {
            transform.Translate(Vector2.up * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !HitRaycast(Vector2.down))
        {
            transform.Translate(Vector2.down * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !HitRaycast(Vector2.right))
        {
            transform.Translate(Vector2.right * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !HitRaycast(Vector2.left))
        {
            transform.Translate(Vector2.left * gridSize);
        }

    }

    // private void FixedUpdate()
    // {
    //     HitRaycast(Vector2.up);
    // }

    bool HitRaycast(Vector2 fwd)
    {

        //Length of the ray
        float laserLength = 1f;

        //Get the first object hit by the ray

        RaycastHit2D hit = Physics2D.Raycast(transform.position, fwd, laserLength, ~layerMask);
        //Method to draw the ray in scene for debug purpose
        Debug.DrawRay(transform.position, fwd * laserLength, Color.red);
        if (hit.collider != null)
        {
            //Hit something, print the tag of the object
            Debug.Log("Hitting: " + hit.collider.gameObject.name);
            return true;
        }
        else
        {
            Debug.Log("Hiting nothing");
            return false;
        }


    }
}
