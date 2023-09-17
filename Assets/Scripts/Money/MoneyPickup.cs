using UnityEngine;
using UnityEngine.Events;

public class MoneyPickup : MonoBehaviour
{
    public UnityEvent bluePicksUp;
    public UnityEvent redPicksUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bluePlayer") && Manager_Money.cheesePlayerBlueStatic <= 0)
        {
            bluePicksUp.Invoke();
        }
        else if (other.CompareTag("redPlayer") && Manager_Money.cheesePlayerRedStatic <= 0)
        {
            redPicksUp.Invoke();
        }
    }
}

