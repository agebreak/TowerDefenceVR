using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfPlayer : MonoBehaviour {
    public float speed;

    Vector3 moveVec;    // 이동하는 벡터
    CharacterController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        moveVec = transform.forward * speed;
        controller.SimpleMove(moveVec);
	}
}
