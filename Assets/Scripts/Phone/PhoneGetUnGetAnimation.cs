using System.Collections;
using UnityEngine;
using Zenject;

public class PhoneGetUnGetAnimation : CoroutineUser
{
    [SerializeField] private float _smoothing;
    [SerializeField] private Vector3 _targetPosition;

    [Inject] private readonly PhoneActivator _phoneActivator;

    private Vector3 _currentTargetPosition;
    private Vector3 _zero = Vector3.zero;

    private new void Start()
    {
        base.Start();

        _phoneActivator.Activated += Activate;
        _phoneActivator.Deactivated += Deactivate;
    }

    private void Awake()
    {
        _currentTargetPosition = _targetPosition;
    }

    private void Activate()
    {
        _currentTargetPosition = _targetPosition;
        StartCoroutineWithInterrupt();
    }

    private void Deactivate()
    {
        _currentTargetPosition = _zero;
        StartCoroutineWithInterrupt();
    }

    public override IEnumerator Coroutine()
    {
        while (transform.localPosition != _currentTargetPosition)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition,
                                                _currentTargetPosition,
                                                _smoothing * Time.deltaTime);
            yield return null;
        }
    }

    private void OnDestroy()
    {
        _phoneActivator.Activated -= Activate;
        _phoneActivator.Deactivated -= Deactivate;
    }
}