using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControl
{

    public class PlayerController : MonoBehaviour
    {
        //刚体
        private new Rigidbody2D rigidbody2D;
        //动画器
        private Animator animator;
        //是否在地面
        private bool isGround = false;
        //计时器
        private float timer = 0;
        //力量
        public float force = 200f;


        void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            //按下鼠标左键
            if (Input.GetMouseButtonDown(0))
            {
                //开始计时
                timer = 0;
            }
            //持续按下左键
            if (Input.GetMouseButton(0))
            {
                //计时
                timer += Time.deltaTime;
            }
            //松开鼠标左键
            if (Input.GetMouseButtonUp(0) && isGround == true)
            {
                //给一个力
                rigidbody2D.AddForce(new Vector2(-1, 1) * timer * force);
                //播放跳跃动画
                animator.SetTrigger("Jump");
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.tag == "Ground")
            {
                isGround = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.collider.tag == "Ground")
            {
                isGround = false;
            }
        }
    }
}

