using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frigate_BLUE_Pathfinding : MonoBehaviour
{
    [SerializeField] private float speed, lookSpeed, lookMin, lookMax;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private string tagRef = null;


    [SerializeField] private int arrayStep = 0;

    private Transform tarRB;
    //made public so player can assign target
    public GameObject[] target;

    public Vector3 toFace;

    private void Awake()
    {
        lookSpeed = Random.Range(lookMin, lookMax);

        if (tagRef == null)
        {
            tagRef = "NavPointBLUE";
        }
        
        target = GameObject.FindGameObjectsWithTag(tagRef);


    }


    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
        toFace = target[arrayStep].transform.position;

        //face - .position is needed otherwise the missile wont turn, took ages
        Quaternion toRotation = Quaternion.LookRotation(toFace - transform.position);
        rb.MoveRotation(Quaternion.Lerp(transform.rotation, toRotation, lookSpeed * Time.deltaTime));
    }

    private void Update()
    {
        if (arrayStep >= target.Length)
        {
            arrayStep = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagRef)
        {
            arrayStep++;
        }
    }

}
