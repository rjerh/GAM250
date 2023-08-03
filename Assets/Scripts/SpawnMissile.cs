using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissile : MonoBehaviour
{
    public GameObject missile;
    private GameObject instance;
    private PlayerMissile pM;
    private PlayerController pC;
    [SerializeField] private Vector3 spawnPos, spawnOffset;
    [SerializeField] private float timer = 0;

    private void Awake()
    {
        pC = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnPos = transform.position;
        timer -= Time.deltaTime;
        timer = Mathf.Clamp(timer, 0, 3);

        //only fire if target is valid and timer is 0
        //checking if target is null means you can't free fire
        //undecided on freefire or lockon only
        if (Input.GetKeyUp(KeyCode.Space) && timer == 0 /*&& pC.target != null*/)
        {
            missSpawn();
        }
    }

    private void missSpawn()
    {
        instance = Instantiate(missile, spawnPos + spawnOffset, transform.rotation);
        pM = instance.GetComponent<PlayerMissile>();
        pM.target = pC.target;

        timer = 1.2f;
    }
}
