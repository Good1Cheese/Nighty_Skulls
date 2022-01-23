using UnityEngine;

public class PhoneLight : PhoneChargeUser
{
    [SerializeField] private KeyCode _key;
    [SerializeField] private GameObject _activable;

    private void Update()
    {
        if (!Input.GetKeyDown(_key)) { return; }

        StartUse();
    }

    private void LateUpdate()
    {
        if (!Input.GetKeyUp(_key)) { return; }

        EndUse();
    }

    protected override void Activate()
    {
        _activable.SetActive(true);
    }

    protected override void Deactivate()
    {
        _activable.SetActive(false);
    }
}