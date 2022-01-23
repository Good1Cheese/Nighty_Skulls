using UnityEngine;
using Zenject;

public abstract class PhoneChargeUser : MonoBehaviour
{
    [Inject] private readonly PhoneCharge _phoneCharge;

    private void Start()
    {
        _phoneCharge.ChargeOut += Deactivate;    
    }

    public void StartUse()
    {
        if (!_phoneCharge.HasCharge) { return; }

        _phoneCharge.AddWasteSource();
        Activate();
    }

    public void EndUse()
    {
        if (!_phoneCharge.HasCharge) { return; }

        _phoneCharge.RemoveWasteSource();
        Deactivate();
    }

    private void OnDestroy()
    {
        _phoneCharge.ChargeOut -= Deactivate;
    }

    protected abstract void Deactivate();
    protected abstract void Activate();
}