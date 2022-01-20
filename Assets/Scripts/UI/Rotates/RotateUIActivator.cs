using UnityEngine;
using UnityEngine.EventSystems;

public abstract class RotateUIActivator : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    protected DirectionRotate _directionRotate;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _directionRotate.StartCoroutine();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _directionRotate.StopCoroutine();
    }
}