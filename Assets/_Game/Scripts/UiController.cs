using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text textScore;
    public Image[] imgLifes;
    public GameObject panelGame, panelPause;
    void Start()
    {
        panelPause.SetActive(false);
        panelGame.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void ButtonResume()
    {
        Time.timeScale = 1f;
        panelPause.SetActive(false);
        panelGame.SetActive(true);

    }

    public void ButtonBackMainMenu()
    {
        Time.timeScale = 1f;
        panelGame.SetActive(false);
        panelPause.SetActive(false);
    }
}
