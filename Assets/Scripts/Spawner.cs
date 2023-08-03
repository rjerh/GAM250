using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject instance, playerRef;

    [SerializeField] private float timer;
    [SerializeField] private float cdMax, cdMin;

    // Start is called before the first frame update
    void Start()
    {

        timer = cdMax; 
    }


    private void Update()
    {
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, cdMin, cdMax);

        if (timer <= 0)
        {
            Instantiate(instance, transform.position, Quaternion.identity);
            timer = cdMax;

            //infinite spawn if this doesn't get disabled
            //maybe set up a bool for engine use?
            //this.enabled = false;
        }

        if(playerRef == null)
        {
            this.enabled = false;
        }
    }
}
