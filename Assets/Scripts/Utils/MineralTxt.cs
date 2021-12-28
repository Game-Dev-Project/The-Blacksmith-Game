using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MineralTxt : MonoBehaviour
{
    private Text diamondText;
    public int newValue = 0;

    private int value;

    private void Start()
    {
        diamondText = GetComponent<Text>();
    }

    private void Update()
    {
        if (value != newValue)
        {
            value = newValue;
            string temp = "mineral: " + value.ToString();
            diamondText.text = temp;
        }
    }
}
