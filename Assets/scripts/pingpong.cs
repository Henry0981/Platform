using System.Collections;
using System.Collections.Generic;
using Microsoft.Cci;
using Unity.Mathematics;
using UnityEngine;

public class pingpong : MonoBehaviour
{


    [SerializeField] int speed = 5;

    float Xpostion = 36f;

    [SerializeField] float Ypostion = 0f;
    [SerializeField] bool yes;

    private Vector2 originalPosition;

    void Awake()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (yes)
        {
            transform.position = new Vector2(transform.position.x, originalPosition.y +  Mathf.PingPong(Time.time * speed, Ypostion));
        }
        if (!yes)
        {
            transform.position = new Vector2(originalPosition.x + Mathf.PingPong(Time.time * speed, Xpostion), transform.position.y);
        }


    }

    void OnDrawGizmos()
    {
        if (originalPosition.magnitude == 0)
        {
            Gizmos.DrawWireSphere(transform.position + Vector3.right * Xpostion, 0.2f);
        }
        else
        {
            Gizmos.DrawWireSphere(originalPosition + Vector2.right * Xpostion, 0.2f);
        }
    }
}
