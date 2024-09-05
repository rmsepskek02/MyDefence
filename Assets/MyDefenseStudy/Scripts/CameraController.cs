using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f; // 카메라 이동 속도
    public float panBorderThickness = 10f; // 화면 가장자리 경계 두께 (마우스 위치 감지용)
    public float zoomSpeed = 10f;
    public float minDistance = 20f;
    public float maxDistance = 70f;
    public bool isMove = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        EnableCamera();
        if (isMove == false) return;
        InputKeyboard();
        InputMouse();
        InputMouseWheel();
    }

    void InputKeyboard()
    {
        if (Input.GetKey(KeyCode.A)) { transform.Translate(Vector3.left * Time.deltaTime); }
        if (Input.GetKey(KeyCode.D)) { transform.Translate(Vector3.right * Time.deltaTime); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(Vector3.down * Time.deltaTime); }
        if (Input.GetKey(KeyCode.W)) { transform.Translate(Vector3.up * Time.deltaTime); }
    }

    void InputMouse()
    {
        // 마우스가 화면의 왼쪽 끝에 있을 때
        if (Input.mousePosition.x <= panBorderThickness)
            transform.Translate(Vector3.left * Time.deltaTime);
        // 마우스가 화면의 오른쪽 끝에 있을 때
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            transform.Translate(Vector3.right * Time.deltaTime);
        // 마우스가 화면의 아래쪽 끝에 있을 때
        if (Input.mousePosition.y <= panBorderThickness)
            transform.Translate(Vector3.down * Time.deltaTime);
        // 마우스가 화면의 위쪽 끝에 있을 때
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
            transform.Translate(Vector3.up * Time.deltaTime);
    }

    void InputMouseWheel()
    {
        float zoomAmount = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed * 100f;

        if (transform.position.y >= 70f && zoomAmount < 0)
            zoomAmount = 0;
        if (transform.position.y <= 20f && zoomAmount > 0)
            zoomAmount = 0;

        transform.Translate(Vector3.forward * zoomAmount * Time.deltaTime);
    }

    void EnableCamera()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isMove = !isMove;
    }
}
