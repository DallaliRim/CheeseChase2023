using UnityEngine;
using UnityEngine.Events;

public class VaultScript : MonoBehaviour
{

    // disable this script if we are going collectible instead

    public UnityEvent RedEnters;
    public UnityEvent BlueEnters;

    public bool blueInVault;
    public bool redInVault;

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
