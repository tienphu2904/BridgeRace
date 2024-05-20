using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UICanvas
{
    public void PlayButton()
    {
        UIManager.Ins.OpenUI<GamePlay>();
        GameManager.Ins.ChangeState(GameState.Gameplay);
        LevelManager.Ins.LoadLevel(PlayerPrefs.GetInt("Level", 0));
        Close(0);
    }

    public void SettingButton()
    {
        UIManager.Ins.OpenUI<Setting>();
    }
}
