using System;
using System.Collections;
using UnityEngine;

public class PhoneCharge : MonoBehaviour
{
    [SerializeField] private AnimationCurve _chargeCurve;

    private float _chargeTime;
    private int _wasteSourceCount = 1;

    public bool HasCharge { get; set; } = true;
    public Action ChargeOut { get; set; }

    private void Start()
    {
        StartCoroutine(UpdateCharge());
    }

    public void AddWasteSource() => _wasteSourceCount++;
    public void RemoveWasteSource() => _wasteSourceCount--;

    private IEnumerator UpdateCharge()
    {
        float totalChargeTime = _chargeCurve.keys[_chargeCurve.length - 1].time;

        while (_chargeTime < totalChargeTime)
        {
            _chargeTime += Time.deltaTime * _wasteSourceCount;
            _chargeCurve.Evaluate(_chargeTime);

            yield return null;
        }

        HasCharge = false;
        ChargeOut?.Invoke();
    }
}