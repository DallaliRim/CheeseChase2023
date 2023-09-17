using UnityEngine;
using UnityEngine.Events;

public class MoneyPickup : MonoBehaviour
{
    /// <summary>
    /// Collectible script. When a player collects with the money
    /// this checks which player collected it, using gameobject Tags,
    /// and whoever it was, that player gets the money.
    /// And the money sprite gets destroyed
    /// </summary>

    // calling function from moneymanagerscript 
    // depending on which player touches the money
    public UnityEvent bluePicksUp;
    public UnityEvent redPicksUp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bluePlayer") && Manager_Money.cheesePlayerBlueStatic == 0)
        {
            bluePicksUp.Invoke();
        }
        else if (other.CompareTag("redPlayer") && Manager_Money.cheesePlayerRedStatic == 0)
        {
            redPicksUp.Invoke();
        }
    }
}

