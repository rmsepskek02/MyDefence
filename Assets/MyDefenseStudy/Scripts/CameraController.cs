using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 20f; // ī�޶� �̵� �ӵ�
    public float panBorderThickness = 10f; // ȭ�� �����ڸ� ��� �β� (���콺 ��ġ ������)
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
        // ���콺�� ȭ���� ���� ���� ���� ��
        if (Input.mousePosition.x <= panBorderThickness)
            transform.Translate(Vector3.left * Time.deltaTime);
        // ���콺�� ȭ���� ������ ���� ���� ��
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
            transform.Translate(Vector3.right * Time.deltaTime);
        // ���콺�� ȭ���� �Ʒ��� ���� ���� ��
        if (Input.mousePosition.y <= panBorderThickness)
            transform.Translate(Vector3.down * Time.deltaTime);
        // ���콺�� ȭ���� ���� ���� ���� ��
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
