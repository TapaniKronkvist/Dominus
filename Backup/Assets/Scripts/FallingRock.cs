using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    [SerializeField]
    int damage;
    [SerializeField]
    float force, knockback;
    [SerializeField]
    ParticleSystem particles;
    [SerializeField]
    LayerMask mask;
    [SerializeField]
    GameObject shadow;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity, mask))
        {
            shadow.transform.position = hit.point;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        //Debug.Log("Coliided");
        if (collision.gameObject.CompareTag("Player"))
        {
            //  Debug.Log("Was player");
            Playermanager.ins.DamagePlayer(damage);
            Playermanager.ins.playerObject.GetComponent<PlayerMovement>().KnockBackPlayer(force, transform.position);
            Playermanager.ins.playerObject.GetComponent<PlayerMovement>().StunPlayer(knockback);
            
        }
        Instantiate(particles, transform.position, transform.rotation);
            Destroy(gameObject);
    }
}
