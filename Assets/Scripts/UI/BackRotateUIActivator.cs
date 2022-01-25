using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class BackRotateUIActivator : MonoBehaviour, IPointerEnterHandler
{
    [Inject] private readonly BackRotate _backRotate;

    public bool Activated { get; private set; }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Activated = !Activated;
        _backRotate.StartCoroutineWithInterrupt();
    }
}