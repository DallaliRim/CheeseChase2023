using System;
using UnityEngine;
using UnityEngine.AI;
public class PathFinding : MonoBehaviour
{
    NavMeshAgent agent;
    private GridMovement red;
    private GridMovement blue;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.ResetPath();
        red = GameObject.FindGameObjectWithTag("redPlayer").GetComponent<GridMovement>();
        blue = GameObject.FindGameObjectWithTag("bluePlayer").GetComponent<GridMovement>();
    }
    void Start()
    {

    }

    void Update()
    {

    }

    public void Move()
    {

        var distanceRed = red.playerStatus == PlayerStatus.InGame ? Vector2.Distance(red.transform.position, transform.position) : float.PositiveInfinity;
        var distanceBlue = blue.playerStatus == PlayerStatus.InGame ? Vector2.Distance(blue.transform.position, transform.position) : float.PositiveInfinity;

        var target =
            distanceRed < distanceBlue
            ? red
            : blue;

        if (Vector2.Distance(transform.position, target.transform.position) != 0)
        {
            NavMeshPath newPath = new();
            agent.CalculatePath(target.transform.position, newPath);
            Vector2 relativeVector = newPath.corners[1] - newPath.corners[0];
            // Debug.Log(relativeVector.x);
            // Debug.Log(relativeVector.y);
            // Debug.Log(agent.nextPosition);
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
        else
        {
            target.playerStatus = PlayerStatus.InJail;
        }
    }
}