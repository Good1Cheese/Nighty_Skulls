using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private GameObject _activable;

    protected void Activate()
    {
        _activable.SetActive(true);
    }

    protected void Deactivate()
    {
        _activable.SetActive(false);
    }
}