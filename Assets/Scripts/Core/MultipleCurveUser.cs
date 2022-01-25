using System.Collections;
using UnityEngine;

public abstract class MultipleCurveUser : CoroutineUser
{
    [SerializeField] protected Transform _transform;

    [SerializeField] protected AnimationCurve _firstCurve;
    [SerializeField] protected AnimationCurve _secondCurve;

    private float _maxCurveTime;
    protected bool _firstCurveUsed;
    protected Keyframe _newStartKeyFrame;
    protected AnimationCurve _currentCurve;

    protected void Awake()
    {
        _maxCurveTime = _firstCurve.GetLastKeyframe().time;
    }

    public override void StartCoroutineWithInterrupt()
    {
        _firstCurveUsed = !_firstCurveUsed;
        _currentCurve = _firstCurveUsed ? _firstCurve : _secondCurve;
        SetFirstKeyFrameCurrentPositiion();

        base.StartCoroutineWithInterrupt();
    }

    public override IEnumerator Coroutine()
    {
        float curveTime = 0;

        while (curveTime < _maxCurveTime)
        {
            curveTime += Time.deltaTime;
            DoAction(curveTime);

            yield return null;
        }
    }

    protected virtual void SetFirstKeyFrameCurrentPositiion()
    {
        _newStartKeyFrame.value = CurrentCurveValue;
        _currentCurve.MoveKey(0, _newStartKeyFrame);
    }

    protected abstract void DoAction(float curveTime);
    protected abstract float CurrentCurveValue { get; }
}