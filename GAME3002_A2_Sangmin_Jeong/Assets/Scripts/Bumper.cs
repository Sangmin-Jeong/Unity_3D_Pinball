using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private int point;
    AudioSource audioSource;
    ScoreManager sm;
    new Renderer renderer;
    Material material;
    Color oriColor;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sm = FindObjectOfType<ScoreManager>();
        renderer = GetComponent<Renderer>();
        material = renderer.material;
        oriColor = material.color;

        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball")
        {
            audioSource.PlayOneShot(audioSource.clip, 0.5f);
            sm.AddScore(point);
            material.SetColor("_EmissionColor", Color.yellow);
            StartCoroutine(ChangeColor());
        }
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(1.0f);
        material.SetColor("_EmissionColor", oriColor);
    }
}
