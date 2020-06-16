using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed=5.0f;
    CharacterController charCtrl;

    //중력 적용 
    public float gr = -20;
    float velocityY;     //낙하속도 (Velocity는 방향과 힘을 가짐)

    float jumpSpeed = 10;
    int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        charCtrl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        //대각선 이동 속도를 상하좌우 속도와 동일하게 만들기
        //게임에따라 일부러 대각선은 빠르게 이동하도록 하는 경우도 있다
        //이럴 경우에는 정규화 X
        //dir.Normalize();    

        //transform.Translate(dir * speed * Time.deltaTime);

        //카메라가 보는 방향으로 이동해야 한다.
        dir = Camera.main.transform.TransformDirection(dir);
        //transform.Translate(dir * speed * Time.deltaTime);

        //심각한 문제: 하늘 날아다님, 땅 뚫음, 충돌처리 안됨
        //캐릭터컨트롤러 컴포넌트를 사용한다
        //캐릭터컨트롤러는 충돌감지만 하고 물리 적용은 안된다
        //따라서 충돌감지를 하기 위해서는 반드시
        //캐릭터컨트롤러 컴포넌트가 제공해주는 함수로 이동처리 해야 함
        //charCtrl.Move(dir*speed*Time.deltaTime);

        //중력적용하기
       //velocityY += gr * Time.deltaTime;
       //dir.y = velocityY;
       //charCtrl.Move(dir * speed * Time.deltaTime);

        //캐릭터 점프
        //점프버튼을 누르면 수직속도에 점프 파워를 넣는다.
        //땅에 닿으면 0으로 초기화
       //if(charCtrl.isGrounded) //땅에 닿았냐
       //{
       //}
        if(charCtrl.collisionFlags==CollisionFlags.Below)
        {
            velocityY = 0;
            jumpCount = 0;
        }
        else
        {
            velocityY += gr * Time.deltaTime;
            dir.y = velocityY;
        }
        if (Input.GetButtonDown("Jump")&&jumpCount<2)
        {
            jumpCount++;
            velocityY = jumpSpeed;
        }

        //중력적용 이동
        charCtrl.Move(dir * speed * Time.deltaTime);
    }

    
}
