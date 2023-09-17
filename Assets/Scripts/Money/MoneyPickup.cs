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
        if (other.CompareTag("bluePlayer"))
        {
            if (Manager_Money.moneyPlayerBlueOnHand <= Manager_Money.maxMoneyAmount)
            {
                bluePicksUp.Invoke();
                Destroy(gameObject);
            }
            else
            {
                // PopUp('blue');
                Debug.Log("Blue is carrying too much money");
            }
        }
        if (Manager_Money.moneyPlayerRedOnHand <= Manager_Money.maxMoneyAmount)
        {
            if (other.CompareTag("redPlayer"))
            {
                redPicksUp.Invoke();
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Red is carrying too much money");
            }
        }

    }
}

