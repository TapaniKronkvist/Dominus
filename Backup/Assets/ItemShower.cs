using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemShower : MonoBehaviour
{
    Pickup pickup;
    [SerializeField]
    ItemCollectionUI ui;
    [SerializeField]
    Pickup test;
    GameObject showObject;

    private void OnMouseDown()
    {
        if (pickup != null)
        {
            Debug.Log(pickup.itemName);
            ui.SetText(pickup);
        }
    }
    public void ClearShowers()
    {
        Destroy(showObject);
    }

    public Pickup Pickup
    {
        get => pickup;
        set
        {

            Destroy(showObject);
            showObject = Instantiate(value.WorldObject, transform);
            showObject.transform.position = transform.position;
            pickup = value;


        }
    }

}
