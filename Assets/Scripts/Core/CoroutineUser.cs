using System.Collections;
using UnityEngine;

public abstract class CoroutineUser : MonoBehaviour
{
    private IEnumerator _enumerator;

    protected void Start()
    {
        _enumerator = Coroutine();
    }

    protected void StartCoroutineWithInterrupt()
    {
        StopCoroutine();
        StartCoroutine();
    }

    public void StartCoroutine()
    {
        _enumerator = Coroutine();
        StartCoroutine(_enumerator);
    }


    public void StopCoroutine()
    {
        StopCoroutine(_enumerator);
    }

    public abstract IEnumerator Coroutine();
}