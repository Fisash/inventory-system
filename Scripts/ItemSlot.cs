using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot
{
    public Item item;
    public int count;
    public Image image;
    public Text countText;

    public bool isAbsent { get { return count <= 0 || item == null; } }
    public bool isFull { get { return count >= item.stackCount; } }

    public ItemSlot(Image image)
    {
        this.image = image;
        countText = image.transform.GetChild(0).gameObject.GetComponent<Text>();
    }
    public void Put(Item item, int count)
    {
        this.item = item;
        this.count = count;
    }
    public void UpdateDisplay()
    {
        image.sprite = isAbsent ? null : item.icon;
        countText.text = isAbsent ? "" : count.ToString();
        image.color = isAbsent ? new Color32(255, 255, 255, 0) : new Color32(255, 255, 255, 255);
    }
}
