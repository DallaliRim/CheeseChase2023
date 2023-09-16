using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class BeatGraphic
{
    private readonly GameObject _left;
    private readonly GameObject _right;

    private float _distance = 0;
    public float Distance
    {
        get => _distance;
        set
        {
            _distance = value;
            this._left.GetComponent<RectTransform>().localPosition = new Vector3(-_distance, 0, 0);
            this._right.GetComponent<RectTransform>().localPosition = new Vector3(_distance, 0, 0);
        }
    }

    public BeatGraphic(GameObject parent, Sprite sprite, float size)
    {
        this._left = CreateBeatImage(parent, sprite, size);
        this._right = CreateBeatImage(parent, sprite, size);
        Debug.Log("here");
    }

    private static GameObject CreateBeatImage(GameObject parent, Sprite sprite, float size)
    {
        GameObject beat = new GameObject("Beat");

        RectTransform transform = beat.AddComponent<RectTransform>();
        transform.transform.SetParent(parent.transform);
        transform.localScale = Vector3.one;
        transform.anchoredPosition = new Vector2(0f, 0f);
        transform.sizeDelta = new Vector2(size, size);

        Image image = beat.AddComponent<Image>();
        image.sprite = sprite;
        image.transform.parent.SetParent(parent.transform);

        return beat;
    }
}

public class BeatGraphicLineCreator : MonoBehaviour
{
    public Sprite sprite;

    private readonly List<BeatGraphic> _beatGraphics = new List<BeatGraphic>();

    private float Width => this.GetComponent<RectTransform>().sizeDelta.x;
    private float Height => this.GetComponent<RectTransform>().sizeDelta.y;

    private void Start()
    {
        for (int i = 0; i < BeatManager.Instance.SignatureTop; i++)
        {
            this._beatGraphics.Add(new BeatGraphic(this.gameObject, sprite, this.Height));
            //this._beatGraphics[i - 1].Distance = i * this.Width / 2 / BeatManager.Instance.SignatureTop;
        }
    }

    private void Update()
    {
        for (int i = 0; i < BeatManager.Instance.SignatureTop; i++)
        {
            int beat = i;

            float relativeBeat = BeatManager.Instance.Beat.beatPrecise - 1 - beat;
            if (relativeBeat < 0)
            {
                relativeBeat += BeatManager.Instance.SignatureTop;
            }

            this._beatGraphics[i].Distance = Mathf.Lerp(
                Width / 2,
                0,
                relativeBeat / BeatManager.Instance.SignatureTop
            );
        }
    }
}
