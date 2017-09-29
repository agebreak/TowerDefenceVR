using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // 스폰 위치들을 받는다 (배열)
    public Transform[] spawnPoints;
    public GameObject drone;        // 생성할 드론 프리팹
    public float spawnTime;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnDrone", 0.0f, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnDrone()
    {
        // 스폰 포인트 중에서 램던한 위치에서 드론을 생성한다. 
        int index = Random.Range(0, spawnPoints.Length);
        Vector3 pos = spawnPoints[index].position;

        GameObject newDrone = Instantiate(drone);
        newDrone.transform.position = pos;
    }
}
