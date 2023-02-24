using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle_initial : MonoBehaviour
{

    public float speed = 5f;
    public float minY = -4.18f;
    public float maxY = 4.18f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "right paddle")
        {
            MovePaddle(gameObject.name);
        }
        else if (gameObject.name == "left paddle")
        {
            MovePaddle(gameObject.name);
        }

        void MovePaddle(string paddleName)
        {
            float moveY = Input.GetAxisRaw(paddleName) * speed * Time.deltaTime;

            transform.position = new Vector2(
                transform.position.x,
               Mathf.Clamp(transform.position.y + moveY,minY,maxY));
        }

    }
}
