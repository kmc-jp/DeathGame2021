using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject HealthBarImage;
    [SerializeField]
    private Image EnemyImage;

    public IEnemy EnemyCore;

    public void UpdateHealthBar()
    {
        float healthRate = (float)EnemyCore.Status.Hp / EnemyCore.Status.MaxHp;
        HealthBarImage.transform.localScale = new Vector3(healthRate, 1.0f, 1.0f);
    }

    public void DamageEffect()
    {
        DOTween.Restart(this.EnemyImage);
        this.EnemyImage.DOKill(true);
        this.EnemyImage.DOColor(Color.red, 0.2f).SetLoops(4, LoopType.Yoyo);
        BattleManager.Instance.PlayDamageSE();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
