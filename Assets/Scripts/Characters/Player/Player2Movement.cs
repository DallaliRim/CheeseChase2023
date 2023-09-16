using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    //collision stuff
    public float collisionOffset = 0.05f;
    Rigidbody2D player2;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    void Start()
    {
        player2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CheckForCollision(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            CheckForCollision(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CheckForCollision(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CheckForCollision(Vector2.left);
        }
    }

    private void CheckForCollision(Vector2 vector)
    {
        int count = player2.Cast(vector, movementFilter, castCollisions, Time.fixedDeltaTime + collisionOffset);
        Debug.DrawRay(vector, Vector2.up);
        if(count == 0) 
        {
            transform.Translate(vector);
        }
    }
}
