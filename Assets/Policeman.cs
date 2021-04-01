using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Policeman : MonoBehaviour
{
    public GameObject dog;
    //public gameManager _instance;

    public float speed;
    public bool follow = false;

    Rigidbody2D rb2d;
    private bool followTourist = false;

    public bool Follow
    {
        get => follow;
        set
        {
            follow = value;
         
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      
            if (follow)
            if (Vector2.Distance(dog.transform.position, transform.position) >= 1)
                rb2d.velocity = (dog.transform.position - transform.position) * speed * Time.deltaTime;
      

        //rb2d.MovePosition(dog.transform.position);
    }


    IEnumerator FollowTheTourist(Transform target)
    {
        follow = false;

        if (Vector2.Distance(new Vector2(target.position.x + target.GetComponent<CircleCollider2D>().radius, target.position.y + target.GetComponent<CircleCollider2D>().radius), transform.position) <= 0.08)
        {
            rb2d.velocity = (target.position - transform.position) * speed * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
            gameManager._instance.SetTagTarget(target.gameObject.tag);
           
            /*
            if(target.gameObject.name == "bob")
            {
                Debug.Log("Mi nashli BOBA!!!!!");
            } else if(target.gameObject.name == "ulik0")
            {
                gameManager.SetNextTarget(other);

            }else Debug.Log("Mi nashli snasti! ");
            */
            //target.gameObject.tag




            yield return new WaitForEndOfFrame();
        }
            //StopCoroutine(FollowTheTourist());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Enter " + other.gameObject.name);
        if (other.GetComponent<tourist>() != null)
        {
            StartCoroutine(FollowTheTourist(other.transform));
        }
        else
        if (other.GetComponent<doge>() != null)
        {
            follow = false;
            rb2d.velocity = new Vector2(0, 0);
        }


    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.GetComponent<tourist>() != null)
    //    {
    //        if (follow)
    //        {
    //            if (Vector2.Distance(collision.transform.position, transform.position) <= 1)
    //            {

    //                follow = false;

    //                rb2d.velocity = new Vector2(0, 0);


    //                StartCoroutine(FollowTheTourist(collision.transform));
    //            }
    //        }
    //    }
    //}
}
