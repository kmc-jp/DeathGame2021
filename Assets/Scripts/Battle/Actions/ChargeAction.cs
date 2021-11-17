
using Cysharp.Threading.Tasks;

public class ChargeAction : ITurnAction
{
    public int Priority { get; } = -1;
    public IActor Actor { get; set; }
    readonly float rate;

    public ChargeAction(float rate, IActor actor)
    {
        this.Actor = actor;
        this.rate = rate;
    }
    
    public bool Prepare()
    {
        MessageWindow.Instance.MakeWindow($"{Actor.Name} はちからをためている！");
        return true;
    }

    public UniTask Exec()
    {
        // 複数回重ねがけされる可能性があるけど掛け算でええんかな……
        Actor.Buffs.AttackRate *= rate;
        return UniTask.CompletedTask;
    }
}