using System.Collections;

public abstract class StaticCoroutineUser : CoroutineUser
{
    protected float _targetTime;

    private static new IEnumerator _enumerator;
}