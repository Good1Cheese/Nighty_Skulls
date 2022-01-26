using UnityEngine;

public class RikiHider : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private RikiMovement _rikiMovement;

    public bool IsHide => _meshRenderer.enabled;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.enabled = false;

        _rikiMovement = GetComponent<RikiMovement>();
        _rikiMovement.MoveMade += Move;
    }


    protected void Move()
    {
        if (_rikiMovement.NextMoveIndex + 1 == _rikiMovement.EnemyMoves.Length)
        {
            _meshRenderer.enabled = true;
        }
    }

    private void OnDestroy()
    {
        _rikiMovement.MoveMade -= Move;
    }
}