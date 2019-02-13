using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeath : MonoBehaviour
{
    [SerializeField]
    WorldManager.Bosses beatenBoss;
    [SerializeField]
    float timeTillDone, beamUpSpeed;
    [SerializeField]
    LineRenderer line;

    private void Start()
    {
        StartCoroutine(BossDead(timeTillDone));
    }

    private void Update()
    {
        line.SetPosition(1, line.GetPosition(1) + new Vector3(0, beamUpSpeed * Time.deltaTime, 0));
    }

    IEnumerator BossDead(float time)
    {
        yield return new WaitForSeconds(time);
        WorldManager.ins.DefeatBoss(beatenBoss);
    }


}
