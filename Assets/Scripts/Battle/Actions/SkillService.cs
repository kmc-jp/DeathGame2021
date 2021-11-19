using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SkillMaster
{
    NormalAttack,
    EnhancedAttackP,
    EnhancedAttackB,
    Heal,
    HighHeal,
    FullHeal,
    Cover,
    AtkBuff,
    HealBuff,
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
    public static readonly Dictionary<SkillMaster, SkillInfo> SkillInfoMaster = new Dictionary<SkillMaster, SkillInfo>(){
        { SkillMaster.NormalAttack,    new SkillInfo("通常攻撃", 0, 0, true) },
        { SkillMaster.EnhancedAttackP, new SkillInfo("はやぶさ斬り", 5, 0, true) },
        { SkillMaster.EnhancedAttackB, new SkillInfo("ブレイドリコール", 15, 0, true) },
        { SkillMaster.Heal,            new SkillInfo("ケア", 5, 0, false) },
        { SkillMaster.HighHeal,        new SkillInfo("ケアル", 7, 0, false) },
        { SkillMaster.FullHeal,        new SkillInfo("ケアルガ", 10, 0, false) },
        { SkillMaster.Cover,           new SkillInfo("身代わり", 0, 1, false) },
        { SkillMaster.AtkBuff,         new SkillInfo("攻撃バフ", 30, 1, false) },
        { SkillMaster.HealBuff,        new SkillInfo("回復バフ", 30, 1, false) },
    };

    public static List<ITurnAction> MakeSkillAction(SkillMaster skillId, IActor actor, IActor target)
    {
        List<ITurnAction> actions = new List<ITurnAction>();
        // あとで何とかするかも
        switch(skillId)
        {
            case SkillMaster.NormalAttack:
                actions.Add(new AttackAction(actor, target, new AttackDamageFromStatus()));
                break;
            case SkillMaster.EnhancedAttackP:
            case SkillMaster.EnhancedAttackB:
                var en = new EnhancedAttackSkillAction(actor, target);
                en.Id = skillId;
                actions.Add(en);
                break;
            case SkillMaster.Heal:
            case SkillMaster.HighHeal:
            case SkillMaster.FullHeal:
                var he = new HealSkillAction(actor, target);
                he.Id = skillId;
                actions.Add(he);
                break;
            case SkillMaster.Cover:
                actions.Add(new CoverSkillAction(actor, target));
                break;
            case SkillMaster.AtkBuff:
                actions.Add(new AtkBuffSkillAction(actor, target));
                break;
            case SkillMaster.HealBuff:
                actions.Add(new HealBuffSkillAction(actor, target));
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
