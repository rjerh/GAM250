using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Shooting : MonoBehaviour
{
    [SerializeField]private Vector3 barrelREF;
    [SerializeField] private Transform barrelTrans;
    [SerializeField] private string tagRef, tagRef2;
    [SerializeField] private float cdMax, cdMin;
    public GameObject instance;
    [SerializeField]private float timer = 0;
    private RaycastHit hit;

    [SerializeField] AudioSource AS;
    private void Start()
    {
        
    }
    void Update()
    {
        barrelREF = barrelTrans.position;

        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, cdMax);

        // Does the ray intersect any objects, are they the player?
        //If so fire if off cooldown

    }

    private void missSpawn()
    {
        if (timer == 0 && (hit.transform.gameObject.tag == tagRef || hit.transform.gameObject.tag == tagRef2))
        {
            timer = Random.Range(cdMin, cdMax);

            AS.Play();

            Instantiate(instance, barrelREF, barrelTrans.rotation);
        }
    }

    private void FixedUpdate()
    {
        if(timer == 0)
        {
            if (Physics.SphereCast(barrelREF, .8f, barrelTrans.TransformDirection(Vector3.forward), out hit, 800))
            {
                missSpawn();
                //Debug.DrawRay(barrelREF, barrelTrans.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            }
        }

    }

    /*    private void OnTriggerStay(Collider other)
        {
            //only fire if timer is 0
            if (timer == 0 && other.gameObject.tag == "Player")
            {
                missSpawn();
            }
        }*/



    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
/*        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(hit.point, 1);*/
    }
}
