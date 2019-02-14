using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusDeathObject : MonoBehaviour
{
    [SerializeField]
    float timeUntilDeletion;
    [SerializeField] int vicSceneNum;


    void Start()
    {
        StartCoroutine(Thingy(timeUntilDeletion));
    }

    IEnumerator Thingy(float time)
    {


        yield return new WaitForSeconds(time);
        Destroy(WorldManager.ins.gameObject);
        Destroy(Playermanager.ins.gameObject);
        if (CollectionManager.ins != null)
        {
            CollectionManager.ins.AddCollectedToCollection();
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(vicSceneNum);
    }

}
