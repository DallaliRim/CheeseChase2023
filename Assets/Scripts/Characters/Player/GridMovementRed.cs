using UnityEngine;

public class GridMovementRed : MonoBehaviour
{
    public LayerMask layerMask;
    public Manager_Money moneyManager;
    public float gridSize;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !HitRaycast(Vector2.up))
        {
            transform.Translate(Vector2.up * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.S) && !HitRaycast(Vector2.down))
        {
            transform.Translate(Vector2.down * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.D) && !HitRaycast(Vector2.right))
        {
            transform.Translate(Vector2.right * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.A) && !HitRaycast(Vector2.left))
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
            CheckMoneySpill(hit.collider.gameObject.tag);
            return true;
        }
        else
        {
            Debug.Log("Hiting nothing");
            return false;
        }
    }

    void CheckMoneySpill(string colliderTag)
    {
        if(colliderTag == "bankTeller")
        {
            moneyManager.moneyPlayerRed = 0;
        }
    }
}
