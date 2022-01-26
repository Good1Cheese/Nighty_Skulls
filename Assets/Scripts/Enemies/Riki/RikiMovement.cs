using System;

public class RikiMovement : EnemyMovement
{
    private RikiHider _rikiHider;

    public float NextMoveIndex => _nextMoveIndex;
    public EnemyMove[] EnemyMoves => _enemyMoves;
    public Action MoveMade { get; set; }

    private new void Awake()
    {
        base.Awake();
        _rikiHider = GetComponent<RikiHider>();
    }

    protected override void Move()
    {
        base.Move();
        MoveMade?.Invoke();     
    }

    public override void Scare()
    {
        if (!_rikiHider.IsHide) { return; }

        base.Scare();
    }
}