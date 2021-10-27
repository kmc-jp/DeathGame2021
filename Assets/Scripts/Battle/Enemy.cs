using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor
{
    public Enemy(string _name, Status _status)
    {
        this.Name = _name;
        this.Status = _status;
    }
}
