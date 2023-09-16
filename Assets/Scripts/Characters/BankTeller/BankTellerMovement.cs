using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankTellerMovement : MonoBehaviour
{
    public float moveSpeed = 2000.0f;
    public float maxDistance = 1.0f; 
    private Vector2 startingPosition;
    private float nextMoveTime = 0f;

    //collision stuff
    public float collisionOffset = 0.05f;
    Rigidbody2D bankTeller;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private void Start()
    {
        nextMoveTime = Time.time + 1.0f;
        startingPosition = transform.position; 
    }

    private void Update()
    {
        if (Time.time >= nextMoveTime)
        {
            Vector2 randomDirection = Vector2.zero; 

            if (Random.value < 0.5f)
            {
                randomDirection.x = Random.Range(-1f, 1f); 
            }
            else
            {
                randomDirection.y = Random.Range(-1f, 1f); 
            }

            Vector2 newPosition = (Vector2)transform.position + randomDirection.normalized * moveSpeed * Time.deltaTime;
            Vector2 clampedPosition = Vector2.ClampMagnitude(newPosition - startingPosition, maxDistance) + startingPosition;

            if(CheckForCollision(clampedPosition)) {
                transform.position = clampedPosition;
            }
            nextMoveTime = Time.time + 1.0f;
        }
    }

    private bool CheckForCollision(Vector2 vector)
    {
        int count = bankTeller.Cast(vector, movementFilter, castCollisions, Time.fixedDeltaTime + collisionOffset);
        Debug.DrawRay(vector, Vector2.up);
        return count == 0;
    }
}
