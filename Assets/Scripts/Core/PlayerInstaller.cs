using Zenject;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindRotetes();
    }

    private void BindRotetes()
    {
        var rightRotate = GetComponent<RightRotate>();
        Container.BindInstance(rightRotate)
            .AsSingle();

        var leftRotate = GetComponent<LeftRotate>();
        Container.BindInstance(leftRotate)
            .AsSingle();

        var backRotate = GetComponent<BackRotate>();
        Container.BindInstance(backRotate)
            .AsSingle();
    }
}