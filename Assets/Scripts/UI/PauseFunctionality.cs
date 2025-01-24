using UnityEngine;
using UnityEngine.InputSystem;

public class PauseFunctionality : MonoBehaviour
{
    [SerializeField] private string _gameplayActionMapName = "Player";
    [SerializeField] private string _pauseActionMapName = "UI";

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void SwitchActionMap(string mapName)
    {
        PlayerInput playerInput = FindFirstObjectByType<PlayerInput>();
        if (playerInput != null)
        {
            playerInput.SwitchCurrentActionMap(mapName);
        }
    }

    private void Start()
    {
        SetTimeScale(1.0f);
    }

    public void Pause()
    {
        SetTimeScale(0f);
        SwitchActionMap(_pauseActionMapName);
    }

    public void Unpause()
    {
        SetTimeScale(1f);
        SwitchActionMap(_gameplayActionMapName);
    }
}
