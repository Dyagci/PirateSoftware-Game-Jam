using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuSceneHandler : SceneHandler
{
    [SerializeField] private Button[] _levelButtons;
    private int _currentLevel;

    private void Start()
    {
        // Sets current unlockable level to 1
        _currentLevel = 1;
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel); 

        for(int i = 0; i < _levelButtons.Length; i++)
        {
            if (i + 1 > _currentLevel)
            {
                _levelButtons[i].interactable = false;
            }
        }
    }
}
