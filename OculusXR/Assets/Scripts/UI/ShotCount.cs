using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotCount : MonoBehaviour
{
    private int shotCounter = 0;
    private TextMeshProUGUI bulletText;
    private TextMeshProUGUI boxText;

    // Start is called before the first frame update
    void Start()
    {
        bulletText = GetComponent<TextMeshProUGUI>();
        FireBulletOnActivate.GunFired += IncreaseCounter;
        UpdateText();
    }

    private void IncreaseCounter()
    {
        shotCounter++;
        UpdateText();
    }

    private void UpdateText()
    {
        bulletText.text = shotCounter.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
