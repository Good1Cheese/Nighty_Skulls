using UnityEngine;
using Zenject;

public abstract class PhoneFunctionEnabler : MonoBehaviour
{
    [Inject] private readonly PhoneCharge _phoneCharge;

    private void Start()
    {
        _phoneCharge.ChargeOut += Disable;
    }

    public void Enable()
    {
        if (!_phoneCharge.HasCharge) { return; }

        _phoneCharge.AddWasteSource();
        Toggle(true);
    }

    public void Disable()
    {
        if (!_phoneCharge.HasCharge) { return; }

        _phoneCharge.RemoveWasteSource();
        Toggle(false);
    }

    private void OnDestroy()
    {
        _phoneCharge.ChargeOut -= Disable;
    }

    protected abstract void Toggle(bool value);
}