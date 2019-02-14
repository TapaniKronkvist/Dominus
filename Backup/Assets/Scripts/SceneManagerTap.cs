using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Managing scene transitions.
//Written by Tapani Kronkvist
public class SceneManagerTap : MonoBehaviour
{
    public Image background;
    public Image controller;
    public Text left;
    public Text right;
    public Text howTo;
    public float waitTime;

    void Start()
    {
        howTo.enabled = false;
        background.enabled = false;
        controller.enabled = false;
        left.enabled = false;
        right.enabled = false;
        
    }
    public void StartNewGame()
    {

        WorldManager.ins.LoadOverWorld();

        howTo.enabled = true;
        left.enabled = true;
        right.enabled = true;
        background.enabled = true;
        controller.enabled = true;
        Invoke("StartNow", waitTime * Time.deltaTime);


    }
    public void Options()
    {
        Application.LoadLevel("Options");
    }

    void StartNow()
    {
        Application.LoadLevel("Overworld");
    }
    public void backToMain()
    {
        Application.LoadLevel("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Collection()
    {
        Application.LoadLevel("Collection");
    }
}
