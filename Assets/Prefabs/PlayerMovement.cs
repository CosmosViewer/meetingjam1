using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rig;
    SpriteRenderer sprite;
    bool isWalking;
    public Animator animator;
    public LightBar lightBar;
    bool fixLight;
    bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("run", isWalking);
        if (lightBar.isProtecting){
            animator.SetBool("hide", true);
            return;
        }
        else {
            animator.SetBool("hide", false);
        }
        if(Input.GetKeyDown(KeyCode.W)) {
            if (isJumping){
                print(isJumping);
                return;
            }
            else {
                print(isJumping);
                isJumping = true;
                rig.AddForce(6.5f * Vector2.up, ForceMode2D.Impulse);
            }
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rig.velocity = new Vector2(10, rig.velocity.y);
            isWalking = true;
            sprite.flipX = false;
            }
        else if (Input.GetKey(KeyCode.A))
        {
            rig.velocity = new Vector2(-10, rig.velocity.y);
            isWalking = true;
            sprite.flipX = true;     
        }

        else
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
            isWalking = false;
        }

        if (rig.velocity.y <= -15) {
            GameStates.instance.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "floor"){
            isJumping = false;
        }
    }
}
