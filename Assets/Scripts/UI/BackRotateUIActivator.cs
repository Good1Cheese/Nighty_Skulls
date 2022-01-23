using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class BackRotateUIActivator : MonoBehaviour, IPointerEnterHandler
{
    [Inject] private readonly BackRotate _backwardsRotate;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _backwardsRotate.StartCoroutineWithInterrupt();
    }
}