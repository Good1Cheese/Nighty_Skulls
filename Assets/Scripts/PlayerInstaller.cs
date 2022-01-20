using Zenject;  

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInstance(transform).AsSingle();
    }
}