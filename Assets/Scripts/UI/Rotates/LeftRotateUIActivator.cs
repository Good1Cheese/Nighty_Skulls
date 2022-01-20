using Zenject;

public class LeftRotateUIActivator : RotateUIActivator
{
    [Inject]
    void Construct(LeftRotate leftRotate)
    {
        _directionRotate = leftRotate;
    }
}