using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VaultScript : MonoBehaviour
{
    public UnityEvent RedEnters;
    public UnityEvent BlueEnters;

    public bool blueInVault;
    public bool redInVault;

    public void Update()
    {
        // calling event from MoneyManager.

        if (blueInVault)
        {
            RedEnters.Invoke();
        }
        if (redInVault)
        {
            BlueEnters.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bluePlayer"))
        {
            blueInVault = true;
            Debug.Log("Entered Vault.");

        }
        if (other.CompareTag("redPlayer"))
        {
            redInVault = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("bluePlayer"))
        {
            blueInVault = false;
            Debug.Log("exited Vault.");

        }
        if (other.CompareTag("redPlayer"))
        {
            redInVault = false;
        }
    }
}
