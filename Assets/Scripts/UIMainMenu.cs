using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    public void OnStartGameClick()
    {
        GameManager.instance.StartGameplayMode();
    }

    public void OnCreditsClick()
    {
        GameManager.instance.StartCreditsMode();
    }

    public void OnSettingsClick()
    {
        GameManager.instance.StartSettingsMode();

    }

    public void OnQuitGameClick()
    {
        GameManager.instance.QuitGame();
    }

}
