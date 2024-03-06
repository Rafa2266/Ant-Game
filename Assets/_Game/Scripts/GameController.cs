using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioClip[] audioEnemies;

    [HideInInspector]public int totalScore, highScore, enemyCount;
    private UiController uiController;
    public Transform allEnemiesParent;
    private Spawner spawner;
    [SerializeField]private AudioSource music;


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
        music.volume = 0.3f;
        
        
    }

    public void DestroyEnemy(Collider2D target)
    {
        enemyCount++;
        if (enemyCount < 5)
        {
            uiController.imgLifes[enemyCount - 1].gameObject.SetActive(false);
        }
        else
        {
            uiController.imgLifes[enemyCount - 1].gameObject.SetActive(false);
            SaveHighScore();
            uiController.textFinalScore.text = "Score: " + totalScore;
            uiController.GameOver();
        }

        Destroy(target.gameObject);
    }
    public void backVolume()
    {
        music.volume = 0.3f;
    }

    public void StartGame()
    {
        totalScore= 0;
        enemyCount = 0;
        uiController.textScore.text=totalScore.ToString();
        spawner.gameObject.GetComponent<Spawner>().enabled = true;
        music.volume = 0.1f;

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
