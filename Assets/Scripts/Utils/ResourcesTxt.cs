using UnityEngine;
using UnityEngine.UI;

public class ResourcesTxt : MonoBehaviour
{
    private Text diamondText;
    public float newValue = 0;

    private string str;
    private float value;

    private void Start()
    {
        diamondText = GetComponent<Text>();
        str = diamondText.text;
        string temp = str + " " + value.ToString();
        diamondText.text = temp;
    }

    private void Update()
    {
        if (value != newValue)
        {
            value = newValue;
            string temp = str + " " + value.ToString();
            diamondText.text = temp;
        }
    }
}
