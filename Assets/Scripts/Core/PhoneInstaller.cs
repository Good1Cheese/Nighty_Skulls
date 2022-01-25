using Zenject;

public class PhoneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindPhoneActivator();
        BindPhoneCharge();
    }

    private void BindPhoneActivator()
    {
        Container.BindInstance(GetComponent<PhoneEnabler>())
            .AsSingle();
    }
    private void BindPhoneCharge()
    {
        Container.BindInstance(GetComponent<PhoneCharge>())
            .AsSingle();
    }
}