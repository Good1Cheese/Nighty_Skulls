using System;

public class PhoneAppEnabler : GameObjectActivator
{
    public bool IsEnabled { get; private set; }

    private void Awake()
    {
        base.Deactivate();
    }

    public override void Activate()
    {
        IsEnabled = true;
        base.Activate();
    }

    public override void Deactivate()
    {
        IsEnabled = false;
        base.Deactivate();
    }
}