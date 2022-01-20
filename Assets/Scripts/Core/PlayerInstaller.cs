using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindPhoneActivator();
        BindRotetes();
    }

    private void BindPhoneActivator()
    {
        var phoneActivator = GetComponent<PhoneActivator>();
        Container.BindInstance(phoneActivator)
            .AsSingle();
    }

    private void BindRotetes()
    {
        var rightRotate = GetComponent<RightRotate>();
        Container.BindInstance(rightRotate)
            .AsSingle();

        var leftRotate = GetComponent<LeftRotate>();
        Container.BindInstance(leftRotate)
            .AsSingle();
    }
}