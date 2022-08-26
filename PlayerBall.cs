using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int DanJump;
    public GameManagerLogic manager;
    bool isJump;
    Rigidbody rigid;

    void Awake() {
        DanJump = 0;
        isJump = false;
        rigid = GetComponent<Rigidbody>();
    }
    void Update() {
        if(Input.GetButtonDown("Jump") && isJump) {
            if(--DanJump == 0) isJump = false;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            manager.GetCoin(DanJump);
        }
    }
    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }
    void OnTriggerEnter(Collider other) {
        if(other.tag == "coins") {
            isJump = true;
            DanJump++;
            other.gameObject.SetActive(false);
            manager.GetCoin(DanJump);
        }
    }
}
