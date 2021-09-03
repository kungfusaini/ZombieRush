using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private Vector2 deathForce = new Vector2(-50,20);
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxDeath;
    [SerializeField] private AudioClip sfxPoint;


    private Animator animator;
    private Rigidbody rigidbody;
    private bool jump = false;
    private AudioSource audioSource;

    private void Awake()
    {
        Assert.IsNotNull(sfxJump);
        Assert.IsNotNull(sfxDeath);
        //Assert.IsNotNull(sfxPoint);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (!GameManager.instance.GameOver && GameManager.instance.GameStarted) {
            if (Input.GetMouseButtonDown(0)) {
                GameManager.instance.GameStart();
                animator.Play("Jump");
                audioSource.PlayOneShot(sfxJump);
                rigidbody.useGravity = true;
                jump = true;

            }
        }
       
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            jump = false;
            rigidbody.velocity = new Vector2(0, 0);
            rigidbody.AddForce(new Vector2(0, 100f), ForceMode.Impulse);
        }
        
    }

    private void OnCollisionEnter(Collision collision) {

        if (collision.gameObject.tag == "obstacle") {
            rigidbody.AddForce(deathForce, ForceMode.Impulse);
            rigidbody.detectCollisions = false;
            audioSource.PlayOneShot(sfxDeath);
            GameManager.instance.PlayerCollided();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "collider") {
            audioSource.PlayOneShot(sfxPoint);
        }
    }
}
