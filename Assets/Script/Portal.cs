using StarterAssets;
using UnityEngine;


public class Portal : MonoBehaviour
{
    public GameObject destination; //목적지
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ThirdPersonController playerController = other.gameObject.GetComponent<ThirdPersonController>();
            if (playerController != null)
            {
                playerController.MoveToPosition(destination.transform.position);
            }
        }
        

    }

}
