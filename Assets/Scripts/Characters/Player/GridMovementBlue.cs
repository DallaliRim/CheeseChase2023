using UnityEngine;

public class GridMovementBlue : MonoBehaviour
{
    public LayerMask layerMask;
    public float gridSize;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !HitRaycast(Vector2.up))
        {
            transform.Translate(Vector2.up * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !HitRaycast(Vector2.up))
        {
            transform.Translate(Vector2.down * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !HitRaycast(Vector2.up))
        {
            transform.Translate(Vector2.right * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && !HitRaycast(Vector2.up))
        {
            transform.Translate(Vector2.left * gridSize);
        }
    }
    bool HitRaycast(Vector2 fwd)
    {
        float laserLength = 1f; //Length of the ray

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
