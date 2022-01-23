using System;
using Zenject;

public class PhoneDisplayActivator : GameObjectActivator
{
    [Inject] private readonly PhoneActivator _phoneActivator;

    private void Start()
    {
        _phoneActivator.Activated += Activate;
        _phoneActivator.Deactivated += Deactivate;
    }

    private void OnDestroy()
    {
        _phoneActivator.Activated -= Activate;
        _phoneActivator.Deactivated -= Deactivate;
    }
}