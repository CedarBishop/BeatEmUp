using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpHeight;

    public Vector3 groundCheckPosition;
    public Vector3 groundCheckSize;
    public LayerMask groundLayer;

    private Rigidbody rigidbody;
    private Vector3 movementDirection;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move ()
    {
        movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * movementSpeed * Time.deltaTime;
        rigidbody.velocity = new Vector3(movementDirection.x, rigidbody.velocity.y, movementDirection.z);
    }

    void Jump ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (CheckIsGrounded())
            {
                float jumpVelocity = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y);
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpVelocity, rigidbody.velocity.z);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + groundCheckPosition, groundCheckSize);
    }

    private bool CheckIsGrounded ()
    {
        if (Physics.CheckBox(transform.position + groundCheckPosition, groundCheckSize, Quaternion.identity, groundLayer))
        {
            return true;
        }

        return false;
    }
}
