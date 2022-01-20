using Zenject;

public class RightRotateUIActivator : RotateUIActivator
{
    [Inject]
    void Construct(RightRotate rightRotate)
    {
        _directionRotate = rightRotate;
    }
}