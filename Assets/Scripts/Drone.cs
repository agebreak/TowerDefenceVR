using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Drone : MonoBehaviour {
    public Transform tower; // 목적지 타워
    public ParticleSystem explosion;    // 폭발 이펙트
    public AudioClip explosionSound; // 폭발 사운드 
    public Image hpGuage;

    float hp = 2;
    float totalHp = 2;

	// Use this for initialization
	void Start () {
        // 타워 오브젝트를 찾아서, 세팅한다. 
        tower = GameObject.Find("Tower").GetComponent<Transform>();

        // 네비게이션 목적지를 타워의 위치로 설정한다. 
        GetComponent<NavMeshAgent>().destination = tower.position;

        explosion = GameObject.Find("Explosion").GetComponent<ParticleSystem>();
     
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDamage()
    {
        --hp;

        // 게이지표시
        hpGuage.fillAmount = hp / totalHp;

        if(hp <= 0)
        {
            Destroy(gameObject);

            explosion.transform.position = transform.position;
            explosion.Stop();
            explosion.Play();

            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }
    }
}
