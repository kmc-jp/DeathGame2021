using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    public Player(string _name)
    {
        this.Name = _name;
        this.Status = new Status(100, 100, 20, 5, 5);
    }
}
