using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce = 5;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;
    bool jump;

    void Update()
    {
        CheckForInput();
    }

    void FixedUpdate()
    {
        CheckForGrounded();
        if (jump == true)
        {
            jump = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void CheckForInput()
    {
        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }
        }
    }

    void CheckForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        if (hit.collider != null)
        {
            if (hit.distance < 0.1f)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
            Debug.Log(hit.transform.name);
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);
        }
    }
}
