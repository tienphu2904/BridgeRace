using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterObject : ColorObject
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask stairLayer;
    [SerializeField] private PlayerBrick playerBrickPrefab;
    [SerializeField] private Transform brickHolder;
    [SerializeField] protected Transform character;
    public List<PlayerBrick> playerBricks = new List<PlayerBrick>();
    private string currentAnim;
    public Animator anim;
    public Stage stage;
    public int BrickCount => playerBricks.Count;

    public void OnInit()
    {
        ClearBrick();
        character.rotation = Quaternion.identity;
        ChangeAnim(Constants.Anim_Idle);
    }

    public Vector3 CheckGround(Vector3 nextPoint)
    {
        RaycastHit hit;

        if (Physics.Raycast(nextPoint + Vector3.up, Vector3.down, out hit, 5f, groundLayer))
        {
            return hit.point + Vector3.up * .01f;
        }

        return Tf.position;
    }

    public void AddBrick()
    {
        PlayerBrick playerBrick = Instantiate(playerBrickPrefab, brickHolder);
        playerBrick.ChangeColor(colorType);
        playerBrick.Tf.localPosition = Vector3.up * 0.21f * playerBricks.Count;
        playerBrick.Tf.localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
        playerBricks.Add(playerBrick);
    }

    public void RemoveBrick()
    {
        if (playerBricks.Count > 0)
        {
            PlayerBrick playerBrick = playerBricks[playerBricks.Count - 1];
            playerBricks.RemoveAt(playerBricks.Count - 1);
            Destroy(playerBrick.gameObject);
        }
    }

    private void ClearBrick()
    {
        for (int i = 0; i < playerBricks.Count; i++)
        {
            Destroy(playerBricks[i].gameObject);
        }

        playerBricks.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.Tag_Brick))
        {
            ColorType brickColorType = other.GetComponent<ColorObject>().colorType;
            if (brickColorType == colorType)
            {
                other.GetComponent<PlayerBrick>().OnDespawn();
                AddBrick();
                Destroy(other.gameObject);
            }
        }
    }

    public bool CanMove(Vector3 nextPoint)
    {
        RaycastHit hit;

        if (Physics.Raycast(nextPoint + Vector3.up, Vector3.down, out hit, 5f, stairLayer))
        {
            ColorObject stairColorObject = hit.collider.GetComponent<ColorObject>();
            MeshRenderer mesh = hit.collider.GetComponent<MeshRenderer>();
            if (stairColorObject.colorType != colorType && playerBricks.Count > 0)
            {
                stairColorObject.ChangeColor(colorType);
                mesh.enabled = true;
                RemoveBrick();
                stage.NewBrick(colorType);
            }

            if (stairColorObject.colorType != colorType && playerBricks.Count == 0 && character.forward.z > 0)
            {
                return false;
            }
        }

        return true;
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(currentAnim);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
}
