using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public Sprite icon;
        public int count;
        public int maxAllowed;
        public string description;

        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 1;
        }

        public bool CanAddItem()
        {
            return count < maxAllowed;
        }

        public void AddItem(UpdateSprite item)
        {
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }
        
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(UpdateSprite item)
    {
        foreach(Slot slot in slots)
        {
            if(slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if(slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }
}
