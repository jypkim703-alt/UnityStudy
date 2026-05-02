using StarterAssets;
using UnityEngine;

public class WinZone : MonoBehaviour
{
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
            Animator anims = other.gameObject.GetComponent<Animator>();
            if(anims != null)
            {
                anims.SetTrigger("win");
            }
        }

    }
}
