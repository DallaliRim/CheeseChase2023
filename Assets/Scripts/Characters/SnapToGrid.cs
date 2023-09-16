using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SnapToGrid : MonoBehaviour
{
    // add this script to anything that moves
    // everything that moves should snap to grid

    // only player shouldn't have this because they snap in their own script.

    [Header("Snap value. 1 = Snaps every 1 grid size.")]
    public int snap = 1;
    private Transform _transform;

    // Use this for initialization
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position = GetSharedSnapPosition(_transform.position, snap);
    }

    // Accepts a position, and sets each axis-value of the position to be snapped according to the value of snap
    public static Vector2 GetSharedSnapPosition(Vector2 originalPosition, int snap)
    {
        return new Vector2(GetSnapValue(originalPosition.x, snap), GetSnapValue(originalPosition.y, snap));
    }

    // Accepts a value, and snaps it according to the value of snap
    public static float GetSnapValue(float value, int snap)
    {
        return (!Mathf.Approximately(snap, 0f)) ? Mathf.RoundToInt(value / snap) * snap : value;
    }
}
