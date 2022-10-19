using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public GameObject PostObject;
    public TransactionApi Transaction;
    public Button RefreshButton;
    public ReadPost readpost;

    int x = 508;
    int y = 340;

    // Start is called before the first frame update
    void Start()
    {
        Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
            tempPrefab.recommend.text = tempPost.recommend.ToString();
            Instantiate(PostObject, createPoint, Quaternion.identity, transform);
            y-=30;
        }
    }

    public void Refresh()
    {
        x = 508;
        y = 340;
        Transaction.GetList();
    }

    public void PostPrint()
    {
        var temp = Transaction.curPost;
        readpost.title.text = temp.title;
        readpost.writer.text = temp.writer + " | " + temp.create_date;
        readpost.count.text = "조회 " + temp.count.ToString() + " | 추천 " + temp.recommend.ToString();
        readpost.contents.text = temp.contents;
    }


}
