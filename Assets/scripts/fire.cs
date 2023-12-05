using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    // Start is called before the first frame update

    float timeBetweenDmg = 0.005f;

    float dmgTimer = 0;
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
