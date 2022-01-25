using System;
using UnityEngine;

public class PhoneEnabler : MonoBehaviour
{
    public bool IsEnabled { get; private set; }
    public Action Enabled { get; set; }
    public Action Disabled { get; set; }

    public void Toggle()
    {
        IsEnabled = !IsEnabled;

        if (IsEnabled)
        {
            Enabled?.Invoke();
            return;
        }

        Disabled?.Invoke();
    }
}