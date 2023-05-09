using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    ScoreManager sm;

    [SerializeField] GameObject ball;
    private Vector3 oriPOS;
    private Quaternion oriROT;
    private GameObject newBall = null;

    void Start()
    {
        sm = FindObjectOfType<ScoreManager>();
        oriPOS = ball.transform.position;
        oriROT = ball.transform.rotation;
    }

    void Update()
    {
        if(!sm.CheckLife() && ball != null)
        {
            Destroy(ball);
            ball = null;
        }
            
    }

    public void LostBall()
    {
        // Create new ball and Destoy old one
        if(sm.CheckLife())
        {
            newBall = Instantiate(ball, oriPOS, oriROT);
            newBall.name = ball.name;
        }
        Destroy(ball);
        ball = newBall;
    }

}
