using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject fxFactory;

    private void OnCollisionEnter(Collision collision)
    {
        //폭발 이펙트 보여주기
        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;
        //이펙트 오브젝트가 저절로 사라지지 않는 경우
        //Destroy(fx, 2.0f);    //2초 후에 폭발 이펙트 삭제
       
        //충돌체 삭제
        //if(collision.collider.name!="Ground") Destroy(collision.gameObject);
        //자기자신 삭제 (맨마지막에 처리)
        Destroy(gameObject);
    }
}
