using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 10f, gravity = -9.8f,checkLength = 0.1f,jumpHeight =2f;

    private Vector3 velocity;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;
    bool isGround;
    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, checkLength, groundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move *speed* Time.deltaTime);//basic movement

        if (Input.GetButtonDown("Jump") && isGround)//jump
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

    }
    private void FixedUpdate()
    {

        if (isGround && velocity.y < 0)
        {
            velocity.y = -0.1f;
        }
        if (velocity.y>0)
        {
            velocity.y += gravity * Time.deltaTime / 2;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime/4;
        }
        
        controller.Move(velocity/2);//fall

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, checkLength);
    }
}
