using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : UICanvas
{
    public void GiveUpButton()
    {
        UIManager.Ins.CloseAll();
        GameManager.Ins.ChangeState(GameState.MainMenu);
    }

    public void NextLevelButton()
    {
        LevelManager.Ins.OnNextLevel();
        GameManager.Ins.ChangeState(GameState.Gameplay);
        Close(0);
    }
}
