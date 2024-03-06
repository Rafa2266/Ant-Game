using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator myAnimator;
    private GameController gameController;
    private UiController uiController;
    [SerializeField] private GameObject[] sprites;
    [SerializeField] private int score;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        sprites[0]=this.transform.GetChild(0).gameObject;
        sprites[1]=this.transform.GetChild(1).gameObject;
        gameController=FindObjectOfType<GameController>();
        uiController=FindObjectOfType<UiController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AnimationSpeed();
    }
    private void AnimationSpeed()
    {
        myAnimator.SetFloat("Speed", speed);
    }
    private void Movement()
    {
        transform.Translate(Vector2.down * (speed * Time.deltaTime));
    }
    public void Dead()
    {
        speed= 0f;
        sprites[0].SetActive(false);
        sprites[1].SetActive(true);
        gameController.totalScore += score;
        uiController.UpdateScore(gameController.totalScore);
        Destroy(this.gameObject,Random.Range(2.5f,5f));
    }

    public void PlayAudio(bool isDead)
    {
        if(isDead) 
        {
            AudioSource audioSource= this.gameObject.GetComponent<AudioSource>();
            audioSource.clip = gameController.audioEnemies[Random.Range(0, gameController.audioEnemies.Length)];
            audioSource.Play();
        }
        
    }
}
