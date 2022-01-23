using UnityEngine;

[RequireComponent(typeof(PhoneAppFunction))]
public class PhoneAppActivator : GameObjectActivator
{
    private PhoneAppFunction _phoneAppFunction;

    public bool Active { get; set; }

    private void Awake()
    {
        _phoneAppFunction = GetComponent<PhoneAppFunction>();
        base.Deactivate();
    }

    public override void Activate()
    {
        Active = true;
        base.Activate();
        _phoneAppFunction.StartUse();
    }

    public override void Deactivate()
    {
        Active = false;
        base.Deactivate();
        _phoneAppFunction.EndUse();
    }
}