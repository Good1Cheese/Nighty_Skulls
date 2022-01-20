using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private AnimationCurve _rotationCurve;

    public AnimationCurve RotationCurve { get => _rotationCurve; }
    public float RotationTime { get; set; }

    public void Rotate(float rotateTime)
    {
        RotationTime = rotateTime;

        float y = _rotationCurve.Evaluate(RotationTime);
        transform.localRotation = Quaternion.Euler(0, y, 0);
    }
}