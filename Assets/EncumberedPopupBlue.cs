using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncumberedPopupBlue : MonoBehaviour
{
    public GameObject popup;
    private void Awake()
    {
        popup.SetActive(false);
    }

    private void Update()
    {
        if (Manager_Money.moneyPlayerBlueOnHand >= Manager_Money.maxMoneyAmount)
        {
            popup.SetActive(true);
        }
        else
        {
            popup.SetActive(false);
        }
    }

    public void EncumberedWarningPopup()
    {

        popup.SetActive(true);
    }

    public void EncumberedWarningPopdown()
    {
        popup.SetActive(false);
    }
}
