using UnityEngine;

public class BackRotate : MultipleCurveUser
{
    [SerializeField] private Transform _transformParent;

    private Quaternion _newRotation;

    protected override float CurrentCurveValue => _transform.eulerAngles.y - _transformParent.eulerAngles.y;

    protected override void DoAction(float curveTime)
    {
        _newRotation = Quaternion.Euler(0, _currentCurve.Evaluate(curveTime), 0);
        _transform.localRotation = _newRotation;
    }
}