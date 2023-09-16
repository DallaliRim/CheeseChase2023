using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float gridSize;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector2.up * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector2.down * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector2.right * gridSize);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector2.left * gridSize);
        }

    }
}
