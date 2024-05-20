using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelItemUI : MonoBehaviour
{
    [SerializeField] private Button selectLevelButton;
    [SerializeField] private GameObject topPath, bottomPath, focusEffect;
    [SerializeField] private TextMeshProUGUI mapText;
    private MapItemData mapItemData;
    public MapItemData MapItemData { get => mapItemData; set => mapItemData = value; }

    private void Start()
    {
        selectLevelButton.onClick.AddListener(() =>
        {
            OnSelectLevelButtonHandle();
        });
    }

    public void Setup(MapItemData mapItemData,
                        Boolean isHideTopPath,
                        Boolean isHideBottmPath)
    {
        SetupUI(mapItemData, isHideTopPath, isHideBottmPath);
        MapItemData = mapItemData;
    }

    private void SetupUI(MapItemData mapItemData,
                            Boolean isHideTopPath,
                            Boolean isHideBottmPath)
    {
        topPath.SetActive(!isHideTopPath);
        bottomPath.SetActive(!isHideBottmPath);
        mapText.text = (mapItemData.id + 1).ToString();
    }

    public void setFocus(Boolean isFocus)
    {
        focusEffect.SetActive(isFocus);
    }

    private void OnSelectLevelButtonHandle()
    {
        Debug.Log($"map {mapItemData.id}");
        PlayerPrefs.SetInt("Level", mapItemData.id);
    }
}
