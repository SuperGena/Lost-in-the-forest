using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfController : MonoBehaviour
{
    public Transform firstPoint;
    public Transform secondPoint;

    public GameObject targetPosition;

    public float speed;

    Rigidbody2D rb2d;

    SpriteRenderer sprite;

    bool runAway;
    
    public bool runTo;
    public bool toTheRight = true;


    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    float WRadius = 1;


    Vector2 direction;


    public bool RunAwayFromDog
    {
        get
        {
            return runAway;
        }
        set
        {
            runAway = value;
            sprite.flipX = !value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        if (!RunAwayFromDog)
        {
            if (Vector2.Distance(waypoints[current].transform.position, transform.position) < WRadius)
            {
                current = Random.Range(0, waypoints.Length);
                if (current >= waypoints.Length)
                {
                    current = 0;
                }
            }
            if (waypoints[current].transform.position.x > transform.position.x)
                sprite.flipX = false;
            else
                sprite.flipX = true;

            transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }
        else
        {
            if (Vector2.Distance(targetPosition.transform.position, transform.position) <= 6)
            {

                //transform.position = Vector2.MoveTowards(transform.position, -direction, Time.deltaTime * speed);
                //rb2d.velocity = -direction * 10;
                if (targetPosition.transform.position.x > transform.position.x)
                    sprite.flipX = true;
                else
                    sprite.flipX = false;

                transform.position = Vector2.MoveTowards(transform.position, targetPosition.transform.position, Time.deltaTime * -1 * speed * speed);
            }
            else
                RunAwayFromDog = false;
        }
    }


    public void RunAway()
    {
        direction = (targetPosition.transform.position - transform.position).normalized;

        RunAwayFromDog = true;
    }

    IEnumerator Run(Vector2 targetPosition)
    {
        if (Vector2.Distance(targetPosition, transform.position) <= 6)
        {
            rb2d.velocity = (new Vector2(targetPosition.x, targetPosition.y) - new Vector2(transform.position.x, transform.position.y)).normalized * speed * Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        else
            yield return new WaitForFixedUpdate(); 
    }
}
