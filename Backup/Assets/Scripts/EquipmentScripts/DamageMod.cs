using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageMod", menuName = "Equipment/DamageMod", order = 1)]
public class DamageMod : Equipment
{
    [SerializeField]
    float modifier;


    public override void ChangePlayerStats()
    {

        Playermanager.ins.damageModifier *= modifier;
    }
}
