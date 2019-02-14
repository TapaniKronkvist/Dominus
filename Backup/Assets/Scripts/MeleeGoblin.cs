using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeGoblin : Goblin
{
    [SerializeField]
    float meleeRange;

    protected override void Update()
    {

        if (Playermanager.ins.playerObject != null && Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < range)
        {
            if (cooldown < cooldownMax)
            {
                cooldown += Time.deltaTime;
                Debug.Log(cooldown);
            }
            else
            {
                Debug.Log("Pre move");
                if (Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < range)
                {
                    transform.LookAt(new Vector3(Playermanager.ins.playerObject.transform.position.x, transform.position.y, Playermanager.ins.playerObject.transform.position.z));
                    toPlayer = Playermanager.ins.playerObject.transform.position - transform.position;
                    transform.Translate(toPlayer.normalized * moveSpeed * Time.deltaTime, Space.World);
                    if (Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < meleeRange)
                    {
                        Attack();
                        Debug.Log("Attacki g");
                        cooldown = 0;
                        Debug.Log(cooldown);
                    }
                }

            }

        }

    }
    void Attack()
    {
        //Damage
        DamagePlayer();
        KnockBackPlayer();

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, meleeRange);
    }

    public override void OnCollisionEnter(Collision collision)
    {
     //   base.OnCollisionEnter(collision);
    }
}
