using UnityEngine;

public class charMove : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    [SerializeField] private float speed = 6.0f;
    // [SerializeField] private float roatationSpeed = 25;
    [SerializeField] private float jumpSpeed = 7.5f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float turnSmoothTime = 0.1F;
    private Vector3 inputVec;
    private Vector3 targetDirection;
    private Vector3 moveDirection = Vector3.zero;
    private float turnSmoothVelocity;

    void Start()
    {
        Time.timeScale = 1;
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = -(Input.GetAxisRaw("Vertical"));
        float z =Input.GetAxisRaw("Horizontal");
        inputVec = new Vector3(x,0,z).normalized;
        animator.SetFloat("Input X",z);
        animator.SetFloat("Input Z",-(x));
        if(x !=0 || z !=0)
        {
            animator.SetBool("Move",true);
            animator.SetBool("Run",true);
        } 
        else 
        {
            animator.SetBool("Move",false);
            animator.SetBool("Run",false);
        }

        if(characterController.isGrounded){
            moveDirection = new Vector3(-Input.GetAxis("Horizontal"),0.0f,-Input.GetAxis("Vertical"));
            moveDirection *= speed;
            if(Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                animator.SetBool("Jump",true);
            }
            else
            {
                animator.SetBool("Jump",false);
            }
        }
        
        if(moveDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            // characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
