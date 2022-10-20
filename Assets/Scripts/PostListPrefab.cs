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

    // Start is called before the first frame update
    void Start()
    {
        btnManager4 = GameObject.Find("Canvas").transform.Find("Community").GetComponent<ButtonManager4>();
        board = GameObject.Find("Canvas").transform.Find("Community").transform.Find("CommuPanel").transform.Find("BoardPanel").GetComponent<Board>();
    }

    // Update is called once per frame
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

    public void OnClick()
    {
        btnManager4.ActiveRead(Int32.Parse(id.text));
    }
}
