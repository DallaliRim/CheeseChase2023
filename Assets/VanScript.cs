using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VanScript : MonoBehaviour
{
    public UnityEvent blueDropsOffMoney;
    public UnityEvent redDropsOffMoney;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bluePlayer"))
        {
            blueDropsOffMoney.Invoke();
        }
        if (other.CompareTag("redPlayer"))
        {
            redDropsOffMoney.Invoke();
        }

    }

}
