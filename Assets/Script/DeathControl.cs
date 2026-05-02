using UnityEngine;


namespace StarterAssets
{
    public class DeathControl : MonoBehaviour
    {
        Vector3 startPoint = Vector3.zero;

        void Start()
        {
            startPoint = transform.position; //리스폰장소 설정
            Debug.Log("Player start position recorded at: " + startPoint);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Death"))
            {
                GameManager.Instance.DecreaseLife(this);
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Kill"))
            {
                GameManager.Instance.Killplayer(this); 
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
            {
                GameManager.Instance.IncreaseLife(this);
                Destroy(other.gameObject); //other는 나랑 부딪힌 옵젝이다. 
            }

        }

        public void Death()
        {
            Debug.Log("Player has died! Resetting position.");
            // reset the player position to the start point
            ThirdPersonController playerController = GetComponent<ThirdPersonController>();
            if (playerController != null)
            {
                playerController.MoveToPosition(startPoint);
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            Debug.Log(collision.collider.name);
            if (collision.gameObject.layer == LayerMask.NameToLayer("Death"))
            {
                Debug.Log("Player has died! Resetting position.");
                // reset the player position to the start point
                ThirdPersonController playerController = GetComponent<ThirdPersonController>();
                if (playerController != null)
                {
                    playerController.MoveToPosition(startPoint);
                }
            }
        }
    }
}