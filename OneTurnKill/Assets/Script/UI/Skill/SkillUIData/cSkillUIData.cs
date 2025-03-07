using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

//public enum SkillType { ACTIVE, PASSIVE }

[CreateAssetMenu(fileName = "SkillUIData", menuName = "ScriptableObject/SkillUIData")]
public class cSkillUIData : ScriptableObject
{
    public Sprite skillSprite;
    //public SkillType skillType;
}
