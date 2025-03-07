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
}
