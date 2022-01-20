using UnityEngine;

public class PhoneLightActivator : Activator
{
    [SerializeField] private KeyCode _key;

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            Activate();
        }   
    }

    private void LateUpdate()
    {
        if (Input.GetKeyUp(_key))
        {
            Deactivate();
        }
    }
}