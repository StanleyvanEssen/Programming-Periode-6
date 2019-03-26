using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TEST SCRIPT
public class LoopScript : MonoBehaviour
{
    enum LoopBoi {One, Two, Three, Four};
    LoopBoi itsALoop;

    void Start ()
    {
        itsALoop = LoopBoi.One;
    }

    void Update()
    {
        LoopsBrother();
    }

    void LoopsBrother()
    {
        if (itsALoop == LoopBoi.One)
        {
            itsALoop = LoopBoi.Two;
            Debug.Log("u gay");
        }
        else if (itsALoop == LoopBoi.Two)
        {
            itsALoop = LoopBoi.Three;
            Debug.Log("u gay the sequel");
        }
        else if (itsALoop == LoopBoi.Three)
        {
            itsALoop = LoopBoi.Four;
            Debug.Log("u gay the prequel sequel");
        }
        else if (itsALoop == LoopBoi.Four)
        {
            itsALoop = LoopBoi.One;
            Debug.Log("u gay the final chapter");
        }
    }
}