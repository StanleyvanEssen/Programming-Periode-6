using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Collect : MonoBehaviour
{
    public enum StateType {Idle, Explore, Action, GoBack};
    [SerializeField]
    public StateType TheThingItShouldDo;
    public NavMeshAgent agent;
    public Transform destination;
    public Transform baseLocation;
    public bool change;
    public bool give;

    //Sets the StateType to Idle
    void Start ()
    {
        TheThingItShouldDo = StateType.Idle;
    }

    //Starts the statemachine
    void Update ()
    {
        DoIt();
    }

    //Set change to true, wait for an amount of time (given in StateType Idle), switch the state to StateType Explore and set change to false
    IEnumerator Please(float time)
    {
        change = true;
        yield return new WaitForSeconds(time);
        TheThingItShouldDo = StateType.Explore;
        change = false;
    }

    //Set change to true, wait for an amount of time (given in StateType GoBack), switch the state to StateType Explore and set change to false
    IEnumerator PleaseTheSequel(float time)
    {
        change = true;
        yield return new WaitForSeconds(time);
        TheThingItShouldDo = StateType.GoBack;
        change = false;
    }

    public virtual void DoIt()
    {
        //If give is false and the state is not Action than give will be true (which will change something in the scripts "PlusMetal" and "PlusWood"
        if (!give && TheThingItShouldDo != StateType.Action)
            give = true;
        //If the state is Idle and if change is false than start the timer named "Please"
        if (TheThingItShouldDo == StateType.Idle)
        {
            if (!change)
            {
                StartCoroutine(Please(3));
            }
        }
        //If the state is Explore than start the nevmash and if it reaches "destination" than start the Action state
        else if (TheThingItShouldDo == StateType.Explore)
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(destination.position);
            if(Vector3.Distance(transform.position, destination.position) <= 1)
            {
                TheThingItShouldDo = StateType.Action;
            }
        }
        //If the state is Action and if change is true start the timer named "PleaseTheSequel"
        else if (TheThingItShouldDo == StateType.Action)
        {
            if (!change)
            {
                StartCoroutine(PleaseTheSequel(1));
            }
        }
        //If the state is GoBack than start the nevmash and if it reaches "baseLocation" than start the Idle state
        else if (TheThingItShouldDo == StateType.GoBack)
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(baseLocation.position);
            if (Vector3.Distance(transform.position, baseLocation.position) <= 1)
            {
                TheThingItShouldDo = StateType.Idle;
            }
        }
    }
}