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

    void Move()
    {
        if(Manager.isInfo)
        {
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

    void StopToWall()
    {
        isBorder=Physics.Raycast(charterBody.position, charterBody.forward, 5, LayerMask.GetMask("Wall"));
    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }

    public void Land()
    {
        anim.SetBool("isJump", false);
        isJump =false;
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
