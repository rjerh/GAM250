using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    [SerializeField]
    private float speed,lookSpeed;
    [SerializeField]
    private Rigidbody rb;
    private Transform tarRB;
    //made public so player can assign target
    public Transform target;

    public Vector3 toFace;

    public float playerSpeed;
    public GameObject playerRef, expPrefab, particlePrefab;

    private void Awake()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");

        playerSpeed = playerRef.gameObject.GetComponent<PlayerController>().enginePower;

        Invoke("explode", 6);
    }



    private void FixedUpdate()
    {
        //add values in brackets so you only need to times once
        //you can't add things outside the brackets
        rb.velocity = transform.forward * (speed + playerSpeed);
        toFace = target.transform.position;

        //toFace - .position is needed otherwise the missile wont turn, took ages
        Quaternion toRotation = Quaternion.LookRotation(toFace - transform.position);
        rb.MoveRotation(Quaternion.Lerp(transform.rotation, toRotation, lookSpeed * Time.deltaTime));

    }

    private void OnCollisionEnter(Collision collision)
    {
        explode();
    }

    private void explode()
    {
        Destroy(gameObject);
        Instantiate(expPrefab, transform.position, Quaternion.identity);
        Instantiate(particlePrefab, transform.position, Quaternion.identity);

    }
}
