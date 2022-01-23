using Zenject;

public class PhoneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindPhoneActivator();
        BindPhoneCharge();
    }

    private void BindPhoneCharge()
    {
        var phoneCharge = GetComponent<PhoneCharge>();
        Container.BindInstance(phoneCharge)
            .AsSingle();
    }

    private void BindPhoneActivator()
    {
        var phoneActivator = GetComponent<PhoneActivator>();
        Container.BindInstance(phoneActivator)
            .AsSingle();
    }
}