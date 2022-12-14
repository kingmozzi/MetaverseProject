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
    public ButtonManager2 btnManager2;
    public ButtonManager3 btnManager3;

    private void Awake() {
        btnManager3 = GameObject.Find("Canvas/LikeInfo").GetComponent<ButtonManager3>();
        //btnManager2 = GameObject.Find("Canvas/ServiceInfo").GetComponent<ButtonManager2>();
        btnManager2 = btnManager3.btnManager2;
    }

    void Update()
    {
        if(index != -1)
        {
            btnManager3.itemBeforeBtn.onClick.AddListener(delegate{DeleteSelf();});
            btnManager3.itemNextBtn.onClick.AddListener(delegate{DeleteSelf();});
        }
        else if(SpIndex != -1)
        {
            btnManager3.SpBeforeBtn.onClick.AddListener(delegate{DeleteSelf();});
            btnManager3.SpNextBtn.onClick.AddListener(delegate{DeleteSelf();});
        }
        btnManager2.isLike.onValueChanged.AddListener(delegate{DeleteSelf();});
        btnManager2.SpIsLike.onValueChanged.AddListener(delegate{DeleteSelf();});
        btnManager3.isLike.onValueChanged.AddListener(delegate{DeleteSelf();});
        btnManager3.SpIsLike.onValueChanged.AddListener(delegate{DeleteSelf();});
    }
    
    void DeleteSelf()
    {
        gameObject.SetActive(false);
    }

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
