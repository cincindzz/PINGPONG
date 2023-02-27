using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class p1score : MonoBehaviour
{
    // get data from other scripts
    public int p1_score = 0;
    public int p2_score = 0;
    ball_initial ball_Initial;
    [SerializeField] GameObject ball;
    timer Timer;
    [SerializeField] GameObject timeleft;
    public TextMeshProUGUI p1scoreTxt;

    // Start is called before the first frame update
    void Awake()
    {
        ball_Initial = ball.GetComponent<ball_initial>();
        float Timer = timeleft.GetComponent<timer>().TimeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        float Timer = timeleft.GetComponent<timer>().TimeLeft;

        Debug.Log("update");

        if (Timer > 0)
        {
            if (ball_Initial.position.x >= ball_initial.screenRight)
            {
                Debug.Log(System.String.Format("2 position: {0}", ball_Initial.position.x));
                Debug.Log(System.String.Format("screen: {0}", ball_initial.screenRight));


                p1_score++;
                updatescore(p1_score,p2_score);
                //Debug.Log(System.String.Format("{0}",p1_score));
            }

            if (ball_Initial.position.x <= ball_initial.screenLeft)
            {
                p2_score++;
                updatescore(p1_score, p2_score);

            }

        }
    }

    void updatescore(int p1_score, int p2_score)
    {
        p1scoreTxt.text = string.Format("{0}:{1}", p1_score, p2_score);
    }
}
