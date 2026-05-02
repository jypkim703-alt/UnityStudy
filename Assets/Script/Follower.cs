using UnityEngine;
using System.Collections.Generic;  //

public class Follower : MonoBehaviour
{
    public List<GameObject> wayPoints; //list는 N개의 게임 오브젝트를 받음.
    public float speed = 5f;
    public bool turnToward = true;
    private int currentWaypointIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = wayPoints[0].transform.position;
        currentWaypointIndex = 1;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, wayPoints[currentWaypointIndex].transform.position);
        //다음 포지션까지의 거리에 따라서

        if(distance<=speed*Time.deltaTime)   // 이번 프레임에 내가 갈 수 있는 거리 계산??
        {
            transform.position = wayPoints[currentWaypointIndex].transform.position;
            currentWaypointIndex++;  //목적지 변경
            if(currentWaypointIndex>=wayPoints.Count)
             {
                currentWaypointIndex = 0; //Loop back to the first waypoint
              }
           

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
            //set rotation to face the next waypoint
            if (turnToward)
            {
                Vector3 direction = wayPoints[currentWaypointIndex].transform.position - transform.position;
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);

                }
            }
        }
    }
}
