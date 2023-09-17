using UnityEngine;

public enum PlayerStatus
{
    InGame,
    Escaped,
    InJail
}

public class GridMovement : MonoBehaviour
{
    public PlayerStatus playerStatus = PlayerStatus.InGame;

    private const float PRECISION_GOOD = 0.15f;
    private const float PRECISION_OK = 0.2f;

    private const int SPILL_OK = 1;
    private const int SPILL_OUT_OF_BEAT = 2;

    public Manager_Money MoneyManager;
    public float GridSize = 1;

    public LayerMask LayerMask;

    public KeyCode keyU = KeyCode.W;
    public KeyCode keyD = KeyCode.S;
    public KeyCode keyL = KeyCode.A;
    public KeyCode keyR = KeyCode.D;
    public KeyCode keyUse = KeyCode.E;

    private bool _isInVan = false;

    void Start() { }

    void Update()
    {
        if (this.playerStatus != PlayerStatus.InGame) return;

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
        else if (Input.GetKeyDown(this.keyUse))
        {
            this.TryExitVan();
        }
    }

    private void TryExitVan()
    {
        if (!this._isInVan) return;
        if (BeatManager.Instance.Audio.time < 1) return;

        this.playerStatus = PlayerStatus.Escaped;
    }

    private void Move(Vector3 dir)
    {
        bool isOnBeat = BeatManager.Instance.IsOnBeat(PRECISION_GOOD);

        if (!isOnBeat)
        {
            isOnBeat = BeatManager.Instance.IsOnBeat(PRECISION_OK);
            this.SpillMoney(SPILL_OK);
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
            this.SpillMoney(SPILL_OUT_OF_BEAT);
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
        switch (this.gameObject.tag)
        {
            case "bluePlayer":
                this.MoneyManager.cheesePlayerBlue -= money;
                break;
            case "redPlayer":
                this.MoneyManager.cheesePlayerRed -= money;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("van"))
        {
            this._isInVan = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("van"))
        {
            this._isInVan = false;
        }
    }
}