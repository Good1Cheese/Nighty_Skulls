using UnityEngine;

public class PositionIdleHeadbob : IdleHeadbob
{
    private Vector3 _newPosition = new Vector3();

    protected override void ActivateHeadbob()
    {
        _newPosition.x = HeadbobCurve.X.Curve.Evaluate(_time);
        _newPosition.y = HeadbobCurve.Y.Curve.Evaluate(_time);
        _newPosition.z = HeadbobCurve.Z.Curve.Evaluate(_time);

        transform.localPosition = _newPosition;
    }
}