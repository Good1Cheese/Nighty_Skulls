using System.Collections;
using UnityEngine;
using Zenject;

public class ClockTime : CoroutineUser
{
    [SerializeField] private float _clockTime;

    [Inject] private readonly SceneSwitch _sceneSwitch;

    private WaitForSeconds _timeout;

    private void Awake()
    {
        _timeout = new WaitForSeconds(_clockTime);
        StartCoroutine();
    }

    public override IEnumerator Coroutine()
    {
        yield return _timeout;
        EndGame();
    }

    private void EndGame()
    {
        _sceneSwitch.SwitchScene(SceneSwitch.SceneId.GameEnd);
    }
}