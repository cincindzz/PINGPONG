using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
public class right_paddle : MonoBehaviour
{

    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 racketDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("up"))
        //{
        //    transform.Translate(Vector2.up * speed * Time.deltaTime);
        //}
        //if (Input.GetKey("down"))
        //{
        //    transform.Translate(Vector2.down * speed * Time.deltaTime);
        //}
        if (transform.position.y >= 4.18f)
        {
            transform.position = new Vector2(transform.position.x, 4.18f);
        }
        if (transform.position.y <= -4.18f)
        {
            transform.position = new Vector2(transform.position.x, -4.18f);
        }


        float directionY = Input.GetAxisRaw("RightPaddle");

        racketDirection = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate()
    {
     rb.velocity = racketDirection * speed;
    }
}
