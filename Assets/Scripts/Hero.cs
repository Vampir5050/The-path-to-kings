using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidbody;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        rigidbody.MovePosition(transform.position + movement * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            animator.SetInteger("State", 1);
        else
            animator.SetInteger("State", 0);

    }
}
