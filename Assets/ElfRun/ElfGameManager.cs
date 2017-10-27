using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElfGameManager : MonoBehaviour {
    public Transform endPoint;
    public GameObject floorObject;  // 생성될 바닥 프리팹
    public GameObject player;

    static ElfGameManager instance;
    static public ElfGameManager Instance()
    {
        return instance;
    }

	// Use this for initialization
	void Start () {
        instance = this;

        CreateNewFloor();
        CreateNewFloor();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateCamera();
	}

    public void CreateNewFloor()
    {
        GameObject newFloor = Instantiate(floorObject);
        newFloor.transform.position = endPoint.position;

        // 새로 생성된 바닥을 endPoint에 넣어준다. 
        for (int i = 0; i < newFloor.transform.childCount; i++)
        {
            Transform child = newFloor.transform.GetChild(i);
            if(child.name == "EndPoint")
            {
                endPoint = child;
                break;
            }
        }
    }

    void UpdateCamera()
    {
        Vector3 playerPos = player.transform.position;
        playerPos.z -= 10;
        Camera.main.transform.position = playerPos;
    }
}
