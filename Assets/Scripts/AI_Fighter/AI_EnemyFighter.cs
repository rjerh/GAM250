using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_EnemyFighter : MonoBehaviour
{
    /// <summary>
    /// This is just the missile script but it doesnt self destroy on a timer
    /// pls dont just leave as is
    /// </summary>
    [SerializeField]
    private float speed, lookSpeed;
    [SerializeField]
    private Rigidbody rb;
    private Transform tarRB;
    //made public so player can assign target
    public Transform target;

    public Vector3 toFace;

    //public GameObject playerRef;

    private void Awake()
    {
        //playerRef = GameObject.FindGameObjectWithTag("Player");
    }


    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
        toFace = target.transform.position;

        //face - .position is needed otherwise the missile wont turn, took ages
        Quaternion toRotation = Quaternion.LookRotation(toFace - transform.position);
        rb.MoveRotation(Quaternion.Lerp(transform.rotation, toRotation, lookSpeed * Time.deltaTime));

    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
