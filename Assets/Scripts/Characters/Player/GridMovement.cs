using System;
using UnityEngine;
using UnityEngine.UIElements;

public enum PlayerColor
{
    Red,
    Blue,
}

public class GridMovement : MonoBehaviour
{
    public Manager_Money MoneyManager;
    public float GridSize = 1;

    public LayerMask LayerMask;
    public PlayerColor PlayerColor;

    public KeyCode keyU = KeyCode.W;
    public KeyCode keyD = KeyCode.S;
    public KeyCode keyL = KeyCode.A;
    public KeyCode keyR = KeyCode.D;

    public float PrecisionGood = 0.15f;
    public float PrecisionOk = 0.2f;

    void Start() { }

    void Update()
    {
        if (Input.GetKeyDown(this.keyU))
        {
            this.Move(Vector3.up);
        }
        else if (Input.GetKeyDown(this.keyD))
        {
            this.Move(Vector3.down);
        }
        else if (Input.GetKeyDown(this.keyL))
        {
            this.Move(Vector3.left);
        }
        else if (Input.GetKeyDown(this.keyR))
        {
            this.Move(Vector3.right);
        }
    }

    private void Move(Vector3 dir)
    {
        bool isOnBeat = BeatManager.Instance.IsOnBeat(this.PrecisionGood);
        Debug.Log(isOnBeat);

        if (!isOnBeat)
        {
            isOnBeat = BeatManager.Instance.IsOnBeat(this.PrecisionOk);
            this.SpillMoney(2000);
        }

        if (isOnBeat)
        {
            switch (TestHit(dir))
            {
                case "bankTeller":
                    this.SpillMoney(int.MaxValue);
                    break;
                default:
                    this.transform.Translate(dir * this.GridSize);
                    break;
            }
        }
        else
        {
            this.SpillMoney(4000);
        }
    }

    private string TestHit(Vector3 dir)
    {
        float length = 1f;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, length, ~LayerMask);

        Debug.DrawRay(transform.position, dir * length, Color.red);
        if (hit.collider != null)
        {
            return hit.collider.gameObject.tag;
        }
        else
        {
            return "";
        }
    }

    private void SpillMoney(int money)
    {
        switch (this.PlayerColor)
        {
            case PlayerColor.Red:
                this.MoneyManager.moneyPlayerRed -= money;
                break;
            case PlayerColor.Blue:
                this.MoneyManager.moneyPlayerBlue -= money;
                break;
        }
    }

}
