using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletImpactFactory;

    public GameObject bombPrefab;
    float power = 2;

 
    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        //마우스 왼쪽 버튼 클릭시 레이캐스트로 총알 발사
        if (Input.GetMouseButtonDown(0))
        {

            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //충돌 지점에 총알이펙트 생성
                GameObject bulletImpact = Instantiate(bulletImpactFactory);
                bulletImpact.transform.position = hit.point;
                //파편이펙트
                //hit의 법선벡터를 forward로 하여 튀는 방향 설정해주기
                bulletImpact.transform.forward = hit.normal;
            }

            //레이어 마스크 사용 충돌처리 (최적화)
            //유니티 내부적으로 속도향상을 위해 비트연산 처리가 된다.
            //총 32비트를 사용하기 때문에 레이어도 32개까지 추가 가능
            //int layer = gameObject.layer;
            //layer = 1 << 8;
            //if (Physics.Raycast(ray, out hit,100,layer))    //layer만 충돌, ~layer: layer만 충돌 제외
            //{
            //}
        }
        //마우스 오른쪽 버튼 클릭시 수류탄 투척
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombPrefab,Camera.main.transform.position,Camera.main.transform.rotation);
            Rigidbody bombRigid = bomb.GetComponent<Rigidbody>();
            bombRigid.AddForce((transform.up + transform.forward)*power,ForceMode.Impulse);
            //ForceMode.Acceleration    => 연속적인 힘을 가한다. 질량의 영향 X
            //ForceMode.Force           => 연속적인 힘을 가한다. 질량의 영향 O
            //ForceMode.Impulse         => 순간적인 힘을 가한다. 질량의 영향 O
            //ForceMode.VelocityChange  => 순간적인 힘을 가한다. 질량의 영향 X
                
            
        }
    }
}
