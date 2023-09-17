using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PathFinding : MonoBehaviour
{
    NavMeshAgent agent;
    private GameObject red;
    private GameObject blue;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.ResetPath();
        red = GameObject.FindGameObjectWithTag("redPlayer");
        blue = GameObject.FindGameObjectWithTag("bluePlayer");
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public void Move()
    {
        Vector2 target =
            Vector2.Distance(red.transform.position, transform.position) < Vector2.Distance(transform.position, blue.transform.position)
            ? red.transform.position
            : blue.transform.position;

        if (Vector2.Distance(transform.position, target) != 0)
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