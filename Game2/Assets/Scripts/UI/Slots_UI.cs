using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Slots_UI : MonoBehaviour, IPointerClickHandler
{
    public Image iconImage;
    public TextMeshProUGUI descriptionText;
    public Inventory.Slot slot;
    private string itemDescription;
    private static Slots_UI currentSelectedSlot;
    private static Slots_UI previousSelectedSlot;

    private void Start()
    {
        descriptionText.gameObject.SetActive(false);
    }

    public void SetItem(Inventory.Slot slot, string description)
    {
        this.slot = slot;
        iconImage.sprite = slot.icon;
        iconImage.color = new Color(1, 1, 1, 1);
        itemDescription = description;
    }

    public void SetEmpty()
    {
        slot = null;
        iconImage.sprite = null;
        iconImage.color = new Color(1, 1, 1, 0);
        ClearDescription();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (slot != null)
        {
            // Hide the description of the previously selected item
            if (previousSelectedSlot != null && previousSelectedSlot != this)
            {
                previousSelectedSlot.descriptionText.gameObject.SetActive(false);
            }

            // Toggle the visibility of the description text
            descriptionText.gameObject.SetActive(!descriptionText.gameObject.activeSelf);

            // Update the description text if it's being shown
            if (descriptionText.gameObject.activeSelf)
            {
                descriptionText.text = itemDescription;
            }

            // Set the current selected slot to this slot
            currentSelectedSlot = this;
            // Update the previous selected slot
            previousSelectedSlot = this;
        }
    }

    public void ClearDescription()
    {
        descriptionText.gameObject.SetActive(false);
        descriptionText.text = "";
        itemDescription = null;
    }
}
