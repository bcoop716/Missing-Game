using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots_UI : MonoBehaviour
{
    public Image iconImage;

    public void SetItem(Inventory.Slot slot)
    {
        iconImage.sprite = slot.icon;
        iconImage.color = new Color(1, 1, 1, 1);
    }

    public void SetEmpty()
    {
        iconImage.sprite = null;
        iconImage.color = new Color(1, 1, 1, 0);
    }

}
