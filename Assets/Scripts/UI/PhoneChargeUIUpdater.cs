using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PhoneChargeUIUpdater : MonoBehaviour
{
    [Inject] private readonly PhoneCharge _phoneCharge;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        _phoneCharge.Changed += Update;
    }

    private void Update()
    {
        _slider.value = _phoneCharge.ChargeCurveTime;
    }

    private void OnDestroy()
    {
        _phoneCharge.Changed -= Update;
    }
}