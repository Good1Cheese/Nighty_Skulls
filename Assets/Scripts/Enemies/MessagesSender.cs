using UnityEngine;

public class MessagesSender : MonoBehaviour
{
    private EnemyActionTimer _debilActionTimeout;

    private void Awake()
    {
        _debilActionTimeout = GetComponent<EnemyActionTimer>();
    }

    private void Start()
    {
        _debilActionTimeout.TimeoutHasCome += SendMessage;
    }

    private void SendMessage()
    {
        print("Message");
    }

    private void OnDestroy()
    {
        _debilActionTimeout.TimeoutHasCome -= SendMessage;
    }
}