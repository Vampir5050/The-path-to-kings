using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.2f, walkCounter, waitCounter;
    [SerializeField] bool isWalking;
    
    Animator animator;
    Vector3 stopPosition;

    float walkTime;
    float waitTime;

    int WalkDirection;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        walkTime = Random.Range(5, 10);
        waitTime = Random.Range(5, 7);


        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

   
    void Update()
    {
        if (isWalking)
        {

            animator.SetBool("isWalk", true);

            walkCounter -= Time.deltaTime;

            switch (WalkDirection)
            {
                case 0:
                    transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 1:
                    transform.localRotation = Quaternion.Euler(0f, 90, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 2:
                    transform.localRotation = Quaternion.Euler(0f, -90, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
                case 3:
                    transform.localRotation = Quaternion.Euler(0f, 180, 0f);
                    transform.position += transform.forward * moveSpeed * Time.deltaTime;
                    break;
            }

            if (walkCounter <= 0)
            {
                stopPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                isWalking = false;
                //stop movement
                transform.position = stopPosition;
                animator.SetBool("isWalk", false);
                //reset the waitCounter
                waitCounter = waitTime;
            }


        }
        else
        {

            waitCounter -= Time.deltaTime;

            if (waitCounter <= 0)
            {
                ChooseDirection();
            }
        }
    }


    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);

        isWalking = true;
        walkCounter = walkTime;
    }
}
