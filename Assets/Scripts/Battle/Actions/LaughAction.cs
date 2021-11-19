
using Cysharp.Threading.Tasks;

public class LaughAction : ITurnAction
{
    public int Priority { get; } = -1;
    public IActor Actor { get; set; }

    public LaughAction(IActor actor)
    {
        this.Actor = actor;
    }
    
    public bool Prepare()
    {
        if (Actor.IsDead) return false;
        MessageWindow.Instance.MakeWindow($"{Actor.Name} は笑っている！");
        return true;
    }

    public UniTask Exec()
    {
        return UniTask.CompletedTask;
    }
}