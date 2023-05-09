using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    private int score = 0;
    private int life = 3;
    private const int MAXSCORE = 999999;

    [SerializeField] private TMP_Text scoreText; 
    [SerializeField] private TMP_Text lifeText; 
    [SerializeField] private TMP_Text GOText;
    AudioSource audioSource;
   
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        scoreText.text = score.ToString();
        lifeText.text = life.ToString();

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        lifeText.text = life.ToString();

        if(life <= 0)
            GOText.gameObject.SetActive(true);
    }

    public void Reset()
    {
        score = 0; life = 3;
    }

    public void AddScore(int addscore)
    {
        if(MAXSCORE < score + addscore)
        {
            score = MAXSCORE;
        }
        else
        {
            score += addscore;
        }
        
    }

    public void MultiplyScore(int mulscore)
    {
        if(MAXSCORE < score * mulscore)
        {
            score = MAXSCORE;
        }
        else
        {
            score *= mulscore;
        }
        
    }

    public void TakeLife()
    {
        if(life > 0)
        life -= 1;
        

    }

    public bool CheckLife()
    {
        if(life > 0)
        {
            return true;
        }
        else
        {
            audioSource.Stop();
            return false;
        }
        
    }

}

