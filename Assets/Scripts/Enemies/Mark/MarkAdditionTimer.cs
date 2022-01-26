using System.Collections;
using UnityEngine;

public class MarkAdditionTimer : CoroutineUser
{
    [SerializeField] private float _delay;

    private WaitForSeconds _timeout;

    public EnemyActionTimer EnemyActionTimer { get; set; }

    private void Awake()
    {
        _timeout = new WaitForSeconds(_delay);
    }

    public override IEnumerator Coroutine()
    {
        yield return _timeout;
        EnemyActionTimer.StartCoroutine();
    }
}