using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public enum SceneId
    {
        Start, 
        Main,
        GameOver,
        GameEnd
    }

    public void SwitchScene(SceneId sceneId) => SceneManager.LoadScene((int)sceneId);
}