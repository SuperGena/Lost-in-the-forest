using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doge : MonoBehaviour
{
    private SpriteRenderer rend;
    private Rigidbody2D rb;
    private Vector2 moveDirect;

    public Policeman[] policemans;

    public int speed;
    public bool isSniffing = false;
    public float changeColorTime;


    public GameObject spriteMask;

    public Color footStepsColor;
    public Material footStepsMaterial;
    private bool isChangeColor = false;
    public AudioSource m_MyAudioSource;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_MyAudioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        //Move();
        rend = GetComponent<SpriteRenderer>();
        rend.sortingOrder = (int)(transform.position.y * -100);

        if (Input.GetKey(KeyCode.Space))
        {
            speed = 1;
        }
        else
        {
            speed = 4;
        }
        if (Input.GetKey(KeyCode.F) && !m_MyAudioSource.isPlaying)
        {
            //cp[s
            
            m_MyAudioSource.Play();


        }
       
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        if (gameManager._instance.isGameOver)
            return;
        else if (!gameManager._instance.isStart)
            return;
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirect = new Vector2(moveX, moveY);

            anim.SetFloat("magnitude", moveDirect.magnitude);
            anim.SetFloat("moveX", moveX);
            anim.SetFloat("moveY", moveY);
        
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirect.x, moveDirect.y).normalized * speed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<tourist>() != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                //Debug.Log("OnTriggerStay2D " + collision.gameObject.name);
                foreach (var policeman in policemans)
                {
                    policeman.Follow = true;
                }

                gameManager._instance.SetTagTarget(collision.gameObject.tag);
            }

        }
        else if (collision.GetComponent<WolfController>() != null)
        {
            if (Input.GetKey(KeyCode.F))
            {
                collision.GetComponent<WolfController>().RunAway();
            }
            if (Input.GetKey(KeyCode.Space))
            {
                gameManager._instance.SetTagTarget(collision.gameObject.tag);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.GetComponentInParent<WolfController>() != null)
        {
            gameManager._instance.GameOver();

        }


    }


}
