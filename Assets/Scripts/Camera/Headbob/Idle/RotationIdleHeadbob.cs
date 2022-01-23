using UnityEngine;

public class RotationIdleHeadbob : IdleHeadbob
{
    protected override void ActivateHeadbob()
    {
        transform.localRotation = Quaternion.Euler(HeadbobCurve.X.Curve.Evaluate(_time),
                                                   HeadbobCurve.Y.Curve.Evaluate(_time),
                                                   HeadbobCurve.Z.Curve.Evaluate(_time));
    }
}