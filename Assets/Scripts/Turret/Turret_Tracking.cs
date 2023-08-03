using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Tracking : MonoBehaviour
{
    public float speed = 3.0f;
    [SerializeField] private string tagRef, tagRef2;

    [SerializeField]GameObject targetTurret = null;
    //sets a rotation ref so I dont rotate the whole prefab, just the turret
    [SerializeField] Transform rotationPoint;
    Vector3 lastKnownPosition = Vector3.zero;
    Quaternion lookAtRotation;


    private void Start()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == tagRef || other.gameObject.tag == tagRef2)
        {
            targetTurret = (GameObject)other.gameObject;
            //Debug.Log("TargetFound");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (targetTurret != null)
        {
            targetTurret = null;
        }
    }

    void Update()
    {

        if (targetTurret != null)
        {
            

            if (lastKnownPosition != targetTurret.transform.position)
            {
                lastKnownPosition = targetTurret.transform.position;
                lookAtRotation = Quaternion.LookRotation(lastKnownPosition - transform.position);
            }

            if (rotationPoint.transform.rotation != lookAtRotation )
            {
                //Rotates whole reference object, cant seem to clamp value or stop it on the Z
                //Quaternion causes issues, will use alternate method next time
                rotationPoint.transform.rotation = Quaternion.Slerp(rotationPoint.rotation, lookAtRotation, speed * Time.deltaTime);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        targetTurret = target;
    }





}
