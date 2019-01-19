using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Component references
    Rigidbody rb;

    public float hitPoints;

    public float h;
    //Container variable
    public float moveSpeed;
    //Two speeds dependent on if the input is being tilted to move slightly forward or 'smashed' to dash around
    public float tiltMoveSpeed, smashMoveSpeed;
    public float jumpForce;

    public bool facingRight = true;

    //https://www.youtube.com/watch?v=7KiK0Aqtmzc
    public float fallMultiplier;
    public float lowJumpMultiplier;

    public GameObject forwardHitbox;
    public GameObject upHitbox;

    public Text hitPointsText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hitPoints = 0.0f;
        UpdateHitPoints();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");

        //The player is moving if h isn't 0, so we set to a static velocity
        if (h != 0)
        {
            /*
            if(h <= 0.15f && h >= -0.15)
            {
                moveSpeed = tiltMoveSpeed;
            }

            if(h < -0.15 || h > 0.15)
            {
                moveSpeed = smashMoveSpeed;
            }
            */

            rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);
        }

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

        if(Input.GetButtonDown("Attack"))        
            forwardHitbox.SetActive(true);        
        else
            forwardHitbox.SetActive(false);

        if (Input.GetButtonDown("Attack2"))
            upHitbox.SetActive(true);
        else
            upHitbox.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        hitPoints += damage;
    }

    //Changes rotation of the player
    void Flip()
    {
        facingRight = !facingRight;
        Quaternion theScale = transform.localRotation;
        theScale.y *= -1;
        transform.localRotation = theScale;
    }

    void UpdateHitPoints()
    {
        hitPointsText.text = hitPoints.ToString() + "%";
    }
}
