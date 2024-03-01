using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameController gameController;
    private UiController uiController;
    private void Start()
    {
        gameController= FindObjectOfType<GameController>();
        uiController = FindObjectOfType<UiController>();
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Enemy"))
        {
           
            if(gameController.enemyCount<5) 
            { 
             gameController.enemyCount++;  
             uiController.imgLifes[gameController.enemyCount-1].gameObject.SetActive(false);
             Debug.Log(target);
            }
            else
            {
                uiController.imgLifes[gameController.enemyCount - 1].gameObject.SetActive(false);
                Debug.Log("Game Over");
            }
           
            Destroy(target.gameObject);
        }
    }
}
