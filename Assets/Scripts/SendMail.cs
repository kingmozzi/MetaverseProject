using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net.Mail;

public class SendMail : MonoBehaviour
{
    public Dropdown Category;
    public InputField Name;
    public InputField Email;
    public InputField Contents;

    MySettings myset = new MySettings();
    MailMessage message;
    // Start is called before the first frame update

    void Awake()
    {
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //메일 전송하기
    public void SendEMail()
    {
        message = new System.Net.Mail.MailMessage();
        message.From = new System.Net.Mail.MailAddress(myset.from);
        message.To.Add(myset.to);
        message.Subject = "["+Category.options[Category.value].text+"]"+"Unity Metaverse에서 온 메일입니다.";
        message.SubjectEncoding = System.Text.Encoding.UTF8;
        message.Body = "작성자: "+Name.text+"\n연락처: "+Email.text+"\n내용: "+Contents.text;
        Name.text = Email.text=Contents.text = "";
        message.BodyEncoding = System.Text.Encoding.UTF8;
        try
        {
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.naver.com", 587);
            smtp.UseDefaultCredentials = false; // 시스템에 설정된 인증 정보를 사용하지 않는다.
            smtp.EnableSsl = true;  // SSL을 사용한다.
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network; // 이걸 하지 않으면 naver 에 인증을 받지 못한다.
            smtp.Credentials = new System.Net.NetworkCredential(myset.id, myset.pw);
            smtp.Send(message);
        }
        catch (System.Exception e)
        {
           Debug.Log(e.Message);
        }
    }
}
