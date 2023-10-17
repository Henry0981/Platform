using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jeffScript : MonoBehaviour
{

    [SerializeField] float speed;

    Rigidbody2D rigibody;

    bool hasReleasedJumpeButton = false;

    [SerializeField] float jumpForce = 300;


    void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(xMovement, 0).normalized * speed * Time.fixedDeltaTime;
        transform.Translate(movement);

        if (Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpeButton == true)
        {
            rigibody.AddForce(Vector2.up * jumpForce);
            hasReleasedJumpeButton = false;
        }

        if (Input.GetAxisRaw("Jump") == 0)
        {
            hasReleasedJumpeButton = true;
        }


    }
}
