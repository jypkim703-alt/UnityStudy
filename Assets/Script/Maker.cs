using UnityEngine;

public class Maker : MonoBehaviour
{
    public GameObject target; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target !=null&&Input.GetMouseButtonDown(0))
        {
            //Raycadt frommouse UIspace t o  world space.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Instantiate ht e tar g e t at the hit point
                if (hit.transform.tag == "Ball") //Ball 태그를 hit햇을 때
                {
                    Destroy(hit.collider.gameObject); //해당 옵젝과 충돌된거 삭제.
                }
                else if (hit.transform.name == "Wall") //Wall이란 옵젝을 쳣을때
                {
                    Instantiate(target, hit.point, Quaternion.identity); //
                }

            }
        }
    }
}
