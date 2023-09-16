using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float gridSize;
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    Vector2 movementInput;
    Rigidbody2D playerBody;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero)
        {
            int count = playerBody.Cast(movementInput, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);
            if(count == 0)
            {
                playerBody.MovePosition(playerBody.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }
        }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }
}
