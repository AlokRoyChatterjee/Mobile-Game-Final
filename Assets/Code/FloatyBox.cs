using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FloatyBox : MonoBehaviour
{


    public float forcejump;

    private bool onjump = false;  //player jumped
    
    private bool onground = false;  //player is on the ground
    private bool onfall = false;   //player time for falling

    public float forcemove; 
    public Animator animator;


    public float forcefall;

    public Text newscore;
    
    public LayerMask groundLayer;
    public Transform feet;
    

    public AudioClip saw;
    public AudioSource _as;
    float horizontalMove = 0f;

    Rigidbody2D _rigidbody;
    static int val=0;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _as = GetComponent<AudioSource> ();
        //GetComponent<AudioSource> ().playOnAwake = false;
        //GetComponent<AudioSource> ().clip = saw;
    }
private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Triggered");
            val+=1;
            newscore.text=""+val;
            //GetComponent<AudioSource> ().Play ();
            _as.PlayOneShot(saw);
            Destroy(collision.gameObject);
        }
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        for (int i = 0; i < Input.touchCount; ++i)
        {
            // get ground collision
            onground = Physics2D.OverlapCircle(feet.position, .3f, groundLayer);

            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Moved)
            {
                if (Mathf.Abs(touch.deltaPosition.y) > Mathf.Abs(touch.deltaPosition.x))
                {
                    // jump (1) or fall (0)
                    bool movesignal = (touch.deltaPosition.y > 0);
                    if (movesignal && !onjump && onground)
                    {
                        // jump or fall
                        _rigidbody.AddForce(Vector2.up * forcejump);
                        //touch.phase = TouchPhase.Canceled;
                        onjump = true;
                        StartCoroutine(jumprestart(1f));
                    }
                    if (!onfall && !movesignal && !onground)
                    {
                        _rigidbody.AddForce(Vector2.down * forcejump);
                        onfall = true;
                        StartCoroutine(fallrestart(.2f));
                    }
                }
                else
                {
                    // move
                    int movesignal = (touch.deltaPosition.x > 0) ? 1 : -1;
                    _rigidbody.AddForce(movesignal * Vector2.right * forcemove);
                }
            }
        }
    }
    public IEnumerator fallrestart(float wait)
    {
        yield return new WaitForSeconds(wait);
        onfall = false;
    }

    public IEnumerator jumprestart(float wait)
    {
        yield return new WaitForSeconds(wait);
        onjump = false;
    }

    
}
