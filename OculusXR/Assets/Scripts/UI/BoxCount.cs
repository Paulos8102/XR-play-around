using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxCount : MonoBehaviour
{
    private int boxCounter = 0;
    
    private TextMeshProUGUI boxText;

    // Start is called before the first frame update
    void Start()
    {
        boxText = GetComponent<TextMeshProUGUI>();
        BoxLife.BoxDied += IncreaseBoxCounter;      //call from the BoxLife Script

        UpdateText();
    }

    private void OnDestroy()
    {
        BoxLife.BoxDied -= IncreaseBoxCounter;      //call from the BoxLife Script
    }

    private void IncreaseBoxCounter()
    {
        boxCounter++;
        UpdateText();
    }

    private void UpdateText()
    {
        boxText.text = boxCounter.ToString();
    }
}
