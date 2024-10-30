using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public CharacterController _controller;
    Animator animator;
    public float speedRotation = 180f;

    float moveSpeed = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_controller.isGrounded)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            float mx = Input.GetAxis("Mouse X");
            if (verticalInput !=0)
            {
                _controller.Move(transform.forward * verticalInput * 2 * Time.deltaTime);

            }
            if (mx != 0)
            {
                transform.Rotate(transform.up * mx * speedRotation * Time.deltaTime);
            }
        }
        _controller.Move(Physics.gravity * Time.deltaTime);
     

        if (Input.GetKey(KeyCode.W))
            animator.SetInteger("State", 1);
        else
            animator.SetInteger("State", 0);

    }

   
}