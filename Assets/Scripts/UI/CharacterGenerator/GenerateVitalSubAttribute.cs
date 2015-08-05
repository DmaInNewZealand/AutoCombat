using UnityEngine;
using UnityEngine.UI;
using System;

public class GenerateVitalSubAttribute : MonoBehaviour
{
    public GameObject VitalSubAttributeUI;
    public CharacterGenerator CharacterGenerator;
    public float Height = 0.05f;

    private int vitalCount;
    private int subAttrCount;

    private void Awake()
    {
        vitalCount = Enum.GetValues(typeof(VitalName)).Length;
        subAttrCount = Enum.GetValues(typeof(SubAttributeName)).Length;

        for (int i = 0; i < vitalCount + subAttrCount; i++)
        {
            //Instantiate AttributeUI
            var textPanel = Instantiate(VitalSubAttributeUI);

            //Set Parent
            textPanel.transform.SetParent(transform, false);

            //SetAnchor
            var rectTransform = textPanel.GetComponent<RectTransform>();
            rectTransform.anchorMax += new Vector2(0, -i * Height);
            rectTransform.anchorMin += new Vector2(0, -i * Height);

            //SetText
            var texts = textPanel.GetComponentsInChildren<Text>();
            if (i < vitalCount)
            {
                //Vitals
                texts[0].text = ((VitalName)i).ToString();
                texts[1].text = PlayerCharacter.Player.GetVital(i).AdjustedValue.ToString();
            }
            else
            {
                //SubAttributes
                texts[0].text = ((SubAttributeName)(i - vitalCount)).ToString();
                texts[1].text = PlayerCharacter.Player.GetSubAttribute(i - vitalCount).AdjustedValue.ToString();
            }
        }
    }

    private void OnEnable()
    {
        var texts = GetComponentsInChildren<UpdateText>();
        //Register to StatChangeEvent
        for (int i = 0; i < texts.Length; i++)
        {
            if (i < vitalCount)
            {
                PlayerCharacter.Player.GetVital(i).StatChanged += texts[i].UpdateTextValue;
            }
            else
            {
                PlayerCharacter.Player.GetSubAttribute(i - vitalCount).StatChanged += texts[i].UpdateTextValue;
            }
        }
    }

    private void OnDisable()
    {
        var texts = GetComponentsInChildren<UpdateText>();
        //Register to StatChangeEvent
        for (int i = 0; i < texts.Length; i++)
        {
            if (i < vitalCount)
            {
                PlayerCharacter.Player.GetVital(i).StatChanged -= texts[i].UpdateTextValue;
            }
            else
            {
                PlayerCharacter.Player.GetSubAttribute(i - vitalCount).StatChanged -= texts[i].UpdateTextValue;
            }
        }
    }

}
