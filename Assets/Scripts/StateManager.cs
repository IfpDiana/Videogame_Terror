using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateManager : MonoBehaviour
{
    public State currentState;
    public NavMeshAgent agent;
    public Transform player;
    void Update()
    {
        RunStateMachine();
    }
    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();
        if (nextState != null)
        {
            SwitchToNextState(nextState);
        }
    }
    //private void Awake()
    //{
    //    agent = GetComponent<NavMeshAgent>();
    //}
    private void SwitchToNextState(State nextState)
    {
        currentState = nextState;
    }
}
