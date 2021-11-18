
using Cysharp.Threading.Tasks;
using UniRx;

public class DoubleAction : ITurnAction
{
    readonly ITurnAction first;
    readonly ITurnAction second;
    
    // 2会の行動が連続して起こる前提で横着している
    public DoubleAction(ITurnAction first, ITurnAction second)
    {
        this.first = first;
        this.second = second;
        this.Actor = first.Actor;
        this.Priority = first.Priority;
    }
    
    public int Priority { get; }
    public IActor Actor { get; set; }

    public bool Prepare() => first.Prepare();

    public async UniTask Exec()
    {
        await first.Exec();

        if (second.Prepare())
        {
            await MessageWindow.Instance.CloseObservable.First();
        }

        await second.Exec();
    }
}