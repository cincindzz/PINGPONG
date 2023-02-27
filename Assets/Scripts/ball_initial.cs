using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ball_initial : MonoBehaviour
{
    public float speed = 5.0f;
    public float extraSpeed;
    public float maxSpeed;
    private int HitCounter = 0;
    //define min and max positions for the object
    // float conversions
    public float minY = (float)-4.5;
    public float maxY = (float)4.5;
    public float angle;
    private Vector2 direction;
    public Vector2 position;
    public static float screenLeft;
    public static float screenRight;
    public static float screenUp;
    public static float screenDown;
    // rigidbody system
    private Rigidbody2D rb;


    void Start()
    // call once before anything starts
    {
        //Debug.Log("Start");
        //random spawn position
        angle = Random.Range(0f, 2f * Mathf.PI);
        screenLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
        screenRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        screenUp = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        screenDown = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;
        Vector2 randomPos = new Vector2(0, Random.Range(minY, maxY));
        position = randomPos;

        // setup ball collision
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;

        //
        StartCoroutine(Launch());
    }


    void Update()
    // update every frame
    {

        float y_transform = Mathf.Sin(angle) * speed * Time.deltaTime;
        float x_transform = Mathf.Cos(angle) * speed * Time.deltaTime;
        // Debug.Log("Update");
        Debug.Log(System.String.Format("Angle: {0}", angle));
        //Debug.Log(System.String.Format("transform: {0},{1}", x_transform, y_transform));
        //Debug.Log(System.String.Format("FROM: {0},{1}",position.x, position.y));
        position = new Vector2(position.x + x_transform, position.y + y_transform);
        //Debug.Log(System.String.Format("To: {0},{1}", position.x, position.y));
        transform.position = position;

        // transformations when hitting the wall
        //hit wall reflect
        // ball hitting the wall from right
        if (transform.position.x <= screenLeft)
        {
            if (angle <= 1f * Mathf.PI)
            {
                angle = 1f * Mathf.PI - angle;
            }
            if (angle > 1f * Mathf.PI)
            {
                angle = 3f * Mathf.PI - angle;
            }
        }
        // ball hitting the wall from left
        // need to turn into scoring
        // could use code for collision between ball and paddle
        if (transform.position.x >= screenRight)
        {
            if (angle > 1f * Mathf.PI)
            {
                angle = 3f * Mathf.PI - angle;
            }
            if (angle <= 1f * Mathf.PI)
            {
                angle = 1f * Mathf.PI - angle;
            }
        }

        // from below
        if (transform.position.y >= screenUp)
        {
            if (angle <= 0.5f * Mathf.PI)
            {
                angle *= -1;
            }
            else
            {
                angle = 2f * Mathf.PI - angle;
            }
        }

        // from above
        if (transform.position.y <= screenDown)
        {
            angle = 2f * Mathf.PI - angle;
        }
    }


    public IEnumerator Launch()
    {
        HitCounter = 0;
        yield return new WaitForSeconds(1);

        MoveBall(new Vector2(-1, 0));
    }


    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = speed + HitCounter * extraSpeed;

        rb.velocity = direction * ballSpeed;
    }

    public void IncreaseHitCounter()
    {
        if (HitCounter * extraSpeed < maxSpeed)
        {
            HitCounter++;
        }
    }

    //private void OnCollisionEnter2D(Collision2D obj)
    //{
    //    if (obj.gameObject.tag == "RightPaddle")
    //    {
    //        float y = (transform.position.y - obj.transform.position.y) / obj.collider.bounds.size.y;
    //        Vector2 dir = new Vector2(-1, y).normalized;
    //        rb.velocity = dir * speed;
    //    }
    //    if (obj.gameObject.tag == "LeftPaddle")
    //    {
    //        float y = (transform.position.y - obj.transform.position.y) / obj.collider.bounds.size.y;
    //        Vector2 dir = new Vector2(1, y).normalized;
    //        rb.velocity = dir * speed;
    //}
}
