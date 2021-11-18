using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class SkillAction : ISkillAction
{
    public SkillMaster Id;

    public SkillInfo Info
    {
        get { return SkillService.SkillInfoMaster[Id]; }
    }

    public int Priority { get { return this.Info.Priority; } }

    public IActor Actor { get; set; }

    public IActor Target { get; set; }

    public abstract bool Prepare();
    public abstract UniTask Exec();
}
