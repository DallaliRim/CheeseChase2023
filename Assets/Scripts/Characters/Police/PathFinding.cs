using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PathFinding : MonoBehaviour
{
    private Vector2 target;
    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.ResetPath();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetAgentPosition();
    }

    void Update()
    {
        SetTargetPosition();
    }

    void SetTargetPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target = new(Mathf.RoundToInt(target.x), Mathf.RoundToInt(target.y));
        }
    }

    void SetAgentPosition()
    {
        if ((Vector2)transform.position != target)
        {
            NavMeshPath newPath = new();
            agent.CalculatePath(target, newPath);
            Vector2 relativeVector = newPath.corners[1] - newPath.corners[0];
            Debug.Log(relativeVector.x);
            Debug.Log(relativeVector.y);
            Debug.Log(agent.nextPosition);
            int sign;
            if (Math.Abs(relativeVector.x) > Math.Abs(relativeVector.y))
            {
                sign = Math.Sign(relativeVector.x);
                // Debug.Log($"x: {transform.position.x} -> {transform.position.x + sign}");
                transform.position = new Vector3((int)transform.position.x + sign, transform.position.y, transform.position.z);
            }
            else
            {
                sign = Math.Sign(relativeVector.y);
                // Debug.Log($"y: {transform.position.y} -> {transform.position.y + sign}");
                transform.position = new Vector3(transform.position.x, (int)transform.position.y + sign, transform.position.z);
            }
        }
    }
}
