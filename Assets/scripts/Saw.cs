using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
  [SerializeField] float speed = 5f;

    void Update()
    {
    
        Vector2 movement = Vector2.right * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    float timeBetweenDmg = 0.01f;

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
