using UnityEngine;
using Zenject;

[RequireComponent(typeof(MarkAdditionTimer))]
public class MarkMovement : EnemyMovement
{
    [Inject] private readonly PhoneEnabler _phoneEnabler;

    private MarkAdditionTimer _markAdditionTimer;

    private new void Awake()
    {
        base.Awake();
        _markAdditionTimer = GetComponent<MarkAdditionTimer>();
        _markAdditionTimer.EnemyActionTimer = _enemyActionTimer;
    }

    public override void Scare()
    {
        if (!_phoneEnabler.IsEnabled) { return; }

        _enemyActionTimer.StopCoroutine();
        _markAdditionTimer.StartCoroutineWithInterrupt();
    }
}