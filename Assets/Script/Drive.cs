using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 5f;
    public float angularSpeed = 120f; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //read joystick 나는없지만 조이스틱을 연동할 떙
        float v = Input.GetAxis("Vertical"); 
        if(v!=0)
        {
            transform.Translate(0, 0, Time.deltaTime * speed * v);
        }

        v = Input.GetAxis("Horizontal");
        if (v != 0)
        {
            transform.Rotate(0, -Time.deltaTime * angularSpeed*v, 0);
        }
    }
}
