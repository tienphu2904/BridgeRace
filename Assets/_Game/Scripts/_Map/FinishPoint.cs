using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.Tag_Character))
        {
            GameManager.Ins.ChangeState(GameState.Lose);
            UIManager.Ins.OpenUI<Lose>();
        }
        if (other.CompareTag(Constants.Tag_Player))
        {
            GameManager.Ins.ChangeState(GameState.Win);
            UIManager.Ins.OpenUI<Win>();
        }
    }
}
