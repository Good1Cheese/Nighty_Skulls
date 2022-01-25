using UnityEngine;
using Zenject;

public class BackRotate : MultipleCurveUser
{
    [Inject] private readonly Rotator _rotator;

    private Quaternion _newRotation;
    private float _oldYRotation;
    private Keyframe _lastPointKeyFrame;

    protected override float CurrentCurveValue => _transform.eulerAngles.y;

    private new void Awake()
    {
        base.Awake();
        _lastPointKeyFrame.time = _secondCurve.GetLastKeyframe().time;
    }

    private new void Start()
    {
        base.Start();
        _rotator.Rotated += SaveCurrentY;
    }

    private void SaveCurrentY() => _oldYRotation = CurrentCurveValue;

    protected override void DoAction(float curveTime)
    {
        _newRotation = Quaternion.Euler(0, _currentCurve.Evaluate(curveTime), 0);
        _transform.localRotation = _newRotation;
    }

    protected override void SetFirstKeyFrameCurrentPositiion()
    {
        if (_firstCurveUsed)
        {
            base.SetFirstKeyFrameCurrentPositiion();
            return;
        }

        _lastPointKeyFrame.value = _oldYRotation;
        _currentCurve.MoveKey(_currentCurve.length - 1, _lastPointKeyFrame);
    }

    private void OnDestroy()
    {
        _rotator.Rotated -= SaveCurrentY;
    }
}