using UnityEngine;
using UnityEngine.UI;
using System;

public class CreateButton : MonoBehaviour
{
    public CharacterGenerator CharacterGenerator;
    public Text InputText;

    private Button button;

    // Use this for initialization
    void Awake()
    {
        button = GetComponent<Button>();
        button.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacterGenerator.LeftPoints != 0 || InputText.text == String.Empty)
        {
            button.interactable = false;
        }
        else
        {
            button.interactable = true;
        }
    }
}
