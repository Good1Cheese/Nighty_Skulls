using System;
using UnityEngine;

[RequireComponent(typeof(EnemyActionTimer))]
public class EnemyMovement : MonoBehaviour, IStepBackable
{
    [SerializeField] protected EnemyMove[] _enemyMoves;

    protected EnemyActionTimer _enemyActionTimer;
    protected int _nextMoveIndex;

    protected void Awake()
    {
        _enemyActionTimer = GetComponent<EnemyActionTimer>();
    }

    private void Start()
    {
        _enemyActionTimer.TimeoutHasCome += Move;
    }

    protected virtual void Move()
    {
        _nextMoveIndex = Array.FindIndex(_enemyMoves, move => !move.IsDone);

        if (_nextMoveIndex == -1)
        {
            print("All moves done");
            return;
        }

        EnemyMove nextMove = _enemyMoves[_nextMoveIndex];
        nextMove.IsDone = true;
        SetCurrentMove(nextMove);
    }

    public virtual void Scare()
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