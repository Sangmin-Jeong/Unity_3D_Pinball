using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashToy : MonoBehaviour
{
    [SerializeField] private int point;
    AudioSource audioSource;
    ScoreManager sm;
    new Renderer renderer;
    Material material;
    CapsuleCollider CapsuleC;
    
    Color oriColor;
    private float oriY;
    private bool isTransforming = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        CapsuleC = GetComponent<CapsuleCollider>();
        sm = FindObjectOfType<ScoreManager>();
        renderer = GetComponent<Renderer>();
        material = renderer.material;
        oriColor = material.color;
        oriY = transform.position.y;

        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTransforming)
        {
            CapsuleC.enabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y - 1.0f * Time.deltaTime, transform.position.z);
        }
        else
        {
            if(transform.position.y < oriY)
            transform.position = new Vector3(transform.position.x, transform.position.y + 1.0f * Time.deltaTime, transform.position.z);
            else
            CapsuleC.enabled = true;
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball")
        {
            audioSource.PlayOneShot(audioSource.clip, 0.5f);
            sm.MultiplyScore(point);
            material.color = Color.red;
            isTransforming = true;
            StartCoroutine(ChangeColor());
        }
    }

    IEnumerator ChangeColor()
    {
        yield return new WaitForSeconds(2.0f);
        material.color = oriColor;
        isTransforming = false;
    }
}
