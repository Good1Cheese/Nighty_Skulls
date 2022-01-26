using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class PhoneUIActivator : MonoBehaviour, IPointerEnterHandler
{
    [Inject] private readonly PhoneEnabler _phoneActivator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_phoneActivator.IsEnabled)
        {
            _phoneActivator.Disable();
            return;
        }
        _phoneActivator.Enable();
    }
}