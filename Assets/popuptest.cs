using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popuptest : MonoBehaviour
{
    public GameObject popup;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            popup.SetActive(true);
        }
    }
}
