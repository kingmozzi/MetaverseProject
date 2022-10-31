using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PostListPrefab : MonoBehaviour
{
    public Text id;
    public Text title;
    public Text writer;
    public Text create_date;
    public Text count;

    Board board;
    ButtonManager4 btnManager4;

    void Start()
    {
        btnManager4 = GameObject.Find("Canvas/Community").GetComponent<ButtonManager4>();
        board = GameObject.Find("Canvas/Community/CommuPanel/BoardPanel").GetComponent<Board>();
    }

    //새로고침 할 경우, 리스트를 새로 업데이트해야 하므로 본인 삭제
    void Update()
    {
        board.RefreshButton.onClick.AddListener(delegate{DeleteSelf();});
        board.BeforeButton.onClick.AddListener(delegate{DeleteSelf();});
        board.NextButton.onClick.AddListener(delegate{DeleteSelf();});
    }

    void DeleteSelf()
    {
        gameObject.SetActive(false);
    }

    //포스트 프리팹 클릭 시, 게시글 상세 내용화면 활성화
    public void OnClick()
    {
        btnManager4.ActiveRead(Int32.Parse(id.text));
    }
}
