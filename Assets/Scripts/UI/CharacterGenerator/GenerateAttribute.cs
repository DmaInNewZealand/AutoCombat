using UnityEngine;
using UnityEngine.UI;
using System;

public class GenerateAttribute : MonoBehaviour
{
    public GameObject AttributeUI;
    public CharacterGenerator CharacterGenerator;
    public float Height = 0.2f;

    private void Awake()
    {
        for (int i = 0; i < Enum.GetValues(typeof(AttributeName)).Length; i++)
        {
            //Instantiate AttributeUI
            var textPanel = Instantiate(AttributeUI);
            //Set Parent
            textPanel.transform.SetParent(transform, false);
            //SetAnchor
            var rectTransform = textPanel.GetComponent<RectTransform>();
            rectTransform.anchorMax += new Vector2(0, -i * Height);
            rectTransform.anchorMin += new Vector2(0, -i * Height);
            //SetText
            var texts = textPanel.GetComponentsInChildren<Text>();
            texts[0].text = ((AttributeName)i).ToString();
            texts[1].text = PlayerCharacter.Player.GetAttribute(i).AdjustedValue.ToString();
           //SetButtonOnClickEvent
            var buttons = textPanel.GetComponentsInChildren<Button>();
            int captured = i;
            buttons[0].onClick.AddListener(() => CharacterGenerator.Add(captured));
            buttons[1].onClick.AddListener(() => CharacterGenerator.Sub(captured));
        }
    }

    private void OnEnable()
    {
        var texts = GetComponentsInChildren<UpdateText>();
        //Register to StatChangeEvent
        for (int i = 0; i < texts.Length; i++)
        {
            PlayerCharacter.Player.GetAttribute(i).StatChanged += texts[i].UpdateTextValue;
        }
    }

    private void OnDisable()
    {
        var texts = GetComponentsInChildren<UpdateText>();
        //UnRegister to StatChangeEvent
        for (int i = 0; i < texts.Length; i++)
        {
            PlayerCharacter.Player.GetAttribute(i).StatChanged -= texts[i].UpdateTextValue;
        }
    }
}
