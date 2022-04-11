using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text TimeText;

    public double TimeLimit = 120;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeLimit -= Time.deltaTime;
        TimeLimit = System.Math.Round(TimeLimit, 2);
        TimeText.text = TimeLimit.ToString();
    }
}
