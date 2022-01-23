using System;
using UnityEngine;
using Zenject;

public class PhoneAppSwitch : MonoBehaviour
{
    [SerializeField] private KeyCode _key;
    [SerializeField] private PhoneAppActivator[] _apps;

    [Inject] private readonly PhoneActivator _phoneActivator;

    private int _activeAppIndex;

    private void Start()
    {
        gameObject.SetActive(false);
        _phoneActivator.Activated += ActivateCurrent;
        _phoneActivator.Deactivated += DeactivateCurrent;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(_key)) { return; }

        SwitchApp();
    }

    private void SwitchApp()
    {
        _activeAppIndex = Array.FindIndex(_apps, app => app.Active);
        _apps[_activeAppIndex].Deactivate();

        ActivateNextApp();
    }

    private void ActivateNextApp()
    {
        _activeAppIndex = Array.FindIndex(_apps,
                                          _activeAppIndex + 1,
                                          (app) => !app.Active);
        if (_activeAppIndex == -1)
        {
            _activeAppIndex = 0;
        }

        _apps[_activeAppIndex].Activate();
    }

    private void ActivateCurrent() => _apps[_activeAppIndex].Activate();
    private void DeactivateCurrent() => _apps[_activeAppIndex].Deactivate();

    private void OnDestroy()
    {
        _phoneActivator.Activated -= ActivateCurrent;
        _phoneActivator.Deactivated -= DeactivateCurrent;
    }
}