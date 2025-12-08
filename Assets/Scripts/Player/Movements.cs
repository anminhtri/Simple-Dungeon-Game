using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float turnDuration;
    public Transform cam;
    public Animator animator;
    public GameObject atkBox;
    public float cooldown = 1f;
    private float turnVelocity;
    private Vector3 velocity;
    private float gravity = -9.81f;
    private float lastAtkTime = 0f;

    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (LogicScript.isControl == true)
        {    if (controller.isGrounded && velocity.y < 0)
                velocity.y = -2f;
            
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float turnAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, turnAngle, ref turnVelocity, turnDuration);
                transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
                Vector3 camDir = Quaternion.Euler(0f, turnAngle, 0f) * Vector3.forward;
                controller.Move(camDir * speed * Time.deltaTime);
            }
            
            if (horizontal != 0 || vertical != 0)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }          
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time - lastAtkTime >= cooldown)
                {
                    animator.SetTrigger("Attack");
                    lastAtkTime = Time.time;
                    atkBox.SetActive(true);
                }
            }
            if (Time.time - lastAtkTime >= cooldown*0.1)
            {
                atkBox.SetActive(false);
            }
            if (Input.GetMouseButton(1))
            {
                animator.SetBool("isBlocking", true);
            }
            else
            {
                animator.SetBool("isBlocking", false);
            }
        }
    }
}
