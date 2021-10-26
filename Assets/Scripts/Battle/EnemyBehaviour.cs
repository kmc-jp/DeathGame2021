using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject HealthBarImage;
    public Enemy EnemyCore{
        get;
        set;
    }
    // Start is called before the first frame update
    void Start()
    {
        this.EnemyCore = new Enemy(new Status(100, 100, 10, 5, 5));
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateHealthBar()
    {
        float healthRate = (float)EnemyCore.status.Hp / EnemyCore.status.MaxHp;
        HealthBarImage.transform.localScale = new Vector3(healthRate, 1.0f, 1.0f);
    }
}
