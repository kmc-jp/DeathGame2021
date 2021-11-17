using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SkillMaster
{
    NormalAttack,
    EnhancedAttack,
    Heal,
    Cover,
}

public struct SkillInfo
{
    public string Name;
    public int Cost;
    public int Priority;
    public bool IsToEnemy;
    public SkillInfo(string name, int cost, int priority, bool isToEnemy)
    {
        Name = name;
        Cost = cost;
        Priority = priority;
        IsToEnemy = isToEnemy;
    }
}

public static class SkillService
{
    public static readonly Dictionary<SkillMaster, string> SkillNameMaster = new Dictionary<SkillMaster, string>(){
        { SkillMaster.NormalAttack,   "通常攻撃" },
        { SkillMaster.EnhancedAttack, "属性攻撃" },
        { SkillMaster.Heal,           "回復呪文" },
        { SkillMaster.Cover,          "身代わり" },
    };
    public static readonly Dictionary<SkillMaster, SkillInfo> SkillInfoMaster = new Dictionary<SkillMaster, SkillInfo>(){
        { SkillMaster.NormalAttack,   new SkillInfo("通常攻撃", 0, 1, true) },
        { SkillMaster.EnhancedAttack, new SkillInfo("属性攻撃", 0, 1, true) },
        { SkillMaster.Heal,           new SkillInfo("回復呪文", 0, 1, false) },
        { SkillMaster.Cover,          new SkillInfo("身代わり", 0, 1, false) },
    };

    public static List<ITurnAction> MakeSkillAction(SkillMaster skillId, IActor actor, IActor target)
    {
        List<ITurnAction> actions = new List<ITurnAction>();
        switch(skillId)
        {
            case SkillMaster.NormalAttack:
                actions.Add(new AttackAction(actor, target));
                break;
            case SkillMaster.EnhancedAttack:
                actions.Add(new EnhancedAttackSkillAction(actor, target));
                break;
            case SkillMaster.Heal:
                actions.Add(new HealSkillAction(actor, target));
                break;
            case SkillMaster.Cover:
                actions.Add(new CoverSkillAction(actor, target));
                break;
            default:
                Debug.Log("No Such Skill");
                break;
        }
        return actions;
    }

    /* 使わないかも
    public readonly Dictionary<SkillMaster, Type> SkillTypeMaster = new Dictionary<SkillMaster, Type>(){
        { SkillMaster.None, typeof(AttackAction) },
        { SkillMaster.Heal, typeof(HealSkillAction)},
        { SkillMaster.Cover, typeof(CoverSkillAction)},
    };
    */
}
