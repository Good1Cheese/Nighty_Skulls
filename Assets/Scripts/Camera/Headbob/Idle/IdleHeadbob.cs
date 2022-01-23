using UnityEngine;

public abstract class IdleHeadbob : MonoBehaviour
{
    [SerializeField] private HeadbobCurve _headbobCurve;

    protected float _time;

    public HeadbobCurve HeadbobCurve { get => _headbobCurve; }

    private void Update()
    {
        _time = Time.time;
        ActivateHeadbob();
    }

    protected abstract void ActivateHeadbob();
}