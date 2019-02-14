using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusMovement : MonoBehaviour
{
    [SerializeField]
    Magnus magnus;
    [SerializeField]
    float stopRange;
    Vector3 toPlayer;
    Vector3 lookAtPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Playermanager.ins.playerObject != null && Vector3.Distance(transform.position, Playermanager.ins.playerObject.transform.position) < stopRange)
        {
            toPlayer = Playermanager.ins.playerObject.transform.position - transform.position;
            transform.Translate(toPlayer.normalized * magnus.moveSpeed * Time.deltaTime * -1, Space.World);
            transform.LookAt(new Vector3(Playermanager.ins.playerObject.transform.position.x, transform.position.y, Playermanager.ins.playerObject.transform.position.z));
        }
        else if (Playermanager.ins.playerObject != null)
        {
            toPlayer = Playermanager.ins.playerObject.transform.position - transform.position;
            transform.Translate(toPlayer.normalized * magnus.moveSpeed * Time.deltaTime, Space.World);
            transform.LookAt(new Vector3(Playermanager.ins.playerObject.transform.position.x, transform.position.y, Playermanager.ins.playerObject.transform.position.z));
        }
    }
}
