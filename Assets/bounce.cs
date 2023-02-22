using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class bounce : MonoBehaviour
{
    public float speed = 1.0f;
    //define min and max positions for the object
    public float minX = -10;
    public float maxX = 10;
    // float conversions
    public float minY = (float)-4.5;
    public float maxY = (float)4.5;
    public float angle;
    private Vector2 direction;
    Vector2 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
