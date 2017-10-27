using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfPlayer : MonoBehaviour {
    public float speed;
    public float jumpSpeed = 8.0f;
    float gravity = 20.0f;

    Vector3 moveVec;    // 이동하는 벡터
    CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(controller.isGrounded)
        {
            moveVec = transform.forward * speed;
            if(Input.GetMouseButtonDown(0))
            {
                moveVec.y += jumpSpeed;
            }            
        }

        moveVec.y -= gravity * Time.deltaTime;        
        controller.Move(moveVec * Time.deltaTime);
	}
}
