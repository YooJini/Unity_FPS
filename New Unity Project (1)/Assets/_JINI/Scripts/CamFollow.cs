using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    //카메라가 플레이어를 따라다니기
    //플레이어에 카메라를 종속시켜도 상관없다.
    //하지만 게임에따라서 드라마틱한 연출이 필요한 경우에
    //1인칭 -> 3인칭 또는 그반대로 변경이 쉽다.
    //또한 순간이동이 아닌 꼬랑지가 따라다니는 것과 같은 효과도 연출 가능하다.
    //지금은 단순히 눈역할이므로 그냥 순간이동 시킨다.

    //public Transform target;    //카메라가 따라다닐 타겟

    public Transform target1st;
    public Transform target3rd;

    public float followSpeed = 10.0f;
    bool isFps = true;
   

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        //카메라 위치를 강제로 타겟 위치에 고정
        //transform.position = target.position;

        //FollowTarget();

        //1인칭 <-> 3인칭 
        ChangeView();

        
    }

    private void ChangeView()
    {
        if (Input.GetKeyDown("1")) isFps = true;
        if (Input.GetKeyDown("3")) isFps = false;

        if (isFps)
            //카메라 위치를 강제로 타겟 위치에 고정
            transform.position = target1st.position;
        else
            transform.position = target3rd.position;
    }

    //타겟 따라다니기
    private void FollowTarget()
    {
        
        //타겟 방향 구하기 (벡터의 뺄셈)
        //방향 = 타겟 - 자기자신
       //Vector3 dir = target.position - transform.position;
       //dir.Normalize();    //방향만 쓰는 거라서 반드시 정규화를 시켜줘야 함
       //transform.Translate(dir * followSpeed * Time.deltaTime);
       //
       ////카메라가 타겟 위치에 도착했을 때 덜덜덜 떨리는 문제점
       //if(Vector3.Distance(transform.position,target.position)<1.0f)
       //{
       //    transform.position = target.position;
       //}
    }
}
