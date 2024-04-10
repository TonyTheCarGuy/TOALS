using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement
    public Rigidbody2D rb;
    public float moveSpeedRunning;
    public float moveSpeedWalking;
    public Vector2 forceToApply;
    public Vector2 PlayerInput;
    public float forceDamping;
    //dash
    private bool dash;
    private bool isDashing;
    private float dashingPower;
    private float dashingTime;
    private float dashingCld;
    public TrailRenderer tr;
    void Update()
    {
        PlayerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        if (Input.GetKeyDown(KeyCode.LeftAlt) == true && dash == true)
        {
            Dash();
        }
    }
    void Dash()
    {
        dash = false;
        rb.velocity = new Vector2();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) == true)
        {
            Vector2 moveForce = PlayerInput * moveSpeedRunning;
            moveForce += forceToApply;
            forceToApply /= forceDamping;
            if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
            {
                forceToApply = Vector2.zero;
            }
            rb.velocity = moveForce;
        }
        else
        {
            Vector2 moveForce = PlayerInput * moveSpeedWalking;
            moveForce += forceToApply;
            forceToApply /= forceDamping;
            if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
            {
                forceToApply = Vector2.zero;
            }
            rb.velocity = moveForce;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            forceToApply += new Vector2(-20, 0);
            Destroy(collision.gameObject);
        }
    }
    //public float speed;
    //public Rigidbody2D rb;
    //private Vector2 moveDirection;
    //void Update()
    //{
    //    //processing inputs
    //    ProcessInputs();
    //}
    //void FixedUpdate()
    //{
    //    //physics calculations
    //    Move();
    //}
    //void ProcessInputs()
    //{
    //    float moveX = Input.GetAxis("Horizontal");
    //    float moveY = Input.GetAxis("Vertical");
    //    moveDirection = new Vector2(moveX, moveY).normalized;
    //}
    //void Move()
    //{
    //    rb.velocity=new Vector2(moveDirection.x*speed, moveDirection.y*speed);
    //}
}
