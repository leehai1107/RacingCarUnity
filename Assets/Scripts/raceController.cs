using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Nếu sử dụng TextMeshPro
using UnityEngine.UI;

public class raceController : MonoBehaviour
{
    private float speed;
    private Vector3 lastPosition;
    private Vector3 previousVelocity;

    private float maxTiltAngle;
    private float maxAccelerationThreshold;

    // Tham chiếu đến bảng cảnh báo
    public GameObject warningPanel; // Bảng cảnh báo
    public Text warningText; // Văn bản cảnh báo

    void Start()
    {
        lastPosition = transform.position;
        previousVelocity = GetComponent<Rigidbody>().velocity;

        maxTiltAngle = 15.0f;
        maxAccelerationThreshold = 10.0f;

        // Ẩn bảng cảnh báo ban đầu
        warningPanel.SetActive(false);
    }

    void Update()
    {
        CalculateSpeed();
        CheckStability();
        LimitCarSpeed();
    }

    void CalculateSpeed()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        speed = rb.velocity.magnitude * 3.6f; // Tính tốc độ bằng km/h
    }

    void LimitCarSpeed()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (speed > 260f)
        {
            rb.velocity = rb.velocity.normalized * (260f / 3.6f);
        }
    }

    void CheckStability()
    {
        Vector3 angles = transform.rotation.eulerAngles;
        float tilt = angles.z;
        if (Mathf.Abs(tilt) > maxTiltAngle)
        {
            DisplayWarning("Cảnh báo: Xe nghiêng quá mức!");
        }

        Vector3 currentVelocity = GetComponent<Rigidbody>().velocity;
        Vector3 acceleration = (currentVelocity - previousVelocity) / Time.deltaTime;
        if (acceleration.magnitude > maxAccelerationThreshold)
        {
            DisplayWarning("Cảnh báo: Xe rung lắc mạnh!");
        }

        previousVelocity = currentVelocity;
    }

    void DisplayWarning(string message)
    {
        warningText.text = message; // Thiết lập nội dung văn bản cảnh báo
        warningPanel.SetActive(true); // Hiển thị bảng cảnh báo

        // Có thể thiết lập thời gian hiển thị bảng cảnh báo (tùy chọn)
        StartCoroutine(HideWarningPanel());
    }

    private IEnumerator HideWarningPanel()
    {
        yield return new WaitForSeconds(3); // Hiển thị trong 3 giây
        warningPanel.SetActive(false); // Ẩn bảng cảnh báo
    }
}
