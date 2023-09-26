using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotCount : MonoBehaviour
{
    private int shotCounter = 0;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
