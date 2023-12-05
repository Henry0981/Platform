using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jeffScript : MonoBehaviour
{

    [SerializeField] float speed;

    Rigidbody2D rigibody;

    bool hasReleasedJumpeButton = false;

    [SerializeField] Transform feet;

    [SerializeField] LayerMask groundlayer;
    [SerializeField] float groundRadius = 0.2f;

    [SerializeField] float jumpForce = 300;

    bool hasDoubleJumped = false;

    void Awake()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(xMovement, 0).normalized * speed * Time.fixedDeltaTime;
        transform.Translate(movement);

        bool isGrounded = Physics2D.OverlapCircle(feet.position, groundRadius, groundlayer);

        if (isGrounded)
        {
            hasDoubleJumped = false;
        }

        if (Input.GetAxisRaw("Jump") > 0 && hasReleasedJumpeButton == true && (isGrounded || !hasDoubleJumped))
        {
            if (!isGrounded)
            {
                hasDoubleJumped = true;
                print("double!");
                rigibody.velocity = new Vector2(rigibody.velocity.x, 0);
            }
            rigibody.AddForce(Vector2.up * jumpForce);
            hasReleasedJumpeButton = false;
        }

        if (Input.GetAxisRaw("Jump") == 0)
        {
            hasReleasedJumpeButton = true;
        }

        

    }

    private void OnDrawGizmos()
    {
        if (feet)
        {
            Gizmos.DrawWireSphere(feet.position, groundRadius);
        }
    }

 
         void OnTriggerEnter2D(Collider2D other)
        {

            Debug.Log(other.gameObject.tag);

            if (other.tag == "triangle")
            {
                SceneManager.LoadScene(2);  
            }

        }
    

    
}
