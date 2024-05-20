using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState<Bot>
{
    int targetBrick;
    public void OnEnter(Bot t)
    {
        t.ChangeAnim(Constants.Anim_Run);
        targetBrick = Random.Range(6, 10);
        SeekTarget(t);
    }

    public void OnExcute(Bot t)
    {
        if (t.IsDestination)
        {
            if (t.BrickCount >= targetBrick)
            {
                t.ChangeState(new AttackState());
            }
            else
            {
                SeekTarget(t);
            }
        }
    }

    public void OnExit(Bot t)
    {
    }

    private void SeekTarget(Bot t)
    {
        if (t.stage != null)
        {
            PlayerBrick brick = t.stage.SeekBrickPoint(t.colorType);

            if (brick == null)
            {
                t.ChangeState(new AttackState());
            }
            else
            {
                t.SetDestination(brick.Tf.position);
            }
        }
        else
        {
            t.ChangeState(new AttackState());
        }
    }

}
