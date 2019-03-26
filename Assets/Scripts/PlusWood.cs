using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusWood : Collect
{
    public int wood;

    //Overrides the void DoIt from the Collect script, if the state is Action and give is true than your wood value increases and than sets give to false
    public override void DoIt()
    {
        base.DoIt();
        if (TheThingItShouldDo == StateType.Action && give)
        {
            wood += 1;
            give = false;
        }
    }
}