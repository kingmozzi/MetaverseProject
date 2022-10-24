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

    public GameObject prefab;
    public ItemPrefab getVariable;

    string companyName;
    int detailIndex;
    int SpDetailIndex;

    void Awake()
    {  
        InstantPart();
        InstantService();
        InstantSpecial();
    }

    void InstantPart()
    {
        if(Manager.itemLength == 0)
        {
            PartNull.SetActive(true);
        }
        for(int i=0;i<Manager.itemLength;i++)
        {
            Item temp = Manager.items[i];
            
            getVariable = prefab.GetComponent<ItemPrefab>();
            Vector2 createPoint = Manager.SpawnPositions[i].position;
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

    void InstantService()
    {
        if(Manager.ServiceItemLength == 0)
        {
            ServiceNull.SetActive(true);
        }
    }

    void InstantSpecial()
    {
        if(Manager.SpItemLength == 0)
        {
            SpecialNull.SetActive(true);
        }
        for(int i=0;i<Manager.SpItemLength;i++)
        {
            SpecialItem temp = Manager.SpItems[i];

            getVariable = prefab.GetComponent<ItemPrefab>();
            Vector2 createPoint = Manager.SpawnPositions[i].position;
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

    // Update is called once per frame
    void Update()
    {

    }

    void ActiveFalse()
    {
        PartPanel.SetActive(false);
        ServicePanel.SetActive(false);
        SpecialPanel.SetActive(false);
        DetailPanel.SetActive(false);
        SpDetailPanel.SetActive(false);

        InfoKindText.text = companyName;
    }

    public void ActivePart()
    {
        ActiveFalse();
        PartPanel.SetActive(true);
        InfoKindText.text += "/부품";
    }

    public void ActiveService()
    {
        ActiveFalse();
        ServicePanel.SetActive(true);
        InfoKindText.text += "/서비스";
    }

    public void ActiveSpecial()
    {
        ActiveFalse();
        SpecialPanel.SetActive(true);
        InfoKindText.text += "/특장";
    }

    public void ServiceInfoExit()
    {
        DetailExit();
        SpDetailExit();
        Manager.ServiceInfoExit();
    }

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

    public void DetailExit()
    {
        detailIndex=-1;
        DetailPanel.SetActive(false);
    }

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


    public void SpDetailExit()
    {
        SpDetailIndex=-1;
        SpDetailPanel.SetActive(false);
    }


}
