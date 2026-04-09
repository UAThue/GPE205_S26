using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class UISettings : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    public Slider mainVolumeSlider;
    public TMP_Text numberOfPlayersButtonText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnMainVolumeSliderChange();
    }

    public void OnPlayersButtonClick()
    {
        switch (GameManager.instance.numberOfPlayers)
        {
            case 1:
                GameManager.instance.numberOfPlayers = 2;
                SetPlayerButtonText();
                break;
            case 2:
                GameManager.instance.numberOfPlayers = 4;
                SetPlayerButtonText();
                break;
            case 4:
                GameManager.instance.numberOfPlayers = 1;
                SetPlayerButtonText();
                break;
            default:
                GameManager.instance.numberOfPlayers = 1;
                SetPlayerButtonText();
                break;
        }
    }

    public void SetPlayerButtonText()
    {
        numberOfPlayersButtonText.text = "" + GameManager.instance.numberOfPlayers;
    }

    public void OnMainVolumeSliderChange ()
    {
        // Start with the slider value (assuming our slider runs from 0 to 1)
        float newVolume = mainVolumeSlider.value;
        if (newVolume <= 0)
        {
            // If we are at zero, set our volume to the lowest value
            newVolume = -80;
        }
        else
        {
            // We are >0, so start by finding the log10 value 
            newVolume = Mathf.Log10(newVolume);
            // Make it in the 0-20db range (instead of 0-1 db)
            newVolume = newVolume * 20;
        }

        // Set the volume to the new volume setting
        mainAudioMixer.SetFloat("MainVolume", newVolume);
    }

    public void OnBackToMenuClick()
    {
        GameManager.instance.StartMainMenuMode();
    }
}
