using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCollection : MonoBehaviour
{
    public Text chapter1;
    AudioSource source;
    public AudioClip clip;


    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        clip = GetComponent<AudioSource>().clip;

        chapter1.GetComponent<Text>().enabled = false;
    }

    public void OpenChapterOne()
    {
        if (chapter1.GetComponent<Text>().enabled == false)
        {
            chapter1.GetComponent<Text>().enabled = true;
            source.PlayOneShot(clip);
        }
        else
        {
            chapter1.GetComponent<Text>().enabled = false;
            source.PlayOneShot(clip);
        }
        
    }
}
