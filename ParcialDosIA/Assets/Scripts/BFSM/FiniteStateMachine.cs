using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    IStates _currentState;
    Dictionary<MyEnum, IStates> _allStates = new Dictionary<MyEnum, IStates>();

    public void Update()
    {
        _currentState.OnUpdate();
    }

    public void ChangeState(MyEnum state)
    {
        if (_currentState != null)
            _currentState.OnExit();
        _currentState = _allStates[state];
        _currentState.OnEnter();
    }

    public void AddState(MyEnum key, IStates value)
    {
        if (!_allStates.ContainsKey(key))
            _allStates.Add(key, value);
        else
            _allStates[key] = value;
    }
}
