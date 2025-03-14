using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType { ACTIVE, PASSIVE }

[CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObject/SkillData")]
public class SkillData : ScriptableObject
{
    [Header("For_GameObject")]
    public GameObject skillEffect;
    public AnimationClip sklilAnim;
    public AudioClip skillSound;

    [Header("For_UI")]
    public string skillName;
    public string skillDesc;
    public Sprite skillSprite;
    public SkillType skillType;

    [Header("For_Enforce")]
    public int level = 0;
    public int[] enforceAmount = new int[5] { 2, 3, 4, 6, 10 };
}
