using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PlayerState
{
    Middle = 0,
    Left = 1,
    Right = 2,
    TurnLeft = 3,
    TurnRight = 4,

}


public class TouchGesture : MonoBehaviour
{
    private Rigidbody rb;
    private Transform target;
    //
    // 摘要：
    //    默认在轨道中间
    [SerializeField]
    public PlayerState state = PlayerState.Middle;
    private bool turnLeft, turnRight;
    bool jump = false;
    bool roll = false;


    // 当前运行轨道：0是中间、1是右边、-1是左边
    private int currentTrack = 0;

    private Vector2 touch_start = Vector2.zero;
    private Vector2 touch_end = Vector2.zero;
    private Vector2 touch_delta = Vector2.zero;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // target = GetComponent<Transform>();

    }

    void Update()
    {

        touch_delta = Vector2.zero;

        jump = roll = turnLeft = turnRight = false;

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {

                touch_start = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended)
            {
                touch_end = Input.touches[0].position;
                touch_delta = touch_start - touch_end;
                if (touch_delta.x < -50)
                {
                    turnRight = true;
                }
                else if (touch_delta.x > 50)
                {
                    turnLeft = true;
                }
                else if (touch_delta.y < -50)
                {
                    jump = true;
                }
                else if (touch_delta.y > 50)
                {
                    roll = true;
                }
            }

        }

        if (turnLeft)
        {
            // if (state == PlayerState.Middle)
            // {
            //     // 左移
            //     Debug.Log("左移");
            //     state = PlayerState.Left;
            // }
            // if (state == PlayerState.Left)
            // {
            //     // 左转
            //     // state = PlayerState.Left;
            // }
            // rb.MoveRotation(Quaternion.Euler(0f, -90f, 0f));
            // if (currentTrack <= 1 && currentTrack > -1)
            // {
            //     // 左滑
            //     currentTrack--;
            //     Debug.Log("左滑至" + currentTrack + "轨道");
            //     transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
            // }
            // else if (currentTrack == -1)
            // {
            //     // 左转弯
            //     transform.Rotate(new Vector3(0f, -90f, 0f));
            // }
            // 左转弯
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        else if (turnRight)
        {
            // 右转弯
            transform.Rotate(new Vector3(0f, 90f, 0f));
            // if (state == PlayerState.Middle)
            // {
            //     // 右移
            //     Debug.Log("右移");

            // }
            // if (state == PlayerState.Right)
            // {
            //     // 右转
            // }
            // if (currentTrack >= -1 && currentTrack < 1)
            // {
            //     // 右滑
            //     // currentTrack++;
            //     // Debug.Log("右滑至" + currentTrack + "轨道");
            //     // transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
            // }
            // else if (currentTrack == 1)
            // {
            //     // 右转弯
            //     transform.Rotate(new Vector3(0f, 90f, 0f));
            // }
        }
        else if (jump)
        {
            Debug.Log("jump");
            rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
        }
        else if (roll)
        {
            Debug.Log("roll");
        }

    }
}
