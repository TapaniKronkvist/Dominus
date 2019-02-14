using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWinCondition : MonoBehaviour
{
    public static Image panel;
    public static Text gameOver;
    public static Text victory;

     // Start is called before the first frame update
    void Start()
    {
        panel.enabled = false;
        gameOver.enabled = false;
        victory.enabled = false; 
    }

    public static void EnableGameOverSplash()
    {
        panel.enabled = true;
        gameOver.enabled = true;
    }
    public void EnableVictorySplash()
    {
        panel.enabled = true;
        victory.enabled = true;
    }

}
