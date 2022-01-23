using UnityEngine;

public abstract class GameObjectActivator : MonoBehaviour
{
    [SerializeField] protected GameObject _activable;

    public virtual void Activate()
    {
        _activable.SetActive(true);
    }

    public virtual void Deactivate()
    {
        _activable.SetActive(false);
    }
}