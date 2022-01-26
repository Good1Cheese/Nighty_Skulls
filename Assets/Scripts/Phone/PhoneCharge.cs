using System;
using System.Collections;
using UnityEngine;

public class PhoneCharge : MonoBehaviour
{
    [SerializeField] private AnimationCurve _chargeCurve;

    private int _wasteSourceCount = 1;
    private float _chargeCurveTime;

    public float ChargeCurveTime
    {
        get => _chargeCurveTime;
        private set
        {
            _chargeCurveTime = value;
            _chargeCurve.Evaluate(ChargeCurveTime);
            Changed?.Invoke();
        }
    }

    public bool HasCharge { get; private set; } = true;
    public Action ChargeOut { get; set; }
    public Action Changed { get; set; }

    private void Awake()
    {
        ChargeCurveTime = _chargeCurve.keys[_chargeCurve.length - 1].time;
        StartCoroutine(UpdateCharge());
    }

    public void AddWasteSource() => _wasteSourceCount++;
    public void RemoveWasteSource() => _wasteSourceCount--;

    private IEnumerator UpdateCharge()
    {
        while (_chargeCurveTime > 0)
        {
            ChargeCurveTime -= Time.deltaTime * _wasteSourceCount;

            yield return null;
        }

        HasCharge = false;
        ChargeOut?.Invoke();
    }
}