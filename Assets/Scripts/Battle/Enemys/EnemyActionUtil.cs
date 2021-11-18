
using System.Linq;
using UnityEngine;

public class EnemyActionUtil
{
    public static Player SelectTarget()
    {
        Player[] liveTargets = BattleManager.Instance.playerList
            .Where(ally => !ally.IsDead)
            .ToArray();
        int targetIdx = Random.Range(0, liveTargets.Length);
        return liveTargets[targetIdx];
    }
}