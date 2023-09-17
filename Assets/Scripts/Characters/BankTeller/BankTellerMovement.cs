using UnityEngine;

public class BankTellerMovement : MonoBehaviour
{
    public float moveSpeed = 2000.0f;
    public float maxDistance = 1.0f;

    private Vector2 startingPosition;
    private bool centered;

    public Animator anim;

    private void Start()
    {
        startingPosition = transform.position;
    }

    public void Move()
    {
        if (centered)
        {
            Vector2 randomDirection = Vector2.zero;

            if (Random.value < 0.5f)
            {
                randomDirection.x = Random.Range(-1f, 1f);
                if (randomDirection.x > 0)
                {
                    anim.SetInteger("AnimInt", 4);
                }
                else
                {
                    anim.SetInteger("AnimInt", 3);
                }
            }
            else
            {
                randomDirection.y = Random.Range(-1f, 1f);
                if (randomDirection.y > 0)
                {
                    anim.SetInteger("AnimInt", 2);
                }
                else
                {
                    anim.SetInteger("AnimInt", 1);
                }
            }

            Vector2 newPosition = (Vector2)transform.position + randomDirection.normalized * moveSpeed * Time.deltaTime;
            Vector2 clampedPosition = Vector2.ClampMagnitude(newPosition - startingPosition, maxDistance) + startingPosition;

            transform.position = clampedPosition;
            centered = false;
        }
        else
        {
            transform.position = startingPosition;
            centered = true;
        }
    }
}
