using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject CompanyInfo;
    public GameObject InfoNpc;
    public GameObject ServiceInfo;
    public GameObject ServiceInfoNpc;
    public Camera getCamera;
    public List<Item> items;
    public List<Item> cart;
    public List<SpecialItem> SpItems;
    public List<SpecialItem> SpCart;

    bool isInfo;

    RaycastHit hit;

    void Awake()
    {
        items = getItems();
        cart = new List<Item>();
        SpItems = getSpItems();
        SpCart = new List<SpecialItem>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckNPC();
    }

    void CheckNPC()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.gameObject);
                if(hit.collider.gameObject == InfoNpc)
                {
                    InfoNpcClicked();
                }
                else if(hit.collider.gameObject == ServiceInfoNpc)
                {
                    ServiceInfoNpcClicked();
                }
                
            }
        }
    }
    
    void InfoNpcClicked()
    {
        if(!isInfo)
        {
            CompanyInfo.SetActive(true);
            isInfo=true;
        }
    }

    public void CompanyInfoExit()
    {
        CompanyInfo.SetActive(false);
        isInfo=false;
    }

    void ServiceInfoNpcClicked()
    {
        if(!isInfo)
        {
            ServiceInfo.SetActive(true);
            isInfo=true;
        }
    }

    public void ServiceInfoExit()
    {
        ServiceInfo.SetActive(false);
        isInfo=false;
    }

    public void addCart(int index)
    {
        items[index].isLike = true;
        cart.Add(items[index]);
    }
    public void deleteCart(int index)
    {
        items[index].isLike = false;
        cart.Remove(items[index]);
    }

    public int itemLength = 3;
    public Image suspension;
    string[] names = {"네오테크 서스펜션 Basic", "네오테크 서스펜션 Comport", "네오테크 서스펜션 Sports"}; 
    string[] details = {"가장 기본적인 튜닝용 코일오버 서스펜션 입니다. 자신이 원하는 차고를 맞출 수 있으며 빨라진 핸들링 반응을 느끼실 수 있는 제품입니다.",
                        "튜닝 입문자들에게 가장 추천드리는 서스펜션 입니다. 감쇠력 조절이 가능하기 때문에 편안한 승차감, 우수한 핸들링을 선택적으로 세팅이 가능합니다. 스테디 셀러이자 베스트셀러인 타입입니다.",
                        "Anti-NVH마운트로 소음과 진동은 최소화 하면서 캠버를 조절할 수 있도록 알루미늄 조절식 마운트가 적용됩니다. 감쇠력 조절을 통해 일반 공도주행도 함께 즐길 수 있는 제품입니다."};
    int[] values = {1300000, 1500000, 1800000};
    int[] grades = {0, 1, 2}; 

    List<Item> getItems()
    {
        List<Item> temp = new List<Item>();
        for(int i=0;i<itemLength;i++)
        {
            Item itemTemp = new Item(names[i], details[i], values[i], grades[i], suspension);
            temp.Add(itemTemp);
        }

        return temp;
    }

    public int SpItemLength = 3;
    public Image[] SpImages;
    string[] SpNames = {"렉카용 쇽업소버", "화물 및 승합 스타렉스용 속업쇼버", "1톤 윙카용 SAFETY KIT"};
    string[] SpDetails = {"사고차량을 안전하게 끌기 위해 안정된 차고를 확보할 수 있도록 쇽업소버의 세팅을 변경하고 차량 견인 시 발생할 수 있는 앞바퀴 들림 현상을 완화하였습니다.",
                            "고속주행이 불가피한 긴급 호송 차량이나 적재 무게가 큰 화물 운송 차량의 안전한 운행을 위해 승차감을 최대한 유지 하면서 무게중심 이동 제어, 핸들링 개선을 통해 주행 안정성을 높였습니다.",
                            "바람의 저항을 많이 받는 형상을 갖고 있으며 적재를 많이 하기 때문에 주행 안정성이 매우 불안합니다. 이를 적절한 댐핑압력의 쇽업소바와 리어 판스프링 보강 킷을 통해 안전하고 편안한 주행이 가능하도록 하였습니다."};

    List<SpecialItem> getSpItems()
    {
        List<SpecialItem> temp = new List<SpecialItem>();
        for(int i=0;i<SpItemLength;i++)
        {
            SpecialItem SpItemTemp = new SpecialItem(SpNames[i], SpDetails[i], SpImages[i]);
            temp.Add(SpItemTemp);
        }

        return temp;
    }

}
