using System.Collections;
using UnityEngine;

public abstract class MultipleCurveUser : CoroutineUser
{
    [SerializeField] protected Transform _transform;

    [SerializeField] private AnimationCurve _firstCurve;
    [SerializeField] private AnimationCurve _secondCurve;

    private float _targetCurveTime;
    protected AnimationCurve _currentCurve;
    private Keyframe _newStartKeyFrame;

    private bool _firstCurveUsed;

    private new void Start()
    {
        base.Start();
        _targetCurveTime = _firstCurve.GetLastKeyframe().time;
    }

    public override void StartCoroutineWithInterrupt()
    {
        _firstCurveUsed = !_firstCurveUsed;
        _currentCurve = _firstCurveUsed ? _firstCurve : _secondCurve;

        base.StartCoroutineWithInterrupt();
    }

    public override IEnumerator Coroutine()
    {
        SetFirstKeyFrameCurrentPositiion();
        float curveTime = 0;

        while (curveTime < _targetCurveTime)
        {
            curveTime += Time.deltaTime;
            DoAction(curveTime);

            yield return null;
        }
    }

    private void SetFirstKeyFrameCurrentPositiion()
    {
        _newStartKeyFrame.value = CurrentCurveValue;
        _currentCurve.MoveKey(0, _newStartKeyFrame);
    }

    protected abstract void DoAction(float curveTime);
    protected abstract float CurrentCurveValue { get; }
}