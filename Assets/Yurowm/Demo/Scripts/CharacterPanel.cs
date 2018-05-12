using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CharacterPanel : MonoBehaviour {

    public float walkspeed = 2;
    public float runspeed = 6;
    public float gravity = -12;
    public float jumpHeight = 1;
    public GameObject trons;
    [Range(0, 1)]
    public float airControlPerecent;

    float velocityY;
    Animator animator;
    CharacterController controller;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame 
    void Update()
    {

        Vector2 input = new Vector2(0f, Input.GetAxisRaw("Horizontal"));
        Vector2 inputDir = input.normalized;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (inputDir != Vector2.zero)
        {
            transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
        }
        bool runnig = Input.GetKey(KeyCode.LeftShift);

        float speed = ((runnig) ? runspeed : walkspeed) * inputDir.magnitude;
        velocityY += Time.deltaTime * gravity;
        Vector3 velocity = transform.forward * speed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);
        speed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;
        if (controller.isGrounded)
        {
            velocityY = 0;
        }
        float animationspeedPerecent = ((runnig) ? speed / runspeed : speed / walkspeed * .2f);
        animator.SetFloat("Blend", animationspeedPerecent);
        if (Input.GetKeyDown(KeyCode.Space))
        {


        }
    }
    void Jump()
    {
        bool jumping = Input.GetKey(KeyCode.Space);
        float animationspeedPerecent1 = ((jumping) ? jumpHeight / runspeed : jumpHeight / walkspeed * .2f);
        animator.SetFloat("Blend", animationspeedPerecent1);

        if (controller.isGrounded)
        {
            float jumpVelicity = Mathf.Sqrt(-6 * gravity * jumpHeight);
            velocityY = jumpVelicity;

        }
    }
    float GetModifiedSmoothTime(float smoothTime)
    {
        if (controller.isGrounded)
        {
            return smoothTime;
        }
        if (airControlPerecent == 0)
        {
            return float.MaxValue;
        }
        return smoothTime / airControlPerecent;
    }
}
