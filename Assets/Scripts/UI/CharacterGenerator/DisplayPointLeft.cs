using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayPointLeft : MonoBehaviour
{
    public CharacterGenerator CharacterGenerator;

    private Text text;

    void Awake()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "Points Left: " + CharacterGenerator.LeftPoints.ToString();
    }
}
