using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] PlayerBrick brickPrefab;
    public Transform[] brickPoints;
    public List<Vector3> emptyPoints = new List<Vector3>();
    public List<PlayerBrick> bricks = new List<PlayerBrick>();

    internal void OnInit()
    {
        for (int i = 0; i < brickPoints.Length; i++)
        {
            emptyPoints.Add(brickPoints[i].position);
        }
    }

    public void InitColor(ColorType colorType)
    {
        int amount = brickPoints.Length / LevelManager.Ins.CharacterAmount;

        for (int i = 0; i < amount; i++)
        {
            NewBrick(colorType);
        }
    }

    public void NewBrick(ColorType colorType)
    {
        if (emptyPoints.Count > 0)
        {
            int index = Random.Range(0, emptyPoints.Count);
            PlayerBrick brick = SimplePool.Spawn<PlayerBrick>(PoolType.Brick, emptyPoints[index], Quaternion.identity);
            brick.stage = this;
            brick.ChangeColor(colorType);
            emptyPoints.RemoveAt(index);
            bricks.Add(brick);
        }
    }

    internal void RemoveBrick(PlayerBrick brick)
    {
        emptyPoints.Add(brick.Tf.position);
        bricks.Remove(brick);
    }

    public void ClearColorBrick(ColorType colorType)
    {
        for (int i = 0; i < bricks.Count; i++)
        {
            if (bricks[i].colorType == colorType)
            {
                RemoveBrick(bricks[i]);
            }
        }
    }

    internal PlayerBrick SeekBrickPoint(ColorType colorType)
    {
        for (int i = 0; i < bricks.Count; i++)
        {
            if (bricks[i].colorType == colorType)
            {
                return bricks[i];
            }
        }
        return null;
    }
}
