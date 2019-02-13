using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockParticles : MonoBehaviour
{
    float timer = 0;
    [SerializeField]
    ParticleSystem system;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;//float är lika med tid passerat
        if (timer >= 0.5f)
        {
            system.Stop();
        }
        if (timer >= 3f)
        {
            Destroy(gameObject);
        }
    }

}
