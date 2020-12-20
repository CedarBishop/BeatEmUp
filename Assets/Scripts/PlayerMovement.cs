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

    public void Move (Vector2 value)
    {
        movementDirection = new Vector3(value.x, 0, value.y).normalized * movementSpeed * Time.deltaTime;
        rigidbody.velocity = new Vector3(movementDirection.x, rigidbody.velocity.y, movementDirection.z);
    }

    public void Jump ()
    {
        if (CheckIsGrounded())
        {
            float jumpVelocity = Mathf.Sqrt(jumpHeight * -2 * Physics.gravity.y);
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, jumpVelocity, rigidbody.velocity.z);
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
