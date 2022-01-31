using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timeRemaining = 90.0f;

    public TextMeshProUGUI textbox;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
        
        this.textbox.text = Mathf.RoundToInt(timeRemaining).ToString();
    }
}
