using System.Collections;
using UnityEngine;

public class LeftRotate : StaticCoroutineUser
{
    [SerializeField] private Rotator _rotator;

    private void Awake()
    {
        _targetTime = _rotator.RotateCurve.GetLastKeyframe().time;
    }

    public override IEnumerator Coroutine()
    {
        while (_rotator.CurveTime < _targetTime)
        {
            _rotator.CurveTime += Time.deltaTime;
            yield return null;
        }
    }
}