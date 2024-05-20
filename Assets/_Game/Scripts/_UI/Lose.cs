using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : UICanvas
{
    public void GiveUpButton()
    {
        UIManager.Ins.CloseAll();
        GameManager.Ins.ChangeState(GameState.MainMenu);
    }

    public void RestartButton()
    {
        GameManager.Ins.ChangeState(GameState.Gameplay);
        LevelManager.Ins.OnRetry();
        Close(0);
    }
}
