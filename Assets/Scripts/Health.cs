using UnityEngine;
using Zenject;

public class Health : MonoBehaviour
{
    [Inject] private readonly SceneSwitch _sceneSwitch;

    public void Die()
    {
        _sceneSwitch.SwitchScene(SceneSwitch.SceneId.GameOver);
    }
}