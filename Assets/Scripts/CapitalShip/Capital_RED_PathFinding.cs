using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capital_RED_PathFinding : MonoBehaviour
{
    [SerializeField] private float speed, lookSpeed;
    [SerializeField] private Rigidbody rb;

    //health system was migrated to turret_health script
    //[SerializeField] public float capitalHealth, HealthMax;

    [SerializeField]private int arrayStep = 0;

    private Transform tarRB;
    //made public so player can assign target
    public GameObject[] target;

    public Vector3 toFace;

    private void Start()
    {
        target = GameObject.FindGameObjectsWithTag("NavPoint");
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

/*        if (capitalHealth <= 0)
        {
            Destroy(gameObject);
        }

        if(capitalHealth > HealthMax)
        {
            capitalHealth = HealthMax;
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "NavPoint")
        {
            arrayStep++;
            Debug.Log("NavPoint");
        }
    }

/*    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "repairStation" && repairPulse == 0)
        {
            capitalHealth += 15;

            repairPulse = 3;
        }
    }*/


}
