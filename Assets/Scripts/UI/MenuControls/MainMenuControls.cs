using UnityEngine;
using Zenject;

public class MainMenuControls : MonoBehaviour
{
    [Inject] private readonly SceneSwitch _sceneSwitch;

    public void Play() => _sceneSwitch.SwitchScene(SceneSwitch.SceneId.Main);

    public void GoToMainMenu() => _sceneSwitch.SwitchScene(SceneSwitch.SceneId.Start);

    public void Exit() => Application.Quit();
}