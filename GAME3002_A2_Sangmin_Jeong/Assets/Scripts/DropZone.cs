using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    BallManager bm;
    ScoreManager sm;
    AudioSource audioSource;

    private void Start()
    {
        bm = FindObjectOfType<BallManager>();
        sm = FindObjectOfType<ScoreManager>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            audioSource.PlayOneShot(audioSource.clip, 0.5f);
            bm.LostBall();
            sm.TakeLife();
        }
    }
}
