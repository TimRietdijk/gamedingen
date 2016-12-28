using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour, IDropHandler {
    public int id;
    private Inventory inv;
    public Item item;
    public int theid;
    public ItemData ItemData;

    void Start()
    {
        inv = GameObject.Find("Inventory").GetComponent<Inventory>();
    }
    void Update()
    {
        theid = ItemData.slotid;
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemData dropedItem = eventData.pointerDrag.GetComponent<ItemData>();
        if (dropedItem.item.Equipable == 0)
        {
            Debug.Log("wapon");
            if (inv.items[id].ID == -1 && inv.slots[id].GetComponent<ItemSlot>().id == 0 || inv.items[id].ID == -1 && inv.slots[id].GetComponent<ItemSlot>().id > 2)
            {
                inv.items[dropedItem.slotid] = new Item();
                inv.items[id] = dropedItem.item;
                dropedItem.slotid = id;
            }
            else if (dropedItem.slotid != id)
            {
                Transform item = this.transform.GetChild(0);
                item.GetComponent<ItemData>().slotid = dropedItem.slotid;
                item.transform.SetParent(inv.slots[dropedItem.slotid].transform);
                item.transform.position = inv.slots[dropedItem.slotid].transform.position;

                dropedItem.slotid = id;
                dropedItem.transform.SetParent(this.transform);
                dropedItem.transform.position = this.transform.position;

                inv.items[dropedItem.slotid] = item.GetComponent<ItemData>().item;
                inv.items[id] = dropedItem.item;
            }
        }
        else if (dropedItem.item.Equipable == 1)
        {
            Debug.Log("armor");
            if (inv.items[id].ID == -1 && inv.slots[id].GetComponent<ItemSlot>().id == 1 || inv.items[id].ID == -1 && inv.slots[id].GetComponent<ItemSlot>().id > 2)
            {
                inv.items[dropedItem.slotid] = new Item();
                inv.items[id] = dropedItem.item;
                dropedItem.slotid = id;
            }
            else if (dropedItem.slotid != id)
            {
                Transform item = this.transform.GetChild(0);
                item.GetComponent<ItemData>().slotid = dropedItem.slotid;
                item.transform.SetParent(inv.slots[dropedItem.slotid].transform);
                item.transform.position = inv.slots[dropedItem.slotid].transform.position;

                dropedItem.slotid = id;
                dropedItem.transform.SetParent(this.transform);
                dropedItem.transform.position = this.transform.position;

                inv.items[dropedItem.slotid] = item.GetComponent<ItemData>().item;
                inv.items[id] = dropedItem.item;
            }
        }
        else if (dropedItem.item.Equipable == 2)
        {
            Debug.Log("artifact");
            if (inv.items[id].ID == -1 && inv.slots[id].GetComponent<ItemSlot>().id == 2 || inv.items[id].ID == -1 && inv.slots[id].GetComponent<ItemSlot>().id > 2)
            {
                inv.items[dropedItem.slotid] = new Item();
                inv.items[id] = dropedItem.item;
                dropedItem.slotid = id;
            }
            else if (dropedItem.slotid != id)
            {
                Transform item = this.transform.GetChild(0);
                item.GetComponent<ItemData>().slotid = dropedItem.slotid;
                item.transform.SetParent(inv.slots[dropedItem.slotid].transform);
                item.transform.position = inv.slots[dropedItem.slotid].transform.position;

                dropedItem.slotid = id;
                dropedItem.transform.SetParent(this.transform);
                dropedItem.transform.position = this.transform.position;

                inv.items[dropedItem.slotid] = item.GetComponent<ItemData>().item;
                inv.items[id] = dropedItem.item;
            }
        }
        else if (dropedItem.item.Equipable > 2)
        {
            Debug.Log("item");
            if (inv.items[id].ID == -1 && inv.slots[id].GetComponent<ItemSlot>().id > 2)
            {
                inv.items[dropedItem.slotid] = new Item();
                inv.items[id] = dropedItem.item;
                dropedItem.slotid = id;
            }
            else if (dropedItem.slotid != id)
            {
                Transform item = this.transform.GetChild(0);
                item.GetComponent<ItemData>().slotid = dropedItem.slotid;
                item.transform.SetParent(inv.slots[dropedItem.slotid].transform);
                item.transform.position = inv.slots[dropedItem.slotid].transform.position;

                dropedItem.slotid = id;
                dropedItem.transform.SetParent(this.transform);
                dropedItem.transform.position = this.transform.position;

                inv.items[dropedItem.slotid] = item.GetComponent<ItemData>().item;
                inv.items[id] = dropedItem.item;
            }

        }
    }

}
