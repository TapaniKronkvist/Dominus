using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null)
        {
            Vector3 look = new Vector3(this.transform.position.x, Camera.main.transform.position.y,this.transform.position.z);
            transform.LookAt(Camera.main.transform.position);
        }
    }
}
