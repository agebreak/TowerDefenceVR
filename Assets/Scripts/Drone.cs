using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Drone : MonoBehaviour {
    public Transform tower; // 목적지 타워

	// Use this for initialization
	void Start () {
        // 타워 오브젝트를 찾아서, 세팅한다. 
        tower = GameObject.Find("Tower").GetComponent<Transform>();

        // 네비게이션 목적지를 타워의 위치로 설정한다. 
        GetComponent<NavMeshAgent>().destination = tower.position;
     
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
