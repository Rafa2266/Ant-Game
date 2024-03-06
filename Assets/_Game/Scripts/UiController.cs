using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JetBrains.Annotations;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text textScore, textHighScore, textFinalScore;
    public Image[] imgLifes;
    [SerializeField] private GameObject panelGame, panelPause,panelMainMenu,panelGameOver, allLifesParent;
    private GameController gameController;
    
    void Start()
    {
        Initialize();  
    }

    private void Initialize()
    {
        panelMainMenu.SetActive(true);
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
        panelGame.SetActive(false);
        gameController = FindObjectOfType<GameController>();
        textHighScore.text= "HighScore: "+gameController.highScore;
    }

     public void UpdateScore(int score)
    {
        textScore.text= score.ToString();
    }

    public void ButtonPause()
    {
        Time.timeScale = 0f;   
        panelGame.SetActive(false);
        panelPause.SetActive(true);
    }
    public void ButtonStart()
    {
        Time.timeScale = 1f;
        panelGame.SetActive(true);
        panelMainMenu.SetActive(false);
        gameController.StartGame();

    }
    public void ButtonExit()
    {
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
    }

    public void ButtonResume()
    {
        Time.timeScale = 1f;
        panelPause.SetActive(false);
        panelGame.SetActive(true);
    }

    public void ButtonRestart()
    {
        Time.timeScale = 1f;
        panelPause.SetActive(false);
        panelGame.SetActive(true);
        panelGameOver.SetActive(false);
        gameController.Restart();
        foreach (Transform child in allLifesParent.transform)
        {
            child.gameObject.SetActive(true);
        }

    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        panelGameOver.SetActive(true);
        panelGame.SetActive(false);
    }

    public void ButtonBackMainMenu()
    {
        Time.timeScale = 0f;
        panelMainMenu.SetActive(true);
        panelGame.SetActive(false);
        panelPause.SetActive(false);
        panelGameOver.SetActive(false);
        gameController.Restart();
        gameController.backVolume();
        foreach (Transform child in allLifesParent.transform)
        {
            child.gameObject.SetActive(true);
        }

    }
}
