using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IScarable
{
    [SerializeField] private EnemyMove[] _enemyMoves;

    private EnemyActionTimer _enemyActionTimer;

    private void Awake()
    {
        _enemyActionTimer = GetComponent<EnemyActionTimer>();
    }

    private void Start()
    {
        _enemyActionTimer.TimeoutHasCome += Move;
    }

    private void Move()
    {
        EnemyMove nextMove = Array.Find(_enemyMoves, move => !move.IsDone);

        if (nextMove == null)
        {
            print("All moves done");
            return;
        }

        nextMove.IsDone = true;
        SetCurrentMove(nextMove);
    }

    public void Scare()
    {
        for (int i = 0; i < _enemyMoves.Length; i++)
        {
            _enemyMoves[i].IsDone = false;
        }

        SetCurrentMove(_enemyMoves[0]);
    }

    private void SetCurrentMove(EnemyMove nextMove)
    {
        transform.SetPositionAndRotation(nextMove.Position, nextMove.Rotation);
    }

    private void OnDestroy()
    {
        _enemyActionTimer.TimeoutHasCome -= Move;
    }
}