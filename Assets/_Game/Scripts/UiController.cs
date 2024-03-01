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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void UpdateScore(int score)
    {
        textScore.text= score.ToString();
    }
}
