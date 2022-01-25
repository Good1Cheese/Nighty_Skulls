using System;
using System.Collections;
using UnityEngine;

public class EnemyActionTimer : CoroutineUser
{
    [SerializeField] private float _maxMessageDelay;
    [SerializeField] private float _minMessageDelay;

    public Action TimeoutHasCome { get; set; }

    private void Awake()
    {
        StartCoroutine();
    }

    public override IEnumerator Coroutine()
    {
        float randomDelay = UnityEngine.Random.Range(_minMessageDelay, _maxMessageDelay);

        yield return new WaitForSeconds(randomDelay);

        TimeoutHasCome?.Invoke();
        StartCoroutine();
    }
}