using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShotCount : MonoBehaviour
{
    private int shotCounter = 0;
    private TextMeshProUGUI bulletText;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletText = GetComponent<TextMeshProUGUI>();
        FireBulletOnActivate.GunFired += IncreaseBulletCounter;

        UpdateText();
    }

    private void OnDestroy()
    {
        FireBulletOnActivate.GunFired -= IncreaseBulletCounter;
    }

    private void IncreaseBulletCounter()
    {
        shotCounter++;
        UpdateText();
    }

    private void UpdateText()
    {
        bulletText.text = shotCounter.ToString();
    }
}
