using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{    
    //collision stuff
    public float collisionOffset = 0.05f;
    Rigidbody2D player1;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    void Start()
    {
        player1 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            CheckForCollision(Vector2.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            CheckForCollision(Vector2.down);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            CheckForCollision(Vector2.right);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            CheckForCollision(Vector2.left);
        }
    }

    private void CheckForCollision(Vector2 vector)
    {
        int count = player1.Cast(vector, movementFilter, castCollisions, Time.fixedDeltaTime + collisionOffset);
        Debug.DrawRay(vector, Vector2.up);
        if(count == 0) 
        {
            transform.Translate(vector);
        }
    }
}