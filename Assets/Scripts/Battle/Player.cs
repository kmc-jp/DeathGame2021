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
        if (value <= 0) return;
        base.DealDamage(value);
        DamageEffect();
    }

    public void DamageEffect()
    {
        DOTween.Restart(this.StatusPanel);
        this.StatusPanel.DOKill(true);
        this.StatusPanel.DOColor(Color.red, 0.2f).SetLoops(4, LoopType.Yoyo);
        BattleManager.Instance.PlayDamageSE();
    }

    public Tweener SelectCommandEffect()
    {
        DOTween.Restart(this.StatusPanel);
        this.StatusPanel.DOKill(true);
        return this.StatusPanel.DOColor(new Color(1.0f, 1.0f, 0.6f, 1.0f), 0.7f).SetLoops(-1, LoopType.Yoyo);
    }
}
