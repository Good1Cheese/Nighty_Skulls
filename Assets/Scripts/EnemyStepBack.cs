using UnityEngine;

public class EnemyStepBack : MonoBehaviour
{
    [SerializeField] private float _radious;

    private void Update()
    {
        var ray = new Ray(transform.position, transform.forward);

        if (!Physics.SphereCast(ray, _radious, out RaycastHit hit)
            || !hit.collider.TryGetComponent(out IScarable scarable)) { return; }

        print(hit.collider);
        scarable.Scare();
    }
}