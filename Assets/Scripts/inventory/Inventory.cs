using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject Player;
    public GameObject Character;
    public GameObject PlayerCanvas;
    public GameObject slotPanel;
    public GameObject equipeblePanel;
    public ItemDatabase database;
    public PlayerControler PlayerControler;
    public GameObject inventorySlot;
    public GameObject equipebleSlot;
    public GameObject inventoryItem;
    public GameObject ArmorSlot;
    public GameObject WaponSlot;
    public GameObject ArtifactSlot;
    public Item item;

    public int slotamount;
    public int equipebleamount;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();
    //public List<Item>  equipebles = new List<Item>();
    //public List<GameObject> eslots = new List<GameObject>();

    void Start()
    {
    }

    public void Houi(string _IDs)
    {
        database = GetComponent<ItemDatabase>();
        //slotamount = 15;
        Player = GameObject.Find(_IDs);
        PlayerCanvas = Player.transform.FindChild("Canvas").gameObject;
        inventoryPanel = PlayerCanvas.transform.FindChild("Inventory Panel").gameObject;
        slotPanel = inventoryPanel.transform.FindChild("Slot Panel").gameObject;
        equipeblePanel = inventoryPanel.transform.FindChild("equipeble panel").gameObject;
        Character = Player.transform.FindChild("Character" + _IDs).gameObject;
        PlayerControler = Character.GetComponent<PlayerControler>();
    }
    public void fillinventory()
    { 
        for (int i = 0; i < slotamount; i++)
        {
            if (i > 2)
            {
                items.Add(new Item());
                slots.Add(Instantiate(inventorySlot));
                slots[i].GetComponent<ItemSlot>().id = i;
                slots[i].transform.SetParent(slotPanel.transform);
            } else if (i == 0)
            {
                items.Add(new Item());
                slots.Add(Instantiate(WaponSlot));
                slots[i].GetComponent<ItemSlot>().id = i;
                slots[i].transform.SetParent(equipeblePanel.transform);
            }
            else if (i == 1)
            {
                items.Add(new Item());
                slots.Add(Instantiate(ArmorSlot));
                slots[i].GetComponent<ItemSlot>().id = i;
                slots[i].transform.SetParent(equipeblePanel.transform);
            }
            else if (i == 2)
            {
                items.Add(new Item());
                slots.Add(Instantiate(ArtifactSlot));
                slots[i].GetComponent<ItemSlot>().id = i;
                slots[i].transform.SetParent(equipeblePanel.transform);
            }

        }

       
    }

    public void itemgive()
    {
        AddItem(0);
        AddItem(1);
        AddItem(2);

    }


    public void AddItem(int id)
    {
        Item itemtoadd = database.FetchItemByID(id);
        if (itemtoadd.Stack && CheckItemInInventory(itemtoadd))
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == id)
                {
                    ItemData data = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                    data.amount++;
                    data.transform.GetChild(0).GetComponent<Text>().text = data.amount.ToString();
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == -1 && slots[i].GetComponent<ItemSlot>().id > 2)
                {
                    Debug.Log("iten added");
                    items[i] = itemtoadd;
                    GameObject itemObj = Instantiate(inventoryItem);
                    itemObj.GetComponent<ItemData>().item = itemtoadd;
                    itemObj.GetComponent<ItemData>().amount = 1;
                    itemObj.GetComponent<ItemData>().slotid = i;
                    itemObj.transform.SetParent(slots[i].transform);
                    itemObj.transform.position = slots[i].transform.position;
                    itemObj.GetComponent<Image>().sprite = itemtoadd.Sprite;
                    itemObj.name = itemtoadd.Name;

                    break;
                }
            }
        }
    }

    bool CheckItemInInventory(Item item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].ID == item.ID)
                return true;    
        }
        return false;
    }
}
