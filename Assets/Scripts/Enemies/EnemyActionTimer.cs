using System;
using System.Collections;
using UnityEngine;

public class EnemyActionTimer : CoroutineUser
{
    [SerializeField] private float _maxMessageDelay;
    [SerializeField] private float _minMessageDelay;

    private float _delayTime;
    private float _randomDelay;

    public Action TimeoutHasCome { get; set; }

    private void Awake()
    {
        CreateNewDelay();
        StartCoroutine();
    }

    public override IEnumerator Coroutine()
    {
        while (_delayTime < _randomDelay)
        {
            _delayTime += Time.deltaTime;
            yield return null;
        }

        CreateNewDelay();
        TimeoutHasCome?.Invoke();
        StartCoroutine();
    }

    public new void StopCoroutine()
    {
        base.StopCoroutine();
        _enumerator = Coroutine();
    }

    private void CreateNewDelay()
    {
        _randomDelay = UnityEngine.Random.Range(_minMessageDelay, _maxMessageDelay);
        _delayTime = 0;
    }
}