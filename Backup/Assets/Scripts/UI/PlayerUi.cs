﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    
    Image createHeart;
    public Image heart;
    public Image maxHeart;
    public List<Image> maxHearts;
    Playermanager getPlayerInfo;
    public List<Image> currentHearts;
    [SerializeField] int playerHp;
    private int hpChange = 4;
    private int hp;
    private GameObject player;
    private Vector3 xOffset;
    private float x = 50;
    private float yOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        getPlayerInfo = Playermanager.ins; 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (getPlayerInfo != null)
        {
            hp = getPlayerInfo.CurrentHP;
            hpChange = hp;
            if (hpChange != playerHp)
            {
                UpdateHealth(hp);
            }

        }
    }
    public void UpdateHealth(int hp)
    {
        foreach (var item in maxHearts)
        {
            Destroy(item);
        }

        foreach (var item in currentHearts)
        {
            Destroy(item);
        }
        currentHearts = new List<Image>();
        x = 50;

        for (int i = 0; i < Playermanager.ins.MaxHP; i++)
        {
            createHeart = Instantiate(maxHeart) as Image;
            maxHearts.Add(createHeart);
            createHeart.transform.SetParent(transform, false);//keeps local pos
            xOffset = createHeart.transform.position;
            xOffset.x += x * i;
            createHeart.transform.position = xOffset;

        }

        for (int i = 0; i < hp; i++)
        {
            createHeart = Instantiate(heart) as Image;
            currentHearts.Add(createHeart);
            createHeart.transform.SetParent(transform, false);//keeps local pos
            xOffset = createHeart.transform.position;
            xOffset.x += x * i;
            createHeart.transform.position = xOffset;
          //  x += 50;
        }
        playerHp = hpChange;
    }
}
