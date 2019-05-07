using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    const int rotateLimitY = 10;

    const float rotateSpeedY = 0.01f;

    const float faceFrontRotateSpeed = 0.3f;

    const float rotateSpeedX = 0.01f;

    float bodyRotateX = 0.00f;

    float bodyRotateY = 0.00f;

    public float speed = 0.1f;

    float rotateX;

    float rotateY;

    public bool reverseVerticalControl = true;
    
    // Start is called before the first frame update
    void Start()
    {
        //プレイヤー機の最初の角度を取得
        rotateX = gameObject.transform.rotation.x;
        rotateY = gameObject.transform.rotation.y;
    }

    // Update is called once per frame
    void Update()
    {
        //前方へ進む
        gameObject.transform.position += gameObject.transform.forward * speed;

        //機体の角度調整
        {
            bool rotateYFlag = false;
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                bodyRotateY += rotateSpeedY;
                rotateYFlag = true;
                Debug.Log("右キーが押された。");
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                bodyRotateY -= rotateSpeedY;
                rotateYFlag = true;
                Debug.Log("左キーが押された。");
            }

            if (rotateYFlag == false)
            {
                if (bodyRotateY > faceFrontRotateSpeed)
                {
                    bodyRotateY -= faceFrontRotateSpeed;
                }
                else if (bodyRotateY < -faceFrontRotateSpeed)
                {
                    bodyRotateY += faceFrontRotateSpeed;
                }
                else
                {
                    bodyRotateY = 0.0f;
                }
                Debug.Log("左右方向キーは押されていない");
            }
        }

        //機体の角度調整（鉛直）
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                bodyRotateX += (reverseVerticalControl) ? rotateSpeedX : -rotateSpeedX;
                Debug.Log("上キーが押された。");
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                bodyRotateX -= (reverseVerticalControl) ? rotateSpeedX : -rotateSpeedX;
                Debug.Log("下キーが押された。");
            }
            else
            {
                bodyRotateX = 0;
                Debug.Log("上下方向キーは押されていない。");
            }
        }

        //プレイヤーの進行方向を設定
        rotateX += bodyRotateX;
        rotateY += bodyRotateY;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(rotateX, rotateY, 0));
    }
}
