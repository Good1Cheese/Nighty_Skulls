using System;
using UnityEngine;

[Serializable]
public class HeadbobCurve
{
    [SerializeField] private RandomizableCurve _x;
    [SerializeField] private RandomizableCurve _y;
    [SerializeField] private RandomizableCurve _z;

    public RandomizableCurve X { get => _x; }
    public RandomizableCurve Y { get => _y; }
    public RandomizableCurve Z { get => _z; }
}