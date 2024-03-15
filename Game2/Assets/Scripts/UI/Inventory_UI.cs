using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory_UI : MonoBehaviour
{  
    public GameObject inventoryPanel;
    public Player player;
    public TextMeshProUGUI descriptionText;

    public List<Slots_UI> slots = new List<Slots_UI>();

    private void Start()
    {
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventory();
        }
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        descriptionText.gameObject.SetActive(false);
        Setup();
    }

    public void Setup()
    {
        if(slots.Count == player.inventory.slots.Count)
    {
        for(int i = 0; i < slots.Count; i++)
        {
            if(player.inventory.slots[i].type != CollectableType.NONE)
            {
                string description = GetDescriptionForType(player.inventory.slots[i].type);
                slots[i].SetItem(player.inventory.slots[i], description);
            }
            else
            {
                slots[i].SetEmpty();
                slots[i].ClearDescription();
            }
        }
    }

    }

    private string GetDescriptionForType(CollectableType type)
    {
        switch (type)
        {
            case CollectableType.G_BOOK:
                return "Landscaping Manual";
            case CollectableType.SPADE:
                return "Spade";
            case CollectableType.WATER_CAN:
                return "Watering Can";
            case CollectableType.HALF_BROOM:
                return "Broomstick appears to be broken";
            case CollectableType.O_HALF_BROOM:
                return "Other Half of Broomstick";
            case CollectableType.PLATE:
                return "Plate";
            case CollectableType.W_GLOVE:
                return "White Glove";
            case CollectableType.B_HAMMER:
                return "Bloody Hammer";
            case CollectableType.C_GOGGLES:
                return "Construction Goggles";
            case CollectableType.EMP_ID:
                return "Employee ID";
            case CollectableType.SAW:
                return "Saw";
            case CollectableType.WORKER_VEST:
                return "Worker Vest";
            // Add more cases for other types as needed
            default:
                return "";
        }
    }

    public void HandleItemClick(Inventory.Slot slot)
    {
        // Handle item click here, e.g., display more info about the item, use it, etc.
        Debug.Log("Item clicked: " + slot.type.ToString());
    }
}
