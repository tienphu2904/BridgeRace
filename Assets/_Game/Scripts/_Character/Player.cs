using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterObject
{
    [SerializeField] private float speed = 100;

    private void Start()
    {
        ChangeColor(ColorType.Yellow);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 nextPoint = JoystickControl.direct * speed * Time.deltaTime + Tf.position;

            if (CanMove(nextPoint))
            {
                Tf.position = CheckGround(nextPoint);
            }

            if (JoystickControl.direct != Vector3.zero)
            {
                character.forward = JoystickControl.direct;
            }

            ChangeAnim(Constants.Anim_Run);
        }

        if (Input.GetMouseButtonUp(0))
        {
            ChangeAnim(Constants.Anim_Idle);
        }
    }
}
