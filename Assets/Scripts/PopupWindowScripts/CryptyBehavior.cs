using System.Collections;
using UnityEngine;

public class CryptyBehavior : MonoBehaviour
{
    public float speed;
    public Vector3 spawnGoal;
    public bool goalReached;

    public Vector3[] bounds = new Vector3[2] {new (-5,-4.5f,0), new (5, -4.5f, 0) };
    Vector3 target;
    public float Timer;
    float randTime;

    private bool moving = true;

    void Start()
    {
        target = bounds[Random.Range(0, 1)];
    }
    void Update()
    {
        if (!goalReached)
        {
            transform.position = Vector3.MoveTowards(transform.position, spawnGoal, speed * Time.deltaTime);
            if (transform.position == spawnGoal)
                goalReached = true;
        }
        else
        {
            Timer += Time.deltaTime;
            //if (!CR_Running)
                randomizedMovement();
        }
        
    }

    void randomizedMovement()
    {
        
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            if (Timer >= randTime || transform.position.x >= bounds[1].x || transform.position.x <= bounds[0].x)
            {
                moving = false;
                Timer = 0;
                randTime = Random.Range(5, 10);
            }
        }
        else
        {
            if (Timer >= randTime)
            {
                moving = true;
                Timer = 0;
                randTime = Random.Range(2, 5);

                if (target == bounds[0])
                {
                    target = bounds[1];
                }
                else
                {
                    target = bounds[0];
                }
            }
        }    
    }
}
