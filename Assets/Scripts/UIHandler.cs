using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private TextMeshProUGUI timer;
    [SerializeField]
    private TextMeshProUGUI highscore;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private Slider musicSlider;
    [SerializeField]
    private Slider sfxSlider;
    [SerializeField]
    private GameObject musicButton;
    [SerializeField]
    private GameObject sfxButton;

    public void ToggleMusic()
    {
        AudioManager.instance.ToggleMusic();
        if(AudioManager.instance.musicSource.mute)
        {
            musicButton.GetComponent<Image>().sprite = musicButton.GetComponent<Button>().spriteState.pressedSprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicButton.GetComponent<Button>().spriteState.disabledSprite;
        }
    }

    public void ToggleSound()
    {
        AudioManager.instance.ToggleSFX();
        if (AudioManager.instance.sfxSource.mute)
        {
            sfxButton.GetComponent<Image>().sprite = sfxButton.GetComponent<Button>().spriteState.pressedSprite;
        }
        else
        {
            sfxButton.GetComponent<Image>().sprite = sfxButton.GetComponent<Button>().spriteState.disabledSprite;
        }
    }

    public void SFXVolume()
    {
        AudioManager.instance.SFXVolume(sfxSlider.value);
    }

    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(musicSlider.value);
    }

    private void Awake()
    {
        PlayerController.OnPlayerDeath += ShowGameOver;
        ShowHighScore();
    }

    private void ShowHighScore()
    {
        string score = "00:00";
        if (PlayerPrefs.HasKey("highscore"))
        {
            score = GetScoreString(PlayerPrefs.GetFloat("highscore"));
        }
        highscore.text = string.Format("High Score: {0}", score);
    }

    private string GetScoreString(float score)
    {
        int minutes = Mathf.FloorToInt(score);
        float seconds = score - minutes;
        return string.Format("{0}:{1}", minutes, System.Math.Round(seconds,2)*100);
    }

    private void Update()
    {
        timer.text = string.Format("Time: {0}:{1}",ScoreManager.Minutes, ScoreManager.Seconds);
    }

    private void ShowMessage()
    {
        startButton.gameObject.SetActive(true);
    }

    private void ShowGameOver(float score)
    {
        timer.gameObject.SetActive(false);
        startButton.GetComponentInChildren<TextMeshProUGUI>().text = "Try Again!";
        ShowHighScore();
        string currentScore = GetScoreString(score);
        highscore.text = string.Format("Current Score: {0} \n"+
            "{1}",currentScore,highscore.text);
        menu.SetActive(true);
    }
}
