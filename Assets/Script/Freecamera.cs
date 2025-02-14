using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lookSpeed = 3f;
    
    private float rotationX = 0f;

    void Update()
    {
        // カメラ移動
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveY = 0;

        if (Input.GetKey(KeyCode.Space)) moveY = moveSpeed * Time.deltaTime; // 上昇
        if (Input.GetKey(KeyCode.LeftControl)) moveY = -moveSpeed * Time.deltaTime; // 下降

        transform.Translate(new Vector3(moveX, moveY, moveZ));

        // カメラ回転
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y + mouseX, 0);
    }
}
