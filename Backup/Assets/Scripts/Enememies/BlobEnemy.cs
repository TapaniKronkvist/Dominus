using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobEnemy : Enemy
{
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float range;
    Vector3 toPlayer;

    private void Update()
    {

        
        if (Playermanager.ins.playerObject != null && Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < range)
        {
           
            toPlayer = Playermanager.ins.playerObject.transform.position - transform.position;
            transform.Translate(toPlayer.normalized * moveSpeed * Time.deltaTime, Space.World);
            transform.LookAt(  Playermanager.ins.playerObject.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Coliided");
        if (collision.gameObject.CompareTag("Player"))
        {
          //  Debug.Log("Was player");
            DamagePlayer();
            KnockBackPlayer();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
