using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnus : Enemy
{
    public float moveSpeed;
    public float shootRange;
    [SerializeField]
    float nrOfShots;
    [SerializeField]
    float offsetAngle;
    [SerializeField]
    GameObject projectilePrefab;
    [SerializeField]
    protected float cooldownMax;
    protected float cooldown;
    //[SerializeField]
    //Vector3 playeroffset;

    // Start is called before the first frame update
    public override void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Playermanager.ins.playerObject != null && Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < shootRange)
        {
            Shoot();
        }
        if (cooldown <= cooldownMax)
        {
            cooldown += Time.deltaTime;
        }
    }
    void Shoot()
    {
        if (cooldown >= cooldownMax)
        {
            Vector3 projectilePosition = new Vector3(transform.position.x, Playermanager.ins.playerObject.transform.position.y, transform.position.z);
            GameObject shot = Instantiate(projectilePrefab, projectilePosition, transform.rotation);
            for (int i = 0; i < nrOfShots; i++)
            {
                GameObject shots = Instantiate(projectilePrefab, projectilePosition, transform.rotation);
                shot.GetComponent<Arrow>().lookDir = Quaternion.Euler(0, offsetAngle * (i + 1), 0) * transform.forward;

                shots = Instantiate(projectilePrefab, projectilePosition, transform.rotation);
                shots.GetComponent<Arrow>().lookDir = Quaternion.Euler(0, -offsetAngle * (i + 1), 0) * transform.forward;
            }
            cooldown = 0;
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
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }
}
