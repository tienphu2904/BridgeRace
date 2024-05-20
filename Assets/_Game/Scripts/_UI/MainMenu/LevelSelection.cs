using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private MapData mapData;
    [SerializeField] private LevelItemUI prblevelItemUI;

    private List<LevelItemUI> listlevelItemUI = new List<LevelItemUI>();

    private void Start()
    {
        SpawnListMap();
    }

    public void SpawnListMap()
    {
        for (int i = mapData.mapItemDataList.Count - 1; i >= 0; i--)
        {
            Boolean isHideBottmPath = i == 0;
            Boolean isHideTopPath = i == mapData.mapItemDataList.Count - 1;
            LevelItemUI lvlItemUI = Instantiate(prblevelItemUI, transform);
            lvlItemUI.Setup(mapData.mapItemDataList[i], isHideTopPath, isHideBottmPath);
            listlevelItemUI.Add(lvlItemUI);
        }
    }

    public void setFocus()
    {

    }
}
