using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FloatyBox3 : MonoBehaviour
{

    public float forceofjumping;

    private bool onjump = false;  //player jumped

    public float forceofmotion; 
    public Animator animator;


    public float forceoffalling;

    public Text newscore;
    
    private bool onfall = false;   //player time for falling

    public LayerMask groundLayer;
    public Transform feet;

    private bool onground = false;  //player is on the ground

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
            Debug.Log("collision");
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
            onground = Physics2D.OverlapCircle(feet.position, .3f, groundLayer); //player on ground
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Moved)
            {
                if (Mathf.Abs(touch.deltaPosition.x) < Mathf.Abs(touch.deltaPosition.y))
                {
                    bool movesignal = (0 < touch.deltaPosition.y);
                    if (!onfall) //movesignal down ify<0
                    {
                        if(!movesignal){
                            if(!onground){
                                
                                _rigidbody.AddForce(forceofjumping * Vector2.down ); //falling
                                onfall = true;
                                StartCoroutine(fallrestart(.2f));
                            }
                        }
                        
                    }
                    if (movesignal) //movesignal up if y>0
                    {
                        if(!onjump){
                            if(onground){
                                _rigidbody.AddForce(forceofjumping * Vector2.up );  //jumping
                                onjump = true;
                                StartCoroutine(jumprestart(1f));
                            }
                        }
                        
                    }
                }
                else
                {
                    int movesignal;
                    if(0 < touch.deltaPosition.x){
                        movesignal=1;
                    }
                    else{
                        movesignal=-1;
                    }
                    _rigidbody.AddForce(forceofmotion * movesignal * Vector2.right );
                }
            }
        }
    }
    public IEnumerator fallrestart(float amountwaiting)
    {
        yield return new WaitForSeconds(amountwaiting);
        onfall = false;
    }

    public IEnumerator jumprestart(float amountwaiting)
    {
        yield return new WaitForSeconds(amountwaiting);
        onjump = false;
    }

    
}
