using System.Collections;
using UnityEngine;

public class RightRotate : DirectionRotate
{
    private new void Start()
    {
        base.Start();
        SetMaxRotateTime(0);
    }

    public override IEnumerator Coroutine()
    {
        while (_rotator.RotationTime > _maxRotateTime)
        {
            _rotator.Rotate(_rotator.RotationTime - Time.deltaTime);
            yield return null;
        }
    }
}