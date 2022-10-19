using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;

public class TransactionApi : MonoBehaviour
{
    [Serializable]
    public class Post
    {
        public int id;
        public string title;
        public string writer;
        public string create_date;
        public int count;
        public int recommend;
        public string password;
        public string contents;
    }

    public static class JsonHelper 
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = UnityEngine.JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.data;
        }
        
        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.data = array;
            return JsonUtility.ToJson(wrapper);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] data;
        }    
    }

    public Post[] PostList;
    public Post curPost;
    public Board boardScript;

    public InputField postTitle;
    public InputField postWriter;
    public InputField postPw;
    public InputField postContents;

    public ButtonManager4 btnManager4;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DataPost());
        //StartCoroutine(DataGet());
        //StartCoroutine(DataGetOne(1));
        //StartCoroutine(DataUpdate(7));
        //StartCoroutine(DataDelete(4));
    }

    public void GetList()
    {
        StartCoroutine(DataGet());
    }

    public void GetOne(int index)
    {
        StartCoroutine(DataGetOne(index));
    }

    public void PostOne()
    {
        StartCoroutine(DataPost());
        GetList();
    }

    IEnumerator DataGet()
    {
        string url = "http://127.0.0.1:8000/board";

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            //Debug.Log(www.downloadHandler.text);
            PostList = JsonHelper.FromJson<Post>("{\"data\":"+www.downloadHandler.text+"}");
            boardScript.BoardPrint();           
        }
    }

    IEnumerator DataPost()
    {
        string url = "http://127.0.0.1:8000/board";
        string title = postTitle.text;
        postTitle.text="";
        string writer = postWriter.text;
        postWriter.text = "";
        string pw = postPw.text;
        postPw.text = ""; 
        string contents = postContents.text;
        postContents.text="";
        string form = "{\"title\": \""+title+"\",\"writer\": \""+writer+"\",\"password\": \""+pw+"\",\"contents\": \""+contents+"\"}";
        byte[] databyte = Encoding.UTF8.GetBytes(form);
        UnityWebRequest _request = new UnityWebRequest(url,UnityWebRequest.kHttpVerbPOST);
        _request.uploadHandler = new UploadHandlerRaw(databyte);
        _request.downloadHandler = new DownloadHandlerBuffer();
        _request.SetRequestHeader("Content-Type", "application/json;charset=utf-8");
        yield return _request.SendWebRequest();
        //Debug.Log(_request.responseCode);
        
        if (_request.error != null)
        {
            Debug.LogError(_request.error);
        }
        else
        {
            //Debug.Log(_request.downloadHandler.text);
        }
    }

    IEnumerator DataGetOne(int index)
    {
        string url = "http://127.0.0.1:8000/board/" + index.ToString();

        UnityWebRequest www = UnityWebRequest.Get(url);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Post temp = JsonUtility.FromJson<Post>(www.downloadHandler.text);
            curPost = temp;
            boardScript.PostPrint();
            btnManager4.ActiveRead2();
        }
    }

    IEnumerator DataUpdate(int index)
    {
        string url = "http://127.0.0.1:8000/board/" + index.ToString();

        string title = "반갑뜹니다";
        string writer = "야디록";
        string contents = "웟";
        string form = "{\"title\": \""+title+"\",\"writer\": \""+writer+"\",\"contents\": \""+contents+"\"}";
        byte[] databyte = Encoding.UTF8.GetBytes(form);
        UnityWebRequest _request = new UnityWebRequest(url,UnityWebRequest.kHttpVerbPUT);
        _request.uploadHandler = new UploadHandlerRaw(databyte);
        _request.downloadHandler = new DownloadHandlerBuffer();
        _request.SetRequestHeader("Content-Type", "application/json;charset=utf-8");
        yield return _request.SendWebRequest();
        Debug.Log(_request.responseCode);
        
        if (_request.error != null)
        {
            Debug.LogError(_request.error);
        }
        else
        {
            Debug.Log(_request.downloadHandler.text);
        }
    }

    IEnumerator DataDelete(int index)
    {
        string url = "http://127.0.0.1:8000/board/" + index.ToString();

        UnityWebRequest www = UnityWebRequest.Delete(url);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log(www.responseCode);
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
