using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform cameraArm;
    public Transform cam;

    public float speed = 12f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public GameManager Manager;

    float hAxis;
    float vAxis;

    bool jDown;
    bool wDown;

    bool isJump;
    bool isBorder;

    Vector3 moveVec;
    
    Animator anim;
    Rigidbody rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponentInChildren<Animator>();
        rigid = transform.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Jump();
    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
    }

    void Move()
    {
        if(Manager.isInfo)
        {
            anim.SetBool("isRun", false);
            anim.SetBool("isWalk", false);
            return;
        }
        moveVec = new Vector2(hAxis, vAxis);
        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
        if(moveVec != Vector3.zero)
        {
            Vector3 lookForward = new Vector3(cameraArm.forward.x, 0f, cameraArm.forward.z).normalized;
            Vector3 lookRight = new Vector3(cameraArm.right.x, 0f, cameraArm.right.z).normalized;
            Vector3 moveDir = lookForward*moveVec.y + lookRight*moveVec.x;

            //charterBody.forward = lookForward;
            transform.forward = moveDir;
            if(!isBorder)
            {
                transform.position += moveDir * speed * (wDown?0.3f:1f) * Time.deltaTime;
            }

        }
        // if(Manager.isInfo)
        // {
        //     anim.SetBool("isRun", false);
        //     anim.SetBool("isWalk", false);
        //     return;
        // }
        // moveVec = new Vector2(hAxis, vAxis).normalized;
        // anim.SetBool("isRun", moveVec != Vector3.zero);
        // anim.SetBool("isWalk", wDown);

        // if(moveVec.magnitude >= 0.1f)
        // {
        //     float targetAngle =Mathf.Atan2(moveVec.x, moveVec.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //     float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //     transform.rotation = Quaternion.Euler(0f, angle, 0f);

        //     Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        //     if(!isBorder)
        //     {
        //         controller.Move(moveDir.normalized * speed *(wDown?0.3f:1f) * Time.deltaTime);
        //     }
        // }
    }

    void Jump()
    {
        if(jDown && !isJump && !Manager.isInfo)
        {
            rigid.AddForce(Vector3.up * 10, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;
        }
    }

    void FixedUpdate() {
        StopToWall();
        FreezeRotation();
    }

    //벽이 앞에 있으면 앞으로 더 이동할 수 없게함
    void StopToWall()
    {
        isBorder=Physics.Raycast(transform.position, transform.forward, 5, LayerMask.GetMask("Wall"));
    }

    //충돌로 인해 움직임이 발생시, 돌아가지 않도록 축을 잡아줌.
    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag == "Floor")
        {
           anim.SetBool("isJump", false);
            isJump =false; 
        }
    }
}

