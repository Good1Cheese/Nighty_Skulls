using System.Collections;
using UnityEngine;

public class RightRotate : StaticCoroutineUser
{
    [SerializeField] private Rotator _rotator;

    private void Awake()
    {
        _targetTime = _rotator.RotateCurve.keys[0].time;
    }

    public override IEnumerator Coroutine()
    {
        while (_rotator.CurveTime > _targetTime)
        {
            _rotator.CurveTime -= Time.deltaTime;
            yield return null;
        }
    }
}