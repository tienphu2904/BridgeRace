using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Stage stage;
    private List<ColorType> colorTypes = new List<ColorType>();

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag(Constants.Tag_Character) || other.CompareTag(Constants.Tag_Player))
            && !colorTypes.Contains(other.GetComponent<CharacterObject>().colorType))
        {
            CharacterObject character = other.GetComponent<CharacterObject>();
            colorTypes.Add(character.colorType);
            character.stage = stage;
            stage.InitColor(character.colorType);
        }
    }
}
