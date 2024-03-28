using UnityEngine;

[System.Serializable]
public enum SIDE {Left,Mid,Right}
public class MoveOnRoad : MonoBehaviour
{
    [SerializeField] private SIDE m_Side = SIDE.Mid;
    [SerializeField] private bool SwipeLeft;
    [SerializeField] private bool SwipeRight;
    [SerializeField] private bool Forward;
    [SerializeField] private bool Backward;
    [SerializeField] private float XValue;
    [SerializeField] private float roatationSpeed;
    [SerializeField] private float speed = 6.0f;
    [SerializeField] private float gravity = 20.0f;
    [SerializeField] private float turnSmoothTime = 0.1F;
    private float turnSmoothVelocity;
    private float xx;
    private Animator animator;
    private Vector3 moveDirection = Vector3.zero;
    private float NewXPos = 0f;
    private CharacterController characterController;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float x = -(Input.GetAxisRaw("Vertical"));
        float z =Input.GetAxisRaw("Horizontal");
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

        if(moveDirection.magnitude >= 0.1f)
        {
            moveDirection = new Vector3(0.0f,0.0f,-Input.GetAxis("Vertical"));
            moveDirection *= speed;

            float targetAngle = Mathf.Atan2(0.0f,moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            
            characterController.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        SwipeLeft = Input.GetKeyDown(KeyCode.A);
        SwipeRight = Input.GetKeyDown(KeyCode.D);
        Forward = Input.GetKeyDown(KeyCode.W);
        Backward = Input.GetKeyDown(KeyCode.S);

        if(SwipeLeft)
        {
            if(m_Side == SIDE.Mid)
            {
                NewXPos = XValue;
                m_Side = SIDE.Left;
            }
            else if(m_Side == SIDE.Right)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
            }

            characterController.Move((NewXPos - transform.position.x)* Vector3.right);
        }
        else if(SwipeRight)
        {
            if(m_Side == SIDE.Mid)
            {
                NewXPos = -XValue;
                m_Side = SIDE.Right;
            }
            else if(m_Side == SIDE.Left)
            {
                NewXPos = 0;
                m_Side = SIDE.Mid;
            }

            characterController.Move((NewXPos - transform.position.x)* Vector3.right);
        }
        else if(Forward)
        {
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }
        else if(Backward)
        {
            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}
