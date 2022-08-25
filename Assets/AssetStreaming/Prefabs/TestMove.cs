using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    float speed = 0.02f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            characterController.Move(transform.forward * speed);
        }
       
        SimulateMotion();
    }

    float mouseX = 0;
    float mouseY = 0;
    float mouseZ = 0;
    /// <summary>
    /// 编辑器模式用鼠标右键模拟蓝牙手柄旋转角度
    /// </summary>
    private void SimulateMotion()
    {
#if UNITY_EDITOR
        Quaternion rot;
        bool rolled = false;

        if (Input.GetMouseButton(1))
        {
            mouseX += Input.GetAxis("Mouse X") * 5;
            if (mouseX <= -180)
            {
                mouseX += 360;
            }
            else if (mouseX > 180)
            {
                mouseX -= 360;
            }
            mouseY -= Input.GetAxis("Mouse Y") * 2.4f;
            mouseY = Mathf.Clamp(mouseY, -85, 85);
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            rolled = true;
            mouseZ += Input.GetAxis("Mouse X") * 5;
            mouseZ = Mathf.Clamp(mouseZ, -85, 85);
        }
        if (!rolled)
        {
            // People don't usually leave their heads tilted to one side for long.
            mouseZ = Mathf.Lerp(mouseZ, 0, Time.deltaTime / (Time.deltaTime + 0.1f));
        }
        rot = Quaternion.Euler(mouseY, mouseX, mouseZ);
        this.transform.localRotation = new Quaternion(rot.x, rot.y, rot.z, rot.w);
#endif
    }
}
