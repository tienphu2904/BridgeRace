using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bot : CharacterObject
{
    private NavMeshAgent agent;
    private Vector3 destionation;
    public bool IsDestination => Vector3.Distance(destionation, Vector3.right * Tf.position.x + Vector3.forward * Tf.position.z) < 0.1f;
    IState<Bot> currentState;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        ChangeState(new PatrolState());
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExcute(this);
            CanMove(Tf.position);
        }
    }

    public void SetDestination(Vector3 position)
    {
        agent.enabled = true;
        destionation = position;
        destionation.y = 0;
        agent.SetDestination(position);
    }

    public void ChangeState(IState<Bot> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    internal void MoveStop()
    {
        agent.enabled = false;
    }
}
