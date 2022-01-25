using UnityEngine;

public class PhoneApp : MonoBehaviour
{
    protected PhoneAppEnabler _phoneAppEnabler;

    private void Awake()
    {
        _phoneAppEnabler = GetComponent<PhoneAppEnabler>();
    }
}