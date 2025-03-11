using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    void Start()
    {
        //// 나의 해상도를 확인한다.
        //int myWidth = 2778;
        //int myHeight = 1284;

        //int deviceWidth = Screen.width;
        //int deviceHeigth = Screen.height;

        //Screen.SetResolution(myWidth, (int)(((float)deviceHeigth / deviceWidth) * myWidth), true);

        //// 기기의 해상도 비율이 더 큰 경우
        //if ((myWidth / myHeight) < (deviceWidth / deviceHeigth))
        //{
        //    float newWidth = ((float)(myWidth / myHeight) / (float)(deviceWidth / deviceHeigth));
        //    Camera.main.rect = new Rect((1 - newWidth) / 2f, 0f, newWidth, 1f);
        //}
        //// 게임의 해상도 비율이 더 큰 경우
        //else
        //{
        //    float newWidth = ((float)(myWidth / myHeight) / (float)(deviceWidth / deviceHeigth));
        //    Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        //}



        int setWidth = 2778;
        int setHeight = 1284;

        int deviceWidth = Screen.width;
        int deviceHeight = Screen.height;

        float gameAspect = (float)setWidth / setHeight; // 게임의 비율
        float deviceAspect = (float)deviceWidth / deviceHeight; // 기기의 비율

        //// 해상도 설정 (추가된 부분)
        //Screen.SetResolution(setWidth, (int)(setWidth / deviceAspect), true);

        float newWidth = gameAspect / deviceAspect;  // 너비 비율 조정
        float newHeight = deviceAspect / gameAspect; // 높이 비율 조정

        if (gameAspect < deviceAspect)
        {
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f);
        }
        else
        {
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight);
        }
    }
}
