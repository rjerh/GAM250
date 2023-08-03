using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField]private float speed = 5;
    public GameObject particlePrefab;

    public AudioSource boom;
    public AudioClip clip;
    [SerializeField] private float volume = 0.25f;

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
    }

    private void Awake()
    {
        boom.PlayOneShot(clip, volume);
        Destroy(gameObject, 3);

    }

    /*    private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }*/

    private void OnCollisionEnter(Collision collision)
    {
        explode();
    }

    private void explode()
    {
        Destroy(gameObject);

        Instantiate(particlePrefab, transform.position, Quaternion.identity);

    }
}
