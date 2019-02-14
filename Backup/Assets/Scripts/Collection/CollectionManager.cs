using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
public class CollectionManager : MonoBehaviour
{
    [SerializeField]
    List<Pickup> collectedItems = new List<Pickup>(), pickedUpDuringGame;
    [SerializeField]
    List<string> itemPaths = new List<string>();
    [SerializeField]
    string itemLoc;

    public static CollectionManager ins;



    public List<Pickup> CollectedItems
    {
        get => collectedItems;
    }

    private void Start()
    {
        if (CollectionManager.ins == null)
        {
            CollectionManager.ins = this;
            DontDestroyOnLoad(gameObject);
            LoadItemsFromFile();
        }
        else Destroy(gameObject);
    }

    public void SaveItemsToFile()
    {
        itemPaths = new List<string>();
        for (int i = 0; i < collectedItems.Count; i++)
        {
            itemPaths.Add(collectedItems[i].name);
        }

        FileStream fs = new FileStream("ItemCollection", FileMode.Create);
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
        xmlSerializer.Serialize(fs, itemPaths);
        fs.Close();

    }
    public void LoadItemsFromFile()
    {
        if (File.Exists("ItemCollection"))
        {
            FileStream fs = new FileStream("ItemCollection", FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<string>));
            List<string> strings = xmlSerializer.Deserialize(fs) as List<string>;
            itemPaths = strings;
            fs.Close();
            for (int i = 0; i < itemPaths.Count; i++)
            {
                if (Resources.Load(itemLoc + "/" + itemPaths[i]))
                {
                    Pickup pickup = Resources.Load(itemLoc + "/" + itemPaths[i]) as Pickup;
                    if (!collectedItems.Contains(pickup))
                    {
                        collectedItems.Add(pickup);
                    }

                }
            }
        }
        else Debug.Log("No file");

    }

    public void AddCollectedToCollection()
    {
        for (int i = 0; i < pickedUpDuringGame.Count; i++)
        {
            if (!collectedItems.Contains(pickedUpDuringGame[i]))
            {
                collectedItems.Add(pickedUpDuringGame[i]);
            }
        }
        SaveItemsToFile();
    }

    public void PickedUpItem(Pickup pickup)
    {
        pickedUpDuringGame.Add(pickup);
    }

}
