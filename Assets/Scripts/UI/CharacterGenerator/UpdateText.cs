using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour
{
    public void UpdateTextValue(int changedValue)
    {
        GetComponent<Text>().text = changedValue.ToString();
    }
}
