using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    private Player player;
    private Animator anim;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        anim.SetBool("isAtk", player.isAtk);
    }
}
