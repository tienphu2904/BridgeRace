using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrick : ColorObject
{
    public Stage stage;

    public void OnDespawn()
    {
        stage.RemoveBrick(this);
    }
}
