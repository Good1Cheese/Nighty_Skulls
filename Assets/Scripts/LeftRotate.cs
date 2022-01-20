using UnityEngine;
using UnityEngine.EventSystems;

public class LeftRotate : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private Rotator _rotator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Started");
        _rotator.RotateLeft();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Stopped");
        _rotator.StopRotation();
    }
}