using UnityEngine;

public class PhoneLightEnabler : PhoneFunctionEnabler
{
    [SerializeField] private KeyCode _key;
    [SerializeField] private GameObject _activable;

    public bool Enabled { get; private set; }

    private void Update()
    {
        if (!Input.GetKeyDown(_key)) { return; }

        Enable();
    }

    private void LateUpdate()
    {
        if (!Input.GetKeyUp(_key)) { return; }

        Disable();
    }

    protected override void Toggle(bool value)
    {
        Enabled = value;
        _activable.SetActive(Enabled);
    }
}