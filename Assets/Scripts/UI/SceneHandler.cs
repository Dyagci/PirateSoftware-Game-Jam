using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void LoadScene(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
