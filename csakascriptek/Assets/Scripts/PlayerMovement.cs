using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private float moveSpeed = 4.5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;
    public AudioSource audioSrc;
    public AudioClip[] dirtSounds;
    public AudioClip[] stoneSounds;
    public bool dirtOrstone;
    //bool isMoving; Régi hanglejátszás
    
    
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0 && movement.y != 0)
        {
            moveSpeed = 3f;
        }
        else if (movement.x == 0 && movement.y != 0)
        {
            moveSpeed = 3.5f;
        }
        else{
            moveSpeed = 4.5f;
        }
        /*if (movement.x!=0 || movement.y!=0)
        {
            isMoving = true;
        }
        if (movement.x == 0 && movement.y == 0)
        {
            isMoving = false;
        }
        
        if (isMoving)
        {
            if (!audioSrc.isPlaying)
            {
                audioSrc.Play();
            }
        }
        else
        {
            audioSrc.Stop();
        }*/
        if (Input.GetAxisRaw("Horizontal") == 1||Input.GetAxisRaw("Horizontal")==-1||Input.GetAxisRaw("Vertical")==1||Input.GetAxisRaw("Vertical")==-1) 
        {
            animator.SetFloat("lastHorizontal", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastVertical", Input.GetAxisRaw("Vertical"));
        }
    }
    
    public void PlayFootstep()
    {
        audioSrc.volume = 0.5f;
        audioSrc.PlayOneShot(audioSrc.clip);
    }
    public void RandomizeFootstep()
    {
        if (dirtOrstone){
            audioSrc.clip = stoneSounds[Random.Range(0, stoneSounds.Length)];
        }
        if (!dirtOrstone){
            audioSrc.clip = dirtSounds[Random.Range(0, dirtSounds.Length)];
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
}
