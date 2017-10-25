using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour {
    public float mouseDelta;
    float deltaX; // 마우스 이동값을 누적시킬 변수
    float deltaY;
    public ParticleSystem hitEffect;    // 피격 이펙트 
   
    public AudioClip rifleSound; // 총 발사 사운드

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // 마우스를 움직이면 카메라를 회전시킨다.
        deltaX += Input.GetAxis("Mouse X") * mouseDelta;
        deltaY += Input.GetAxis("Mouse Y") * mouseDelta;

        // x축 회전값에 제한을 건다. 
        deltaY = Mathf.Clamp(deltaY, -80, 80);

        // 오일러 앵글을 -> 쿼터니언
        Quaternion rot = new Quaternion();
        rot.eulerAngles = new Vector3(-deltaY, deltaX, 0);
        transform.rotation = rot;

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
		
	}

    // 총알을 화면 정중앙에 쏜다. 피격 이펙트 표시
    void Shoot()
    {
        // 카메라 방향 레이를 만든다. 
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        // 레이를 쏴서 hitInfo를 받아온다. 
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo))
        {
            // 만약, 맞은애가 드론이면, 
            if(hitInfo.transform.tag == "Drone")
            {
                // 드론에게 데미지를 준다. 
                Drone dr = hitInfo.transform.gameObject.GetComponent<Drone>();
                dr.OnDamage();                
            }

            // 맞았다면, 그곳에 이펙트를 이동한다.
            hitEffect.transform.position = hitInfo.point;
            hitEffect.Stop();
            hitEffect.Play();

            AudioSource.PlayClipAtPoint(rifleSound, hitInfo.point);
        }        
    }
}
