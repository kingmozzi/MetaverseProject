using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialItem
{
    public string name{get; set;}
    public string detail{get; set;}
    public bool isLike{get; set;}
    public Sprite image{get; set;}

    public SpecialItem(string _name, string _detail="", Sprite _image = null)
    {
        name = _name;
        detail = _detail;
        isLike = false;
        image = _image;
    }
}
