using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairPulse : MonoBehaviour
{
    [SerializeField] private float pulseTimer = 3;

    public Turret_Health RED;

    public Collider capitalShip;
    public GameObject particlePulse;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pulseTimer -= Time.deltaTime;
        pulseTimer = Mathf.Clamp(pulseTimer, 0, 3);

    }

    public void OnTriggerStay(Collider other)
    {
        if (other == capitalShip && pulseTimer <= 0)
        {
            Debug.Log("the ship");
            RED.healing();
            Instantiate(particlePulse, transform.position, Quaternion.identity);
            pulseTimer = 3;
        }
    }
}
