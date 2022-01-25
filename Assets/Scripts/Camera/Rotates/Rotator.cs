using System;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private AnimationCurve _rotateCurve;

    private float _curveTime;

    public AnimationCurve RotateCurve { get => _rotateCurve; }
    public Action Rotated { get; set; }

    public float CurveTime
    {
        get => _curveTime;
        set
        {
            _curveTime = value;
            float y = RotateCurve.Evaluate(_curveTime);
            transform.localRotation = Quaternion.Euler(0, y, 0);

            Rotated?.Invoke();
        }
    }
}