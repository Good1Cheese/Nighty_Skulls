using UnityEngine;
using UnityEngine.EventSystems;

public abstract class SideRotateUIActivator : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    [SerializeField] private BackRotateUIActivator _backRotateUIActivator;

    protected StaticCoroutineUser _oneCoroutineUser;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_backRotateUIActivator.Activated) { return; }

        _oneCoroutineUser.StartCoroutineWithInterrupt();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _oneCoroutineUser.StopCoroutine();
    }
}