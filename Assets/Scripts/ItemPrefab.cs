using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPrefab : MonoBehaviour
{
    public Image itemBacground;
    public Text nameText;
    public Image itemImage;
    public int index=-1;
    public int SpIndex=-1;
    public ButtonManager2 btnManager2;

    private void Awake() {
        btnManager2 = GameObject.Find("Canvas/ServiceInfo").GetComponent<ButtonManager2>();
    }

    void Update()
    {
        if(index != -1)
        {
            btnManager2.itemBeforeBtn.onClick.AddListener(delegate{DeleteSelf();});
            btnManager2.itemNextBtn.onClick.AddListener(delegate{DeleteSelf();});
        }
        else if(SpIndex != -1)
        {
            btnManager2.SpBeforeBtn.onClick.AddListener(delegate{DeleteSelf();});
            btnManager2.SpNextBtn.onClick.AddListener(delegate{DeleteSelf();});
        }
    }
    
    void DeleteSelf()
    {
        gameObject.SetActive(false);
    }

    public void Onclick()
    {   
        if(index!=-1){
            btnManager2.ActiveDetail(index);
        }
        else if(SpIndex != -1)
        {
            btnManager2.ActiveSpDetail(SpIndex);
        }
        
    }

}
