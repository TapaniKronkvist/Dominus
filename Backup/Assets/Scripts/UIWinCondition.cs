using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWinCondition : MonoBehaviour
{
    public Image panel;
    public Text gameOver;
    public Text victory;

     // Start is called before the first frame update
    void Start()
    {
        panel.enabled = false;
        gameOver.enabled = false;
        victory.enabled = false; 
    }

    public void EnableGameOverSplash()
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
