using System;
using UnityEngine;

[Serializable]
public class RandomizableCurve
{
    [SerializeField] private AnimationCurve _curve;

    private float _minTime;
    private float _maxTime;

    private float _minValue;
    private float _maxValue;

    private Keyframe _keyFrame = new Keyframe();

    public AnimationCurve Curve { get => _curve; }

    public void GetMinMaxTimeAndValue()
    {
        Keyframe firstKeyframe = _curve.keys[0];
        Keyframe lastKeyFrame = _curve.GetLastKeyframe();

        _minTime = firstKeyframe.time;
        _minValue = firstKeyframe.value;

        _maxTime = lastKeyFrame.time;
        _maxValue = lastKeyFrame.value;
    }

    public void Randomize()
    {
        for (int i = 1; i < _curve.length - 1; i++)
        {
            _keyFrame.time = UnityEngine.Random.Range(_minTime, _maxTime);
            _keyFrame.value = UnityEngine.Random.Range(_minValue, _maxValue);

            _curve.MoveKey(i, _keyFrame);
        }
    }
}