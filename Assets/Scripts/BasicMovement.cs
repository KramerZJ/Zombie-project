using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 10f, gravity = -9.8f/2;

    private Vector3 velocity;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkLength = 0.1f;
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


    }
    private void FixedUpdate()
    {
        velocity.y += gravity * Time.deltaTime;
        if (isGround && velocity.y < 0)
        {
            velocity.y = -0.3f;
        }
        controller.Move(velocity);//fall
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundCheck.position, checkLength);
    }
}
