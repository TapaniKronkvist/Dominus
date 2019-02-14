using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemShower : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Pickup pickup;
    [SerializeField]
    ItemCollectionUI ui;
    [SerializeField]
    Pickup test;
    GameObject showObject;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pickup = test;
        }
    }
    private void OnMouseDown()
    {
        Debug.Log(pickup.itemName);
        ui.SetText(pickup);
    }


    public Pickup Pickup
    {
        get => pickup;
        set
        {
            Debug.Log(value.itemName);
            Destroy(showObject);
            showObject = Instantiate(value.WorldObject, transform);
            showObject.transform.position = transform.position;
            pickup = value;


        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {

    }
}
