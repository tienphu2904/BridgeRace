using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform tf;
    public Transform playerTransform;
    [SerializeField] Vector3 offset;
    private void LateUpdate()
    {
        tf.position = Vector3.Lerp(tf.position, playerTransform.position + offset, Time.deltaTime * 100f);
        tf.LookAt(playerTransform);
    }


}