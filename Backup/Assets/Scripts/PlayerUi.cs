using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    
    Image createHeart;
    public Image heart;
    Playermanager getPlayerInfo;
    [SerializeField] int playerHp;
    //public int testhealth = 8;
    GameObject player;
    Vector3 xOffset;
    float x = 50;
    float yOffset;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        getPlayerInfo = Playermanager.ins;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playerHp = getPlayerInfo.CurrentHP;
            print(playerHp);
            createHeart = Instantiate(heart) as Image;
            createHeart.transform.SetParent(transform, false);//keeps local pos
        }
        

        
    }
    public void UpdateHealth(int hp)
    {
        for (int i = 0; i < hp; i++)
        {
            
                createHeart = Instantiate(heart) as Image;
                createHeart.transform.SetParent(transform, false);//keeps local pos
                xOffset = createHeart.transform.position;
                xOffset.x += x;
                createHeart.transform.position = xOffset;
                x += 100;
        }
        
    }
}
