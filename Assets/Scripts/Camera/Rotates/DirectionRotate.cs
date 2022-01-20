using UnityEngine;
using UnityEngine.EventSystems;

public abstract class DirectionRotate : CoroutineUser, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] protected Rotator _rotator;

    protected float _maxRotateTime;

    public void OnPointerEnter(PointerEventData eventData) => StartCoroutine();

    public void OnPointerExit(PointerEventData eventData) => StopCoroutine();

    protected void SetMaxRotateTime(int rotatorCurveKeyFrameIndex)
    {
        _maxRotateTime = _rotator.RotationCurve.keys[rotatorCurveKeyFrameIndex].time;
    }
}