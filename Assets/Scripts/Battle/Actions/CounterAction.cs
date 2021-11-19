
using Cysharp.Threading.Tasks;

public class CounterAction : ITurnAction
{
    public int Priority { get; } = 1;
    public IActor Actor { get; set; }
    readonly int counterDamage;

    public CounterAction(IActor actor, int damage)
    {
        Actor = actor;
        counterDamage = damage;
    }
        
    public bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} はカウンターのじゅんびをしている！");
        return true;
    }

    public async UniTask Exec()
    {
        Actor.Buffs.Counter = counterDamage;
    }
}
