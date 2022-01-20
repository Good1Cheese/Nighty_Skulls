using UnityEngine;
using UnityEngine.EventSystems;

public class RightRotate : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private Rotator _rotator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Started");
        _rotator.RotateRight();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Stopped");
        _rotator.StopRotation();
    }
}