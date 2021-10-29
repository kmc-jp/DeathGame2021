using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : Actor
{
    private Image StatusPanel;

    public List<SkillMaster> Skills;

    public Player(string _name, Status _status, Image _statusPanel, List<SkillMaster> _skills)
    {
        this.Name = _name;
        this.Status = _status;
        this.StatusPanel = _statusPanel;
        this.Skills = _skills;
    }

    public override void DealDamage(int value)
    {
        base.DealDamage(value);
        if (value <= 0) return;
        DamageEffect();
    }

    public void DamageEffect()
    {
        this.StatusPanel.DOColor(Color.red, 0.2f).SetLoops(4, LoopType.Yoyo);
    }
}
