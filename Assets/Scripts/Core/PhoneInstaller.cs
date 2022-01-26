using Zenject;

public class PhoneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindPhoneEnabler();
        BindPhoneCharge();
    }

    private void BindPhoneEnabler()
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