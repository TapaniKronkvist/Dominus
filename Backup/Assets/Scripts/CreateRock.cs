using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRock : MonoBehaviour
{
    [SerializeField]
    FallingRock rock;
    [SerializeField]
    float height;
    [SerializeField]
    float cooldownMax;
    float cooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;//float är lika med tid passerat
        if (cooldown >= cooldownMax && Playermanager.ins.playerObject != null)
        {
            Instantiate(rock, new Vector3(Playermanager.ins.playerObject.transform.position.x, height, Playermanager.ins.playerObject.transform.position.z), transform.rotation);
            cooldown = 0;
        }
    }
}
