using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private EnemyState[] states;

    private Dictionary<Type, EnemyState> stateDictionary = new Dictionary<Type, EnemyState>();
    public static EnemyState currentState;

    protected virtual void Awake()
    {
        foreach (EnemyState state in states)
        {
            EnemyState instance = Instantiate(state);
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

    public void Transition<T>() where T : EnemyState
    {
        currentState.Exit();
        currentState = stateDictionary[typeof(T)];
        currentState.Enter();
    }

    void Update()
    {
        currentState.HandleUpdate();
    }
    public EnemyState getCurrentState()
    {
        return currentState;
    }
}