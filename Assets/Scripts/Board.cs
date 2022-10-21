using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject PostObject;
    public TransactionApi Transaction;
    public Button RefreshButton;
    public Button NextButton;
    public Button BeforeButton;
    public ReadPost readpost;

    public RectTransform SpawnPostion;


    float x;
    float y;

    void Start()
    {
        Refresh();
    }

    void Update()
    {
        
    }

    //Board에 받아온 게시글들을 표시
    public void BoardPrint()
    {
        for(int i=0;i<Transaction.PostList.Length;i++)
        {
            var tempPost = Transaction.PostList[i];
            PostListPrefab tempPrefab = PostObject.GetComponent<PostListPrefab>(); 
            Vector2 createPoint = new Vector2(x,y);
            tempPrefab.id.text = tempPost.id.ToString();
            tempPrefab.title.text = tempPost.title;
            tempPrefab.writer.text = tempPost.writer;
            tempPrefab.create_date.text = tempPost.create_date;
            tempPrefab.count.text = tempPost.count.ToString();
            //tempPrefab.recommend.text = tempPost.recommend.ToString();
            Instantiate(PostObject, createPoint, Quaternion.identity, transform);
            y-=30;
        }
    }

    //새로고침 - x,y 좌표 초기화 시킨 후 새로 생성
    public void Refresh()
    {
        x = SpawnPostion.position.x;
        y = SpawnPostion.position.y;
        Transaction.GetList();
    }

    //게시글 내용 출력 - 제목, 글쓴이, 날짜, 조회수, 내용
    public void PostPrint()
    {
        var temp = Transaction.curPost;
        readpost.title.text = temp.title;
        readpost.writer.text = temp.writer + " | " + temp.create_date;
        readpost.count.text = "조회 " + temp.count.ToString();
        readpost.contents.text = temp.contents;
    }

    //이전 페이지
    public void BeforePage()
    {
        if(Transaction.page > 1)
        {
            Transaction.page-=1;
        }
        Refresh();
    }

    //다음 페이지
    public void NextPage()
    {
        Transaction.page+=1;
        Refresh();
    }


}
