using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    [SerializeField] private float speed;
    [SerializeField] private float sprintMultiplier;
    [SerializeField] private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement() {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButton("Fire3")) 
        {
            rb.linearVelocity = new Vector2(horizontal * speed * sprintMultiplier, vertical * speed * sprintMultiplier);
        }
        else 
        {
            rb.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
        }
       
    }
}
