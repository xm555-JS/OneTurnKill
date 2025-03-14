using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cSKillDamage : MonoBehaviour
{
    [SerializeField] int damage;
    int levelDamage;

    public int Damage { get => damage; }
    public int LevelDamage { get => levelDamage; set => levelDamage = value; }
}
