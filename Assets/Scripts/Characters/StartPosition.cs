using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    [Header("0.5, 0,5 is world center for pivot points that are at center.")]
    public Vector3 startPos = new Vector3(0.5f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
