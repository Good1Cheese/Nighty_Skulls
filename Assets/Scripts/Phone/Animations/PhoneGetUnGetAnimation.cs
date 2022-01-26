using UnityEngine;
using Zenject;

public class PhoneGetUnGetAnimation : MultipleCurveUser
{
    [Inject] protected readonly PhoneEnabler _phoneEnabler;

    private Vector3 _newPosition;

    protected override float CurrentCurveValue => _transform.localPosition.y;

    private new void Start()
    {
        base.Start();
        _phoneEnabler.Enabled += StartCoroutineWithInterrupt;
        _phoneEnabler.Disabled += StartCoroutineWithInterrupt;
    }

    protected override void DoAction(float curveTime)
    {
        _newPosition.y = _currentCurve.Evaluate(curveTime);
        transform.localPosition = _newPosition;
    }

    private void OnDestroy()
    {
        _phoneEnabler.Enabled += StartCoroutineWithInterrupt;
        _phoneEnabler.Disabled += StartCoroutineWithInterrupt;
    }
}