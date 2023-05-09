using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{
    AudioSource audioSource;
    Rigidbody rb;
    private const float MAXZ = 5.3f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb= GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Pull back plunger to increase the power of spring
        if(Input.GetKey(KeyCode.DownArrow))
        {
            rb.isKinematic = true;
            if(transform.position.z < MAXZ)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (1.5f * Time.deltaTime));
        }

        // Release the plunger
        if(Input.GetKeyUp(KeyCode.DownArrow))
        {
            rb.isKinematic = false;
            audioSource.PlayOneShot(audioSource.clip, 0.5f);
        }
    }
}
