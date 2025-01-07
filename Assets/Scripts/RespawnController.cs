using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public Transform respawnPoint;   // Điểm trên đường đua mà xe sẽ được reset về

    void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu đối tượng rơi vào vùng là xe của người chơi
        if (other.CompareTag("Player"))
        {
            // Đặt lại vị trí của xe ở vị trí an toàn trên đường đua
            other.transform.position = respawnPoint.position;
            other.transform.rotation = respawnPoint.rotation;

            // Đặt lại vận tốc của xe để tránh xe tiếp tục rơi
            Rigidbody carRigidbody = other.GetComponent<Rigidbody>();
            if (carRigidbody != null)
            {
                carRigidbody.velocity = Vector3.zero;
                carRigidbody.angularVelocity = Vector3.zero;
            }
        }
    }
}

