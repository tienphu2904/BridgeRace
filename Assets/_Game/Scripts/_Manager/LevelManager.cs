using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class LevelManager : Singleton<LevelManager>
{
    readonly List<ColorType> colorTypes = new List<ColorType>() {
        ColorType.Red,
        ColorType.Blue,
        ColorType.Green,
        ColorType.Orange
    };

    public MapData MapList;
    public Map currentMap;
    public int CharacterAmount => currentMap.botAmount + 1;
    public Player player;
    private List<Bot> bots = new List<Bot>();
    private int levelIndex;

    private void Awake()
    {
        levelIndex = PlayerPrefs.GetInt("Level", 0);
    }

    public void OnInit()
    {
        Vector3 index = currentMap.startPoint.position;

        List<Vector3> startPoints = new List<Vector3>();

        for (int i = 1; i <= CharacterAmount / 2; i++)
        {
            startPoints.Add(index + Vector3.left * i);
            startPoints.Add(index + Vector3.right * i);
        }

        player.Tf.position = index;
        player.OnInit();

        for (int i = 0; i < CharacterAmount - 1; i++)
        {
            Bot bot = SimplePool.Spawn<Bot>(PoolType.Bot, startPoints[i], Quaternion.identity);
            bot.ChangeColor(colorTypes[i]);
            bot.OnInit();
            bot.ChangeState(new PatrolState());
            bots.Add(bot);
        }
    }

    public void LoadLevel(int level)
    {


        if (level < MapList.mapItemDataList.Count)
        {
            currentMap = Instantiate(MapList.mapItemDataList[level].prbMap);
            currentMap.OnInit();
        }
        OnInit();
    }

    public void OnReset()
    {
        if (currentMap != null)
        {
            Destroy(currentMap.gameObject);
        }
        SimplePool.CollectAll();
        bots.Clear();
    }

    public void OnRetry()
    {
        LoadLevel(levelIndex);
    }

    public void OnNextLevel()
    {
        levelIndex++;
        PlayerPrefs.SetInt("Level", levelIndex);
        LoadLevel(levelIndex);
    }
}
