using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PhoneUIActivator : MonoBehaviour, IPointerEnterHandler
{
    [Inject] private readonly PhoneActivator _phoneActivator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _phoneActivator.Toggle();
    }
}