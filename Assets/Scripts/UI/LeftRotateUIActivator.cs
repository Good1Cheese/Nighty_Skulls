using Zenject;

public class LeftRotateUIActivator : SideRotateUIActivator
{
    [Inject]
    void Construct(LeftRotate leftRotate)
    {
        _oneCoroutineUser = leftRotate;
    }
}