using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LikePrefab : MonoBehaviour
{
    public Image itemBacground;
    public Text nameText;
    public Image itemImage;
    public int index=-1;
    public int SpIndex=-1;
    ButtonManager2 btnManager2;
    public ButtonManager3 btnManager3;

    private void Awake() {
        btnManager2 = GameObject.Find("Canvas").transform.Find("ServiceInfo").GetComponent<ButtonManager2>();
        btnManager3 = GameObject.Find("Canvas").transform.Find("LikeInfo").GetComponent<ButtonManager3>();
    }

    //좋아요 버튼 상태가 변하면 리스트에 새로 업데이트를 해줘야 하므로 본인 삭제
    void Update()
    {
        btnManager2.isLike.onValueChanged.AddListener(delegate{DeleteSelf();});
        btnManager2.SpIsLike.onValueChanged.AddListener(delegate{DeleteSelf();});
        btnManager3.isLike.onValueChanged.AddListener(delegate{DeleteSelf();});
        btnManager3.SpIsLike.onValueChanged.AddListener(delegate{DeleteSelf();});
    }
    
    void DeleteSelf()
    {
        gameObject.SetActive(false);
    }

    //아이템 클릭시 상세정보 활성화
    public void Onclick()
    {   
        if(index!=-1){
            btnManager3.ActiveDetail(index);
        }
        else if(SpIndex != -1)
        {
            btnManager3.ActiveSpDetail(SpIndex);
        }
        
    }
}
