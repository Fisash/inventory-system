using System.Collections;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        public ItemSlot[] slots;
        public ItemSlot mouseSlot;
        //public Item testItem;
        public void Start()
        {
            slots = new ItemSlot[transform.childCount];
            mouseSlot = new ItemSlot(transform.parent.GetChild(1).GetComponent<Image>());
            for (int i = 0; i < transform.childCount; i++)
            {
                slots[i] = new ItemSlot(transform.GetChild(i).transform.GetChild(0).GetComponent<Image>());
            }
            //AddItem(testItem, 5);
        }
        public void TapSlot(int index)
        {
            if (mouseSlot.item != slots[index].item)
            {
                SwapSlotsContent(mouseSlot, slots[index]);
                return;
            }
            if (mouseSlot.item == null) { return; }
            int fullCount = mouseSlot.count + slots[index].count;
            int remains = fullCount - mouseSlot.item.stackCount;
            slots[index].count = remains <= 0 ? fullCount : mouseSlot.item.stackCount;
            mouseSlot.count = remains <= 0 ? 0 : remains;
            UpdateDisplay();
        }
        public void SwapSlotsContent(ItemSlot a, ItemSlot b)
        {
            Item memorizedItem = a.item;
            int memrizedCount = a.count;
            a.Put(b.item, b.count);
            b.Put(memorizedItem, memrizedCount);
            a.UpdateDisplay();
            b.UpdateDisplay();
        }
        public void AddItem(Item item, int count = 1)
        {
            for(int i = 0; i < slots.Length; i++)
            {
                if (slots[i].isAbsent || (slots[i].item == item && !slots[i].isFull))
                {
                    int fullCount = slots[i].count + count;
                    int remains = fullCount - item.stackCount;
                    slots[i].Put(item, remains <= 0 ? fullCount : item.stackCount);
                    if (remains > 0)
                    {
                        AddItem(item, remains);
                    }
                    UpdateDisplay();
                    return;
                }
            }
        }
        public void UpdateDisplay()
        {
            foreach(ItemSlot slot in slots)
            {
                slot.UpdateDisplay();
            }
            mouseSlot.UpdateDisplay();
        }
    }
}
