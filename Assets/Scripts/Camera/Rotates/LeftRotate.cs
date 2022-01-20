using System.Collections;
using UnityEngine;

public class LeftRotate : DirectionRotate
{
    private new void Start()
    {
        base.Start();
        SetMaxRotateTime(_rotator.RotationCurve.length - 1);
    }

    public override IEnumerator Coroutine()
    {
        while (_rotator.RotationTime < _maxRotateTime)
        {
            _rotator.Rotate(_rotator.RotationTime + Time.deltaTime);
            yield return null;
        }
    }
}