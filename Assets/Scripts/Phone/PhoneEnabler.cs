using System;

public class PhoneEnabler : PhoneFunctionEnabler
{
    public bool IsEnabled { get; private set; }
    public Action Enabled { get; set; }
    public Action Disabled { get; set; }

    protected override void Toggle(bool value)
    {
        IsEnabled = value;

        if (IsEnabled)
        {
            Enabled?.Invoke();
            return;
        }

        Disabled?.Invoke();
    }
}