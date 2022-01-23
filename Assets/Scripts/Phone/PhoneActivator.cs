using System;
using UnityEngine;

public class PhoneActivator : MonoBehaviour
{
    public bool Active { get; private set; }

    public Action Activated { get; set; }
    public Action Deactivated { get; set; }

    public void Toggle()
    {
        Active = !Active;

        if (Active)
        {
            Activated?.Invoke();
            return;
        }

        Deactivated?.Invoke();
    }
}