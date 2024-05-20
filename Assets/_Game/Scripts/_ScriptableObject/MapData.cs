using System;
using System.Collections.Generic;
using UnityEngine;

public enum MapStatus { Open, Selected, Locked }

[Serializable]
public struct MapItemData
{
    public int id;
    public MapStatus mapStatus;
    public Map prbMap;
}

[CreateAssetMenu(menuName = "My Assets/Map Data")]
public class MapData : ScriptableObject
{
    public List<MapItemData> mapItemDataList;
}
