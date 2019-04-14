using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State[] states;

    private Dictionary<Type, State> stateDictionary = new Dictionary<Type, State>();
    public static State currentState;

    protected virtual void Awake()
    {
        foreach (State state in states)
        {
            State instance = Instantiate(state);
            instance.Initialize(this);
            stateDictionary.Add(instance.GetType(), instance);
            if (currentState == null)
                currentState = instance;
        }
        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    public void Transition<T>() where T : State
    {
        currentState.Exit();
        currentState = stateDictionary[typeof(T)];
        currentState.Enter();
    }

    void Update()
    {
        currentState.HandleUpdate();
    }
    public State getCurrentState()
    {
        return currentState;
    }
}
