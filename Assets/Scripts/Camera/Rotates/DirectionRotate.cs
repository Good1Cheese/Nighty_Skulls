using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DirectionRotate : CoroutineUser
{
    [SerializeField] protected Rotator _rotator;

    protected float _maxRotateTime;

    protected void SetMaxRotateTime(int rotatorCurveKeyFrameIndex)
    {
        _maxRotateTime = _rotator.RotationCurve.keys[rotatorCurveKeyFrameIndex].time;
    }
}