using Zenject;

public class PhoneDisplayEnabler : GameObjectActivator
{
    [Inject] private readonly PhoneEnabler _phoneEnabler;

    private void Start()
    {
        _phoneEnabler.Enabled += Activate;
        _phoneEnabler.Disabled += Deactivate;
    }

    private void OnDestroy()
    {
        _phoneEnabler.Enabled -= Activate;
        _phoneEnabler.Disabled -= Deactivate;
    }
}