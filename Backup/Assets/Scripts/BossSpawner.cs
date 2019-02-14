using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    GameObject newBoss;
    private void Start()
    {
        if (GetComponent<MeshRenderer>())
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void SpawnBoss(GameObject boss)
    {
         newBoss = Instantiate(boss);
        newBoss.SetActive(false);
        boss.transform.position = transform.position;
        boss.transform.rotation = transform.rotation;
    }

    public void ActivateBoss()
    {
        newBoss.SetActive(true);
    }

}
