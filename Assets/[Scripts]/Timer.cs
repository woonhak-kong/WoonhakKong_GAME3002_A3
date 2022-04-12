using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text TimeText;

    public double TimeLimit = 120;

    private bool _isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlaying)
        {
            TimeLimit -= Time.deltaTime;
            if (TimeLimit < 0)
                TimeLimit = 0;

            TimeLimit = System.Math.Round(TimeLimit, 2);
            TimeText.text = TimeLimit.ToString();

            if (TimeLimit <= 0)
            {
                FindObjectOfType<Player>().Die();
            }

        }
    }

    public void SetIsPlaying(bool val)
    {
        _isPlaying = val;
    }
}
