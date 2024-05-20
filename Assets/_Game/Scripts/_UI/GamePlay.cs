using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : UICanvas
{
    public void PausedButton()
    {
        UIManager.Ins.OpenUI<Paused>();
        GameManager.Ins.ChangeState(GameState.Pause);
    }
}
