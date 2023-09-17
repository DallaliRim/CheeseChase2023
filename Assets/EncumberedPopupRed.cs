using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncumberedPopupRed : MonoBehaviour
{
    public GameObject popup;
    private void Awake()
    {
        popup.SetActive(false);
    }

    private void Update()
    {
        popup.SetActive(Manager_Money.cheesePlayerRedStatic > 0);
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
