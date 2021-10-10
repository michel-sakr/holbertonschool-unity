using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private CharacterController control;
    public GameObject mainCamera;
    private float moveHorizontal;
    private float moveVertical;
    private float speed;
    private float jumpSpeed;
    private float gravity;
    private Vector3 movement = Vector3.zero;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
        speed = 10f;
        jumpSpeed = 10f;
        gravity = 20f;
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = transform.position - mainCamera.transform.position;
        relativePos.Normalize();
        relativePos.y = 0;

        if (control.isGrounded)
        {
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Input.GetAxisRaw("Vertical");

            if (moveHorizontal != 0 || moveVertical != 0)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            movement = (moveHorizontal * mainCamera.transform.right) + (moveVertical * relativePos);
            movement = transform.TransformDirection(movement);
            movement.Normalize();
            movement *= speed;
            if (Input.GetButton("Jump"))
            {
                movement.y = jumpSpeed;
                animator.SetTrigger("isJumping");
            }
        }
        movement.y -= gravity * Time.deltaTime;

        control.Move(movement * Time.deltaTime);



        if (transform.position.y < -3)
        {
            animator.SetBool("isFalling", true);
        }

        if (transform.position.y < -21)
        {
            transform.position = new Vector3(0f, 30f, 0f);
            movement = Vector3.zero;
            animator.SetBool("isFalling", false);
        }
    }
}