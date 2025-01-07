using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera thirdPersonCamera;    // Camera góc nhìn thứ ba
    public Camera firstPersonCamera;    // Camera góc nhìn thứ nhất
    public Camera hoodCamera;           // Camera trên mui xe
    public Canvas uiCanvas;             // Canvas hiển thị UI

    private int cameraIndex = 0;        // Lưu trạng thái camera hiện tại
    private Camera[] cameras;           // Mảng chứa các camera

    void Start()
    {
        // Đặt tất cả camera vào một mảng
        cameras = new Camera[] { thirdPersonCamera, firstPersonCamera, hoodCamera };

        // Kích hoạt camera thứ ba ban đầu và tắt các camera còn lại
        ActivateCamera(cameraIndex);
    }

    void Update()
    {
        // Chuyển đổi camera khi nhấn phím C
        if (Input.GetKeyDown(KeyCode.C))
        {
            cameraIndex = (cameraIndex + 1) % cameras.Length;
            ActivateCamera(cameraIndex);
        }
    }

    void ActivateCamera(int index)
    {
        // Tắt tất cả camera và chỉ bật camera tại index
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].enabled = i == index;
        }

        // Thay đổi camera của Canvas để phù hợp với camera hiện tại
        uiCanvas.worldCamera = cameras[index];
    }
}
