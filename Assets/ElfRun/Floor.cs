using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public GameObject[] spawnPoint;
    public GameObject tree;
    public bool spawnTree = true;

    // Use this for initialization
    void Start()
    {
        if (!spawnTree)
            return;

        // 세팅한다. 
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            if(Random.Range(0, 2) == 0)
            {
                GameObject newTree = Instantiate(tree, spawnPoint[i].transform);

                Vector3 scale = newTree.transform.localScale;
                scale *= Random.Range(0.5f, 1.2f);
                newTree.transform.localScale = scale;
            }
        }

        // 회전 
        float rot = Random.Range(-30, 30);
        gameObject.transform.parent.transform.rotation = 
         Quaternion.AngleAxis(rot, Vector3.forward);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 charPos = ElfGameManager.Instance().player.transform.position;
        if(transform.position.x < charPos.x)
        {
            if (Vector3.Magnitude(transform.position - charPos) > 15)
                OnBecameInvisible();
        }        
    }

    public void OnBecameInvisible()
    {
        // 바닥이 카메라에서 사라지면, 새로운 바닥 생성을 한다.
        ElfGameManager.Instance().CreateNewFloor();
        Destroy(gameObject);
    }
}
