using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    public float h, moveSpeed;
    public float jumpForce;

    public bool facingRight = true;

    //https://www.youtube.com/watch?v=7KiK0Aqtmzc
    public float fallMultiplier;
    public float lowJumpMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");

        //The player is moving if h isn't 0, so we set to a static velocity
        if (h != 0)
            rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }

        //jump code comes from the following video https://www.youtube.com/watch?v=7KiK0Aqtmzc
        //allows player to fall faster
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        //Flips when hitting 'right' and facing left
        if (h > 0 && !facingRight)
            Flip();
        //Flips when hitting 'left' and facing right
        else if (h < 0 && facingRight)
            Flip();
    }

    //Changes rotation of the player
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
