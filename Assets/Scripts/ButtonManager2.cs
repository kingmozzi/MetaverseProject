using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager2 : MonoBehaviour
{
    public GameObject PartPanel;
    public GameObject PartNull;
    public GameObject ServicePanel;
    public GameObject ServiceNull;
    public GameObject SpecialPanel;
    public GameObject SpecialNull;
    public Text InfoKindText;
    public GameManager Manager;
    public Image DetailImage;
    public ButtonManager3 btnManager3;

    public GameObject DetailPanel;
    public Image namePanel;
    public Text itemName;
    public Image picturePanel;
    public Text detail;
    public Text value;
    public Toggle isLike;

    public GameObject SpDetailPanel;
    public Image SpNamePanel;
    public Text SpItemName;
    public Image SpDetailImage;
    public Text SpDetail;
    public Toggle SpIsLike;

    public Button itemNextBtn;
    public Button itemBeforeBtn;
    public Button SpNextBtn;
    public Button SpBeforeBtn;

    public GameObject prefab;
    public ItemPrefab getVariable;

    string companyName;
    int detailIndex;
    int SpDetailIndex;

    int itemPage=1;
    int spPage=1;

    void Awake()
    {  
        InstantPart();
        InstantService();
        InstantSpecial();
    }

    //부품을 인스턴스로 생성, 길이가 0일 경우에는 메세지 출력
    void InstantPart()
    {
        if(Manager.itemLength == 0)
        {
            PartNull.SetActive(true);
        }
        for(int i=15*(itemPage-1);i<15*itemPage;i++)
        {
            if(i>=Manager.itemLength){
                break;
            }
            Item temp = Manager.items[i];
            
            getVariable = prefab.GetComponent<ItemPrefab>();
            Vector2 createPoint = Manager.SpawnPositions[i%15].position;
            getVariable.itemImage.sprite = temp.image;
            getVariable.nameText.text = temp.name;
            getVariable.index = i;
            getVariable.SpIndex = -1;

            switch(temp.grade)
            {
                case 0:
                    getVariable.itemBacground.color = new Color(124/255f, 126/255f, 125/255f);
                    break;
                case 1:
                    getVariable.itemBacground.color = new Color(88/255f, 143/255f, 111/255f);
                    break;
                case 2:
                    getVariable.itemBacground.color = new Color(85/255f, 128/255f, 163/255f);
                    break;
                case 3:
                    break;
            }

            Instantiate(prefab, createPoint, Quaternion.identity, PartPanel.transform);
            
        }
    }

    //서비스를 인스턴스로 생성, 길이가 0일 경우에는 메세지 출력
    void InstantService()
    {
        if(Manager.ServiceItemLength == 0)
        {
            ServiceNull.SetActive(true);
        }
    }

    //특장을 인스턴스로 생성, 길이가 0일 경우에는 메세지 출력
    void InstantSpecial()
    {
        if(Manager.SpItemLength == 0)
        {
            SpecialNull.SetActive(true);
        }
        for(int i=15*(spPage-1);i<15*spPage;i++)
        {
            if(i>=Manager.SpItemLength)
            {
                break;
            }
            SpecialItem temp = Manager.SpItems[i];

            getVariable = prefab.GetComponent<ItemPrefab>();
            Vector2 createPoint = Manager.SpawnPositions[i%15].position;
            getVariable.itemBacground.color = new Color(124/255f, 126/255f, 125/255f);
            getVariable.nameText.text = temp.name;
            getVariable.itemImage.sprite = temp.image;
            getVariable.SpIndex = i;
            getVariable.index = -1;

            Instantiate(prefab, createPoint, Quaternion.identity, SpecialPanel.transform);

        }
    }

    void Start()
    {
        companyName = InfoKindText.text;
        InfoKindText.text += "/부품";
    }

    void Update()
    {

    }

    //모든패널 끄기
    void ActiveFalse()
    {
        PartPanel.SetActive(false);
        ServicePanel.SetActive(false);
        SpecialPanel.SetActive(false);
        DetailPanel.SetActive(false);
        SpDetailPanel.SetActive(false);

        InfoKindText.text = companyName;
    }

    //모든패널을 끄고 부품패널 활성화.
    public void ActivePart()
    {
        ActiveFalse();
        PartPanel.SetActive(true);
        InfoKindText.text += "/부품";
    }

    //모든패널 끄고 서비스패널 활성화.
    public void ActiveService()
    {
        ActiveFalse();
        ServicePanel.SetActive(true);
        InfoKindText.text += "/서비스";
    }


    //모든패널 끄고 특장패널 활성화.
    public void ActiveSpecial()
    {
        ActiveFalse();
        SpecialPanel.SetActive(true);
        InfoKindText.text += "/특장";
    }

    //서비스 정보패널 끄기.
    public void ServiceInfoExit()
    {
        DetailExit();
        SpDetailExit();
        Manager.ServiceInfoExit();
    }

    //부품 상세정보 활성화.
    public void ActiveDetail(int index)
    {
        Item temp = Manager.items[index];
        detailIndex = -1;
        switch(temp.grade)
        {
            case 0:
                namePanel.color = new Color(169/255f, 172/255f, 171/255f);
                picturePanel.color = new Color(124/255f, 126/255f, 125/255f);
                break;
            case 1:
                namePanel.color = new Color(41/255f, 144/255f, 114/255f);
                picturePanel.color = new Color(88/255f, 143/255f, 111/255f);
                break;
            case 2:
                namePanel.color = new Color(40/255f, 113/255f, 144/255f);
                picturePanel.color = new Color(85/255f, 128/255f, 163/255f);
                break;
            case 3:
                break;
        }

        itemName.text = temp.name;
        detail.text = temp.detail;
        value.text = (temp.value).ToString() + "\\";
        isLike.isOn = temp.isLike;
        DetailImage.sprite = temp.image;

        DetailPanel.SetActive(true);
        detailIndex = index;
    }

    /*
     * 좋아요 토글 활성, 비활성상태에 따라 카트에 넣고 뺌.
     * 업데이트된 카트에 맞게 좋아요 리스트 업데이트
     */
    public void toggleListener()
    {
        if(detailIndex != -1)
        {
            if(isLike.isOn)
            {
                Manager.addCart(detailIndex);
            }
            else{
                Manager.deleteCart(detailIndex);
            }
        }
        btnManager3.Instants();
    }

    //부품 상세정보 끄기
    public void DetailExit()
    {
        detailIndex=-1;
        DetailPanel.SetActive(false);
    }

    //특장 상세정보 활성화.
    public void ActiveSpDetail(int index)
    {
        SpecialItem temp = Manager.SpItems[index];
        SpDetailIndex = -1;

        SpItemName.text = temp.name;
        SpDetail.text = temp.detail;
        SpIsLike.isOn = temp.isLike;
        SpDetailImage.sprite = temp.image;

        SpDetailPanel.SetActive(true);
        SpDetailIndex = index;
    }

    /*
     * 특장 좋아요 토글 활성, 비활성상태에 따라 특장 카트에 넣고 뺌.
     * 업데이트된 특장 카트에 맞게 좋아요 리스트 업데이트
     */
    public void SpToggleListener()
    {
        if(SpDetailIndex != -1)
        {
            if(SpIsLike.isOn)
            {
                Manager.addSpCart(SpDetailIndex);
            }
            else{
                Manager.deleteSpCart(SpDetailIndex);
            }
        }
        btnManager3.Instants();
    }

    //특장 상세정보 끄기
    public void SpDetailExit()
    {
        SpDetailIndex=-1;
        SpDetailPanel.SetActive(false);
    }

    public void itemNextPage()
    {
        if(itemPage*15 < Manager.itemLength)
        {
            itemPage+=1;
        }
        InstantPart();
    }

    public void itemBeforePage()
    {
        if(itemPage>1){
            itemPage-=1;
        }
        InstantPart();
    }

    public void SpNextPage()
    {
        if(spPage*15 < Manager.SpItemLength)
        {
            spPage+=1;
        }
        InstantSpecial();
    }

    public void SpBeforePage()
    {
        if(spPage>1){
            spPage-=1;
        }
        InstantSpecial();
    }



}
