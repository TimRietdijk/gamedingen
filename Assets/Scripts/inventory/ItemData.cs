using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler {
    public int amount;
    public int slotid;

    public GameObject Player;
    public GameObject Character;
    public GameObject Inventory;
    public GameObject InvCanvas;
    public GameObject Tooltip;

    public Item item;
    public Inventory inv;
    public Tooltip tooltip;

    public void Start()
    {
        Player = this.transform.parent.parent.parent.parent.parent.gameObject;
        Character = Player.transform.FindChild("Character" + Player.name).gameObject;
        Inventory = Player.transform.FindChild("Inventory").gameObject;
        InvCanvas = Player.transform.FindChild("Canvas").gameObject;
        Tooltip = InvCanvas.transform.FindChild("Tooltip").gameObject;
        inv = Inventory.GetComponent<Inventory>();
        tooltip = Tooltip.GetComponent<Tooltip>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.SetParent(this.transform.parent.parent.parent);
            this.transform.position = eventData.position;
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(inv.slots[slotid].transform);
        this.transform.position = inv.slots[slotid].transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("entering");
        tooltip.Activate(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("leaving"); 
        tooltip.Deactivate();
    }
}
