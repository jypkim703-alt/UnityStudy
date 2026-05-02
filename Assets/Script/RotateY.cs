using UnityEngine;

public class RotateY : MonoBehaviour

{                       //상수는 특정한 숫자 딱 넣어둔거.
    public float speed; //변수는 public float ~~~; 만들어서 Inspector창에 변수 넣어만드는 거. 클래스 생성이 됨.


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()  //괄호가 있는건 전부 함수이다
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime * speed, 0);  //초당 60도 돌기에 한바퀴에 6초가 걸린다
                                                         //델타타임이 머지. 컴퓨터간 성능차이를 보정해준다..
    }
}
