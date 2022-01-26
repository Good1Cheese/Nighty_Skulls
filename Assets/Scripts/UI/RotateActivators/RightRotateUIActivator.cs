using Zenject;

public class RightRotateUIActivator : SideRotateUIActivator
{
    [Inject]
    void Construct(RightRotate rightRotate)
    {
        _oneCoroutineUser = rightRotate;
    }
}