using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class Item : ScriptableObject
{
    public string title;
    public string decription;
    public Sprite icon;
    public int stackCount;

}
