using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class testscript : MonoBehaviour
{
    // public Vector3 startRotation;

    int degreePerKlick = 90;
    float currentDegree = 0;

    float timeBetweenDmg = 0.005f;

    float dmgTimer = 0;

    void Start()
    {
        currentDegree = transform.localRotation.z;
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            currentDegree += degreePerKlick;
            if (currentDegree >= 360)
            {
                currentDegree -= 360;
            }
            transform.eulerAngles = Vector3.forward * currentDegree;
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other.gameObject.tag);

        dmgTimer += Time.deltaTime;

        if (other.TryGetComponent(out healthbar _healthmanager) && dmgTimer > timeBetweenDmg)
        {
            _healthmanager.TakeDamage(1);
            dmgTimer = 0;
        }
    }



}
