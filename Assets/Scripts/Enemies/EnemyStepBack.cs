using UnityEngine;

public class EnemyStepBack : MonoBehaviour
{
    [SerializeField] private float _radious;

    private Ray _ray;

    private void Update()
    {
        _ray.origin = transform.position;
        _ray.direction = transform.forward;

        if (!Physics.SphereCast(_ray, _radious, out RaycastHit hit)
            || !hit.collider.TryGetComponent(out IStepBackable scarable)) { return; }

        scarable.Scare();
    }
}