using System;
using UnityEngine;

[Serializable]
public class EnemyMove
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;

    public bool IsDone { get; set; }
    public Vector3 Position { get => _position; }
    public Quaternion Rotation { get => _rotation; }
}