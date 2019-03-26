using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusMetal : Collect
{
    public int metal;

    //Overrides the void DoIt from the Collect script, if the state is Action and give is true than your metal value increases and than sets give to false
    public override void DoIt()
    {
        base.DoIt();
        if (TheThingItShouldDo == StateType.Action && give)
        {
            metal += 1;
            give = false;
        }
    }
}