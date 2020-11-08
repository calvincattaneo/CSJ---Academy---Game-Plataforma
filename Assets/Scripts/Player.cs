using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    private Animator anim;
    private bool isJumping;
    public bool isAtk;
    private float timeAtk;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        if(Input.GetKey(KeyCode.D)) {
            rig.velocity = new Vector2(Speed * Time.deltaTime, rig.velocity.y);
            anim.SetBool("isWalking", true);
            transform.localEulerAngles = new Vector3(0, 0, 0);
        } else {
            rig.velocity = new Vector2(0f, rig.velocity.y);
            anim.SetBool("isWalking", false);
        }

        if(Input.GetKey(KeyCode.A)) {
            rig.velocity = new Vector2(-Speed * Time.deltaTime, rig.velocity.y);
            anim.SetBool("isWalking", true);
            //rotacionar 180 graus - euler
            transform.localEulerAngles = new Vector3(0,180,0);
            
        }

        if(Input.GetKeyDown(KeyCode.Space) && !isJumping) {
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isJumping = true;
            anim.SetBool("isJumping", true);
        }

        if(Input.GetKeyDown(KeyCode.E)) {
            anim.SetBool("isAtk", true);
            isAtk = true;
            timeAtk = 0.25f;
            Debug.Log('E');
        }

        timeAtk -= Time.deltaTime;
        if (timeAtk <= 0f) {
            anim.SetBool("isAtk", false);
            isAtk = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 8) {
            isJumping = false;
            anim.SetBool("isJumping", false);
        }
    }
}
