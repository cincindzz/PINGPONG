using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class p1score : MonoBehaviour
{
    // get data from other scripts
    int p1_score = 0;
    ball_initial ball_Initial;
    [SerializeField] GameObject ball;
    timer Timer;
    [SerializeField] GameObject timeleft;
    public TextMeshProUGUI p1scoreTxt;

    // Start is called before the first frame update
    void Awake()
    {
        ball_Initial = ball.GetComponent<ball_initial>();
        Timer = timeleft.GetComponent<timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.TimeLeft > 0)
        {
            if (ball_initial.position.x >= ball_initial.screenRight)
            {
                p1_score++;
            }


        }
    }

    void updatescore(int score)
    {
        p1scoreTxt.text = string.Format("{00}", score);
    }
}
