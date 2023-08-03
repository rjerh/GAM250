using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret_Health : MonoBehaviour
{
    [SerializeField] private string tagRefCol, tagRefTrig;
    [SerializeField] private float healthCurrent, healthMax, pulseHeal, shieldsCurrent, shieldsMax, shieldsChargeTimer;
    public GameObject tracker, tracker2, particlePrefab;
    private Image healthBar, shieldBar;

    [SerializeField] AudioSource AS;
    public AudioClip clip;

    private void Start()
    {

        if (tracker != null)
        {
            healthBar = tracker.gameObject.GetComponent<Image>();
        }
        if (tracker2 != null)
        {
            shieldBar = tracker2.gameObject.GetComponent<Image>();
        }
    }

    void Update()
    {
        shieldsCurrent = Mathf.Clamp(shieldsCurrent, 0, shieldsMax);

        if (tracker != null)
        {
            healthBar.fillAmount = Mathf.Clamp(healthCurrent / healthMax, 0, 1f);
        }
        if (tracker2 != null)
        {
            shieldBar.fillAmount = Mathf.Clamp(shieldsCurrent / shieldsMax, 0, 1f);
        }

        if (healthCurrent > healthMax)
        {
            healthCurrent = healthMax;
        }
        if (shieldsCurrent > shieldsMax)
        {
            shieldsCurrent = shieldsMax;
        }
        if (shieldsCurrent == shieldsMax)
        {
            shieldsChargeTimer = 5;
        }

        if (healthCurrent <= 0)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            Instantiate(particlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

            if (tracker != null)
            {
                tracker.SetActive(false);
            }
        }

        if (shieldsCurrent < shieldsMax)
        {
            shieldsChargeTimer -= Time.deltaTime;
            shieldsChargeTimer = Mathf.Clamp(shieldsChargeTimer, 0, 5);

            if (shieldsChargeTimer <= 0)
            {
                shieldsCurrent += 1.5f * Time.deltaTime;

            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == tagRefCol)
        {
            if(shieldsCurrent <= 0)
            {
                healthCurrent--;
            }
            else
            {
                shieldsCurrent -= 2;
            }

            shieldsChargeTimer = 5;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagRefTrig)
        {
            if (shieldsCurrent <= 0)
            {
                healthCurrent-=5;
            }
            else
            {
                shieldsCurrent -= 2;
            }

            shieldsChargeTimer = 5;
        }
    }

    public void healing()
    {
        healthCurrent += pulseHeal;
    }
}
