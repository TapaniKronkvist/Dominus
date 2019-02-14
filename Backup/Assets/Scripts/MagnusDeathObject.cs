using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusDeathObject : MonoBehaviour
{
    [SerializeField]
    float timeUntilDeletion;
    [SerializeField] int vicSceneNum;




    IEnumerator Thingy(float time)
    {


        yield return new WaitForSeconds(time);
        UnityEngine.SceneManagement.SceneManager.LoadScene(vicSceneNum);
    }

}
