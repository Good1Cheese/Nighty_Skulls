using System;
using UnityEngine;
using Zenject;

public class PhoneAppSwitch : MonoBehaviour
{
    [SerializeField] private KeyCode _key;
    [SerializeField] private PhoneAppEnabler[] _appEnablers;

    [Inject] private readonly PhoneEnabler _phoneEnabler;

    private int _activeAppIndex;

    private void Start()
    {
        _phoneEnabler.Enabled += ActivateCurrent;
        _phoneEnabler.Disabled += DeactivateCurrent;
    }

    private void Update()
    {
        if (!Input.GetKeyDown(_key)) { return; }

        SwitchApp();
    }

    private void SwitchApp()
    {
        _activeAppIndex = Array.FindIndex(_appEnablers, app => app.IsEnabled);
        _appEnablers[_activeAppIndex].Deactivate();

        ActivateNextApp();
    }

    private void ActivateNextApp()
    {
        _activeAppIndex = Array.FindIndex(_appEnablers,
                                          _activeAppIndex + 1,
                                          (app) => !app.IsEnabled);
        if (_activeAppIndex == -1)
        {
            _activeAppIndex = 0;
        }

        _appEnablers[_activeAppIndex].Activate();
    }

    private void ActivateCurrent()
    {
        _appEnablers[_activeAppIndex].Activate();
    }

    private void DeactivateCurrent()
    {
        _appEnablers[_activeAppIndex].Deactivate();
    }

    private void OnDestroy()
    {
        _phoneEnabler.Enabled -= ActivateCurrent;
        _phoneEnabler.Disabled -= DeactivateCurrent;
    }
}