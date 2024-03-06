using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;

    [HideInInspector]public int totalScore;
    [HideInInspector] public int enemyCount;
    private UiController uiController;
    public Transform allEnemiesParent;
    private Spawner spawner;
    public int highScore;


    private void Awake()
    {
        uiController = FindObjectOfType<UiController>();
        spawner = FindObjectOfType<Spawner>();
        highScore = GetHighScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        totalScore= 0;
        enemyCount= 0;
        spawner.gameObject.GetComponent<Spawner>().enabled = false;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        totalScore= 0;
        enemyCount = 0;
        uiController.textScore.text=totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled = true;

    }
    public void Restart()
    {
        totalScore= 0;
        enemyCount= 0;
        uiController.textScore.text = totalScore.ToString();
        foreach(Transform child in allEnemiesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void SaveHighScore()
    {
        if (highScore < totalScore)
        {
            PlayerPrefs.SetInt("highscore", totalScore);
            uiController.textHighScore.text = "HighScore: "+totalScore.ToString();
        }
    }

    public int GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("highscore");
        return highScore;
    }
}
