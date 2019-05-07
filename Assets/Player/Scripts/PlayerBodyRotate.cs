using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyRotate : MonoBehaviour
{
    const int rotateLimitY = 10;

    const float rotateSpeedY = 0.3f;

    float bodyRotateY = 0.00f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //機体の角度調整
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            bodyRotateY += rotateSpeedY;
            Debug.Log("右キーが押された。");
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            bodyRotateY -= rotateSpeedY;
            Debug.Log("左キーが押された。");
        }
        else
        {
            if (bodyRotateY > rotateSpeedY)
            {
                bodyRotateY -= rotateSpeedY;
            }
            else if (bodyRotateY < -rotateSpeedY)
            {
                bodyRotateY += rotateSpeedY;
            }
            else
            {
                bodyRotateY = 0.0f;
            }
            Debug.Log("方向キーは押されていない");
        }

        //機体の角度をクランプ
        if (bodyRotateY > rotateLimitY)
        {
            bodyRotateY = rotateLimitY;
        }
        else if (bodyRotateY < -rotateLimitY)
        {
            bodyRotateY = -rotateLimitY;
        }

        //機体の角度に代入
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(90, bodyRotateY, 0));
    }
}
