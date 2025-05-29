using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType { ACTIVE, PASSIVE }

[CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObject/SkillData")]
public class SkillData : ScriptableObject
{
    [Header("For_GameObject")]
    public GameObject skillEffect;

    [Header("For_UI")]
    public string skillName;
    public string skillDesc;
    public Sprite skillSprite;
    public SkillType skillType;

    [Header("For_Enforce")]
    public int level = 0;
    public int[] levelDamage = new int[5] { 1, 10, 20, 40, 60 };
    public int[] enforceAmount = new int[5] { 2, 3, 4, 6, 10 };
}
