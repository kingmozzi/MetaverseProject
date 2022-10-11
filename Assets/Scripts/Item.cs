using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    public string name{get; set;}
    public string detail{get; set;}
    public int value{get; set;}
    public bool isLike{get; set;}
    public int grade{get; set;}
    public Image image{get; set;}

    public Item(string _name, string _detail="", int _value=0, int _grade=0, Image _image = null)
    {
        name = _name;
        detail = _detail;
        value = _value;
        isLike = false;
        grade=_grade;
        image = _image;
    }
}

