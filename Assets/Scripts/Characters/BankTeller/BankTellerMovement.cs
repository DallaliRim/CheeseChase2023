using UnityEngine;

public class BankTellerMovement : MonoBehaviour
{public float moveSpeed = 2000.0f;
    public float maxDistance = 1.0f; 

    private Vector2 startingPosition;
    private bool centered;

    private void Start()
    {
        startingPosition = transform.position; 
    }

    private void FixedUpdate()
    {
        if(centered)
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

            transform.position = clampedPosition;
            centered = false;
        } else {
            transform.position = startingPosition;
            centered = true;
        }
    }
}
