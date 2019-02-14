using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollectionUI : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text descriptionText;
    [SerializeField] Text pageText;
    [SerializeField] int mainMenuSceneNum;
    [SerializeField]
    List<ItemShower> showers = new List<ItemShower>();
    int currentPage;
    List<Pickup> itemsToShow = new List<Pickup>();

    int ShowerNumber { get => showers.Count; }
    List<Pickup> items { get => CollectionManager.ins.CollectedItems; }

    void ShowPage(int page)
    {
        if (page >= 0 && page * ShowerNumber +1 <= items.Count)
        {
            for (int i = 0; i < showers.Count; i++)
            {
                showers[i].ClearShowers();
            }
            currentPage = page;
            for (int i = 0; i < ShowerNumber; i++)
            {
                if (items.Count > i + ShowerNumber * page)
                {
                    showers[i].Pickup = items[i + ShowerNumber * page];
                }
            }
        }
    }

    public void NextPage()
    {
        ShowPage(currentPage + 1);
    }
    public void PrevPage()
    {
        ShowPage(currentPage - 1);
    }

    public void SetText(Pickup pickup)
    {
        nameText.text = pickup.itemName;
        descriptionText.text = pickup.description;
    }

    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(mainMenuSceneNum);
    }

    private void Start()
    {
        ShowPage(0);
    }
    private void Update()
    {
        pageText.text = (currentPage + 1).ToString();
    }
}
