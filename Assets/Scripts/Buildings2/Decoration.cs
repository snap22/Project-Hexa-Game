using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration : Building
{
    public Decoration(string name, int goldcost) : base(name, goldcost, 0, 0, 0, 0, 0)
    {

    }
    public override void DoStuff(Player player)
    {
        // do nothing
    }

    public override string GetDescription()
    {
        return string.Format("This fancy {0} costed {1} golds", base.name, base.goldCost);
    }

}
