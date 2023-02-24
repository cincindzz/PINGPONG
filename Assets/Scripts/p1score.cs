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
        float ball_Initial = ball.GetComponent<ball_initial>().position.x;
        float Timer = timeleft.GetComponent<timer>().TimeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        float Timer = timeleft.GetComponent<timer>().TimeLeft;

        if (Timer > 0)
        {
            if (ball_Initial.position.x >= ball_initial.screenRight)
            {
                p1_score++;
                Debug.Log(System.String.Format("{0}",p1_score));
            }


        }
    }

    void updatescore(int score)
    {
        p1scoreTxt.text = string.Format("{0}", score);
    }
}
