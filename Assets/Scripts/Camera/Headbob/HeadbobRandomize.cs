using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class HeadbobRandomize : CoroutineUser
{
    [SerializeField] private IdleHeadbob _idleHeadbob;
    [SerializeField] private float _randomizeDelay;

    private WaitForSeconds _randomizeTimeout;
    private RandomizableCurve[] _randomizableCurves;

    private void Awake()
    {
        _randomizeTimeout = new WaitForSeconds(_randomizeDelay);
        _randomizableCurves = new RandomizableCurve[]
        {
            _idleHeadbob.HeadbobCurve.X,
            _idleHeadbob.HeadbobCurve.Y,
            _idleHeadbob.HeadbobCurve.Z
        };

        Parallel.ForEach(_randomizableCurves, curve => curve.GetMinMaxTimeAndValue());
    }

    private new void Start()
    {
        StartCoroutine();
    }

    public override IEnumerator Coroutine()
    {
        yield return _randomizeTimeout;

        RandomizeCurves();
        StartCoroutine();
    }

    private void RandomizeCurves()
    {
        for (int i = 0; i < _randomizableCurves.Length; i++)
        {
            _randomizableCurves[i].Randomize();
        }
    }
}