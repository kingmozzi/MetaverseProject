using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject CompanyInfo;
    public GameObject InfoNpc;
    public GameObject ServiceInfo;
    public GameObject ServiceInfoNpc;
    public GameObject LikeInfo;
    public GameObject LikeInfoNpc;
    public GameObject Community;
    public GameObject CommunityNpc;
    public GameObject VideoMode;
    public GameObject VideoModeNpc;
    public GameObject VideoModeCamera;
    public Camera getCamera;
    public List<Item> items;
    public List<Item> cart;
    public List<SpecialItem> SpItems;
    public List<SpecialItem> SpCart;
    public List<RectTransform> SpawnPositions;
    public List<RectTransform> PostSpawnPositions;

    public int itemLength = 0;
    public int ServiceItemLength = 0;
    public int SpItemLength = 0;

    public bool isInfo;

    RaycastHit hit;

    void Awake()
    {
        //가상 데이터 받아오기 
        items = getItems();
        cart = new List<Item>();
        SpItems = getSpItems();
        SpCart = new List<SpecialItem>();
        //VideoMode.GetComponent<VideoMode>().VideoSelect(2);
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        CheckNPC();
    }

    //NPC상호작용, 마우스 클릭한 NPC가 상호작용 가능한 NPC라면 그에 맞는 패널 활성화
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
                else if(hit.collider.gameObject == LikeInfoNpc)
                {
                    LikeInfoNpcClicked();
                }
                else if(hit.collider.gameObject == CommunityNpc)
                {
                    CommunityNpcClicked();
                }
                else if(hit.collider.gameObject == VideoModeNpc)
                {
                    VideoModeNpcClicked();
                }
                
            }
        }
    }
    
    //회사 정보 npc 클릭 -> 회사 정보 패널 활성화
    void InfoNpcClicked()
    {
        if(!isInfo)
        {
            CompanyInfo.SetActive(true);
            isInfo=true;
        }
    }

    //회사 정보 패널 비활성화
    public void CompanyInfoExit()
    {
        CompanyInfo.SetActive(false);
        isInfo=false;
    }

    //서비스(부품, 서비스, 특장종류) 정보 패널 활성화
    void ServiceInfoNpcClicked()
    {
        if(!isInfo)
        {
            ServiceInfo.SetActive(true);
            isInfo=true;
        }
    }

    //서비스(부품, 서비스, 특장종류) 정보 패널 비활성화
    public void ServiceInfoExit()
    {   
        ServiceInfo.SetActive(false);
        isInfo=false;
    }

    //좋아요 리스트 패널 활성화
    public void LikeInfoNpcClicked()
    {
        if(!isInfo)
        {
            LikeInfo.SetActive(true);
            isInfo = true;
        }
    }

    //좋아요 리스트 패널 비활성화
    public void LikeInfoExit()
    {
        LikeInfo.SetActive(false);
        isInfo = false;
    }

    //게시판 활성화
    public void CommunityNpcClicked()
    {
        if(!isInfo)
        {
            Community.SetActive(true);
            isInfo = true;
        }
    }

    //게시판 비활성화
    public void CommunityExit()
    {
        Community.SetActive(false);
        isInfo = false;
    }

    //비디오 모드 활성화
    void VideoModeNpcClicked()
    {
        if(!isInfo)
        {
            VideoMode.SetActive(true);
            isInfo = true;
            Player.SetActive(false);
            VideoModeCamera.SetActive(true);
        }
    }

    //비디오 모드 비활성화
    public void VideoModeExit()
    {
        VideoMode.SetActive(false);
        isInfo = false;
        VideoModeCamera.SetActive(false);
        Player.SetActive(true);
    }

    //좋아요 누른 제품을 카트에 추가함
    public void addCart(int index)
    {
        items[index].isLike = true;
        cart.Add(items[index]);
    }
    //좋아요 취소한 제품을 카트에서 뺌
    public void deleteCart(int index)
    {
        items[index].isLike = false;
        cart.Remove(items[index]);
    }
    //좋아요 리스트에서 좋아요 취소한 제품을 카트에서 뺌
    public void deleteCartFromCart(int index)
    {
        cart[index].isLike = false;
        cart.Remove(cart[index]);
    }
    //좋아요 누른 특장을 카트에 추가함
    public void addSpCart(int index)
    {
        SpItems[index].isLike = true;
        SpCart.Add(SpItems[index]);
    }
    //좋아요 취소한 특장을 카트에서 뺌
    public void deleteSpCart(int index)
    {
        SpItems[index].isLike = false;
        SpCart.Remove(SpItems[index]);
    }
    //좋아요 리스트에서 좋아요 취소한 특장을 카트에서 뺌
    public void deleteSpCartFromCart(int index)
    {
        SpCart[index].isLike = false;
        SpCart.Remove(SpCart[index]);
    }

    
    

    //가상 데이터 입력

    
    public Sprite suspension;
    string[] names = {"네오테크 서스펜션 Basic", "네오테크 서스펜션 Comport", "네오테크 서스펜션 Sports", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14"}; 
    string[] details = {"가장 기본적인 튜닝용 코일오버 서스펜션 입니다. 자신이 원하는 차고를 맞출 수 있으며 빨라진 핸들링 반응을 느끼실 수 있는 제품입니다.",
                        "튜닝 입문자들에게 가장 추천드리는 서스펜션 입니다. 감쇠력 조절이 가능하기 때문에 편안한 승차감, 우수한 핸들링을 선택적으로 세팅이 가능합니다. 스테디 셀러이자 베스트셀러인 타입입니다.",
                        "Anti-NVH마운트로 소음과 진동은 최소화 하면서 캠버를 조절할 수 있도록 알루미늄 조절식 마운트가 적용됩니다. 감쇠력 조절을 통해 일반 공도주행도 함께 즐길 수 있는 제품입니다.",
                        "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14"};
    int[] values = {1300000, 1500000, 1800000, 1557, 1557, 1557, 1557, 1557, 1557, 1557, 1557, 1557, 1557, 1557, 1557, 1557, 1557};
    int[] grades = {0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1}; 

    List<Item> getItems()
    {
        List<Item> temp = new List<Item>();
        for(int i=0;i<names.Length;i++)
        {
            Item itemTemp = new Item(names[i], details[i], values[i], grades[i], suspension);
            temp.Add(itemTemp);
        }
        
        itemLength = temp.Count;
        return temp;
    }

    
    public Sprite[] SpImages;
    string[] SpNames = {"렉카용 쇽업소버", "화물 및 승합 스타렉스용 속업쇼버", "1톤 윙카용 SAFETY KIT", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14"};
    string[] SpDetails = {"사고차량을 안전하게 끌기 위해 안정된 차고를 확보할 수 있도록 쇽업소버의 세팅을 변경하고 차량 견인 시 발생할 수 있는 앞바퀴 들림 현상을 완화하였습니다.",
                            "고속주행이 불가피한 긴급 호송 차량이나 적재 무게가 큰 화물 운송 차량의 안전한 운행을 위해 승차감을 최대한 유지 하면서 무게중심 이동 제어, 핸들링 개선을 통해 주행 안정성을 높였습니다.",
                            "바람의 저항을 많이 받는 형상을 갖고 있으며 적재를 많이 하기 때문에 주행 안정성이 매우 불안합니다. 이를 적절한 댐핑압력의 쇽업소바와 리어 판스프링 보강 킷을 통해 안전하고 편안한 주행이 가능하도록 하였습니다.",
                            "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14"};

    List<SpecialItem> getSpItems()
    {
        List<SpecialItem> temp = new List<SpecialItem>();
        for(int i=0;i<SpNames.Length;i++)
        {
            SpecialItem SpItemTemp = new SpecialItem(SpNames[i], SpDetails[i], SpImages[i%3]);
            temp.Add(SpItemTemp);
        }

        SpItemLength = temp.Count;
        return temp;
    }

}
