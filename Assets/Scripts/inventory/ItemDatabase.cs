using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class ItemDatabase : MonoBehaviour {
    private List<Item> database = new List<Item>();
    private JsonData itemData;

    void Start()
    {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
    }

    public Item FetchItemByID(int id)
    {
        for (int i =0; i < database.Count; i++)
        {
            if (database[i].ID == id)
            {
                return database[i];
            }
        }
        return null;
    }

    void ConstructItemDatabase()
    {
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], itemData[i]["name"].ToString(), (int)itemData[i]["value"], 
            (int)itemData[i]["stats"]["power"], (int)itemData[i]["stats"]["regeneration"], (int)itemData[i]["stats"]["mpower"],
            (int)itemData[i]["equipable"],itemData[i]["description"].ToString(), (bool)itemData[i]["stack"], itemData[i]["slug"].ToString()));

        }
    } 
}

public class Item
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
    public int Power { get; set; }
    public int Regeneration { get; set; }
    public int Mpower { get; set; }
    public int Equipable { get; set; }
    public string Description { get; set; }
    public bool Stack { get; set; }
    public string Slug {get; set; }
    public Sprite Sprite { get; set; }

    public Item(int id, string name, int value, int power, int regeneration, int mpower, int equipable,string discription, bool stack, string slug)
    {
        this.ID = id;
        this.Name = name;
        this.Value = value;
        this.Power = power;
        this.Regeneration = regeneration;
        this.Mpower = mpower;
        this.Equipable = equipable;
        this.Description = discription;
        this.Stack = stack;
        this.Slug = slug;
        this.Sprite = Resources.Load<Sprite>("Sprites/Items/" + slug);

    }

    public Item()
    {
        this.ID = -1;
    }
}