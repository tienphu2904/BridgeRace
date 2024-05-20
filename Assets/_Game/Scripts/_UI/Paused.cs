using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paused : UICanvas
{
    public void ContinueButton()
    {
        GameManager.Ins.ChangeState(GameState.Gameplay);
        Close(0);
    }

    public void RestartButton()
    {
        GameManager.Ins.ChangeState(GameState.Gameplay);
        LevelManager.Ins.OnRetry();
        Close(0);
    }

    public void GiveUpButton()
    {
        UIManager.Ins.CloseAll();
        GameManager.Ins.ChangeState(GameState.MainMenu);
        LevelManager.Ins.OnReset();
    }
}
