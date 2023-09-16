using UnityEngine;
using UnityEngine.Events;

public class GridMovementBlue : MonoBehaviour
{
    public LayerMask layerMask;
    public Manager_Money moneyManager;
    public float gridSize;
    private BeatManager beatManager;

    void Start()
    {
        beatManager = BeatManager.Instance;
    }

    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (beatManager.IsOnBeat)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) && !HitRaycast(Vector2.up))
                {
                    transform.Translate(Vector2.up * gridSize);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) && !HitRaycast(Vector2.down))
                {
                    transform.Translate(Vector2.down * gridSize);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) && !HitRaycast(Vector2.right))
                {
                    transform.Translate(Vector2.right * gridSize);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && !HitRaycast(Vector2.left))
                {
                    transform.Translate(Vector2.left * gridSize);
                }
            }
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
        if (colliderTag == "bankTeller")
        {
            moneyManager.moneyPlayerBlue = 0;
        }
    }
}
