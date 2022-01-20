using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class Rotator : MonoBehaviour
{
    [SerializeField] private AnimationCurve _rotationCurve;

    [Inject] private readonly Transform _playerTransform;

    private float _leftCurveTimeLimit;
    private float _rightCurveTimeLimit;

    private sbyte _curveMultiplier;
    private Func<bool> _condition;
    private float _curveTime;
    private float _maxCurveTime;
    private IEnumerator _enumerator;

    private float CurveTime
    {
        get => _curveTime;
        set
        {
            _curveTime = value;
            _playerTransform.localRotation = Quaternion.Euler(0,
                                                              _rotationCurve.Evaluate(_curveTime),
                                                              0);
        }
    }

    private void Start()
    {
        _rightCurveTimeLimit = _rotationCurve.keys[0].time;
        _leftCurveTimeLimit = _rotationCurve.keys[_rotationCurve.length - 1].time;
    }

    public void RotateRight()
    {
        StartRotation(-1, () => _curveTime > _maxCurveTime, _rightCurveTimeLimit);
    }

    public void RotateLeft()
    {
        StartRotation(1, () => _curveTime < _maxCurveTime, _leftCurveTimeLimit);
    }

    public void StartRotation(sbyte curveMultiplier, Func<bool> func, float maxCurveTime)
    {
        _curveMultiplier = curveMultiplier;
        _maxCurveTime = maxCurveTime;
        _condition = func;

        _enumerator = RotateCoroutine();
        StartCoroutine(_enumerator);
    }

    public void StopRotation()
    {
        StopCoroutine(_enumerator);
    }

    private IEnumerator RotateCoroutine()
    {
        while (_condition())
        {
            CurveTime += Time.deltaTime * _curveMultiplier;
            yield return null;
        }
    }
}