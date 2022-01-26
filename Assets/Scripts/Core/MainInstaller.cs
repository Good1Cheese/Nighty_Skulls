using Zenject;

public class MainInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSceneSwitch();
    }

    private void BindSceneSwitch()
    {
        Container.BindInstance(GetComponent<SceneSwitch>())
            .AsSingle();
    }
}