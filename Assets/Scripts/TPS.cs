using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPS : MonoBehaviour
{
    public Transform charterBody;
    public Transform cameraArm;
    public float speed;
    public float sensitivity;
    public GameManager Manager;

    float hAxis;
    float vAxis;
    float mouseX;
    float mouseY;

    bool wDown;
    bool jDown;
    bool fDown;

    bool isJump;
    bool isBorder;

    Vector3 moveVec;
    
    Animator anim;
    Rigidbody rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = charterBody.GetComponentInChildren<Animator>();
        rigid = charterBody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        LookAround();
        Move();
        Jump();
    }

    //Input 관리
    void GetInput()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
        fDown = Input.GetButton("Fire2");
    }

    //이동
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
            charterBody.forward = moveDir;
            if(!isBorder)
            {
                transform.position += moveDir * speed * (wDown?0.3f:1f) * Time.deltaTime;
            }

        }
    }

    //마우스 오른쪽 버튼을 눌렀을 때 카메라 회전할 수 있게하는 함수
    void LookAround()
    {
        if(!fDown)
        {
            return;
        }
        Vector2 mouseDelta = new Vector2(mouseX, mouseY);
        Vector3 camAngle = cameraArm.rotation.eulerAngles;
        float x = camAngle.x - mouseDelta.y*sensitivity;

        if(x <180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 361f);
        }

        cameraArm.rotation = Quaternion.Euler(x, camAngle.y + mouseDelta.x*sensitivity, camAngle.z);
    }

    //점프
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
        isBorder=Physics.Raycast(charterBody.position, charterBody.forward, 5, LayerMask.GetMask("Wall"));
    }

    //충돌로 인해 움직임이 발생시, 돌아가지 않도록 축을 잡아줌.
    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    //착지, 착지했을때 다시 점프할 수 있음.
    public void Land()
    {
        anim.SetBool("isJump", false);
        isJump =false;
    }
    
}
