using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager4 : MonoBehaviour
{
    public GameManager Manager;
    public GameObject SelectPanel;
    public GameObject RequestPanel;
    public GameObject CommuPanel;
    public GameObject CreatePanel;
    public GameObject ReadPanel;
    public TransactionApi transaction;
    public GameObject UpdatePwPanel;
    public GameObject DeletePwPanel;
    public GameObject UpdatePanel;
    public InputField UpdatePw;
    public InputField DeletePw;
    public GameObject PwCheckPopup;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //모든 패널 끄기
    void ActiveFalse()
    {
        SelectPanel.SetActive(false);
        RequestPanel.SetActive(false);
        CommuPanel.SetActive(false);
        CreatePanel.SetActive(false);
        ReadPanel.SetActive(false);
        UpdatePwPanel.SetActive(false);
        DeletePwPanel.SetActive(false);
        UpdatePanel.SetActive(false);
    }

    //모든 패널 끄고 선택창 활성화
    public void ActiveSelect()
    {
        ActiveFalse();
        transaction.page =1;
        SelectPanel.SetActive(true);
    }

    //모든 패널 끄고 의뢰 게시판 활성화
    public void AcitveRequest()
    {
        ActiveFalse();
        RequestPanel.SetActive(true);
    }

    //모든 패널 끄고 사용자 게시판 활성화
    public void ActiveCommu()
    {
        ActiveFalse();
        CommuPanel.SetActive(true);
    }

    //모든 패널 끄고 게시글 작성화면 활성화
    public void ActiveCreate()
    {
        ActiveFalse();
        CreatePanel.SetActive(true);
    }

    //커뮤니티 패널 끄기
    public void CommunityExit()
    {
        ActiveSelect();
        Manager.CommunityExit();
    }

    //게시글 읽기 화면 활성화를 위해 해당 id의 게시글 내용 불러오기
    public void ActiveRead(int id)
    {
        transaction.GetOne(id);
    }

    //게시글 읽기 화면 활성화(코루틴이 끝나야 정보가 들어오기 떄문에, 코루틴 마지막에서 사용)
    public void ActiveRead2()
    {
        ActiveFalse();
        ReadPanel.SetActive(true);
    }

    //게시글 읽기 화면에서 작성버튼 클릭 후, 서버에 내용 전송
    public void PostSubmit()
    {
        transaction.PostOne();
        ActiveCommu();
    }

    //글 읽기 화면에서 원래의 비밀번호와 일치할경우 글 수정 화면 활성화
    public void ActiveUpdate()
    {
        if(UpdatePw.text == transaction.curPost.password)
        {
            ActiveFalse();
            UpdatePanel.SetActive(true);
        }
        else
        {
            PwCheckPopup.SetActive(true);
        }
    }

    //글 읽기 화면에서 원래의 비밀번호와 일치할 경우 글 삭제
    public void ActiveDelete()
    {
        if(DeletePw.text == transaction.curPost.password)
        {
            transaction.DeleteOne();
            ActiveCommu();
        }
        else
        {
            PwCheckPopup.SetActive(true);
        }
    }

    //수정을 위한 비밀번호 확인 화면 활성화
    public void ActiveUpdatePw()
    {
        ActiveFalse();
        UpdatePwPanel.SetActive(true);
    }

    //삭제를 위한 비밀번호 확인 화면 활성화
    public void ActiveDeletePw()
    {
        ActiveFalse();
        DeletePwPanel.SetActive(true);
    }

    //비밀번호 체크 화면 끄기
    public void PwCheckPopupExit()
    {
        PwCheckPopup.SetActive(false);
    }

    //글 수정 버튼 클릭 후, 서버에 내용 전송
    public void UpdateSubmit()
    {
        transaction.UpdateOne();
        ActiveCommu();
    }
}
