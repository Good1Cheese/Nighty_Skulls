using UnityEngine;
using Zenject;

public class PhoneAnimation : MultipleCurveUser
{
    [Inject] protected readonly PhoneActivator _phoneActivator;

    private Vector3 _newPosition;

    protected override float CurrentCurveValue => _transform.localPosition.y;

    private void Awake()
    {
        _phoneActivator.Activated += StartCoroutineWithInterrupt;
        _phoneActivator.Deactivated += StartCoroutineWithInterrupt;
    }

    protected override void DoAction(float curveTime)
    {
        _newPosition.y = _currentCurve.Evaluate(curveTime);
        transform.localPosition = _newPosition;
    }
    
    public override void StartCoroutineWithInterrupt()
    {
        _phoneActivator.StopCoroutine(_enumerator);
        _enumerator = Coroutine();
        _phoneActivator.StartCoroutine(_enumerator);
    }

    private void OnDestroy()
    {
        _phoneActivator.Activated += StartCoroutineWithInterrupt;
        _phoneActivator.Deactivated += StartCoroutineWithInterrupt;
    }
}