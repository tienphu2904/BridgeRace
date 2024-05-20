using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorObject : GameUnit
{
    public ColorType colorType = ColorType.None;

    [SerializeField] private ColorData colorData;
    [SerializeField] private Renderer render;

    public void ChangeColor(ColorType colorType)
    {
        this.colorType = colorType;
        render.material = colorData.GetMat(colorType);
    }
}
