using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    void Start()
    {
        //// ���� �ػ󵵸� Ȯ���Ѵ�.
        //int myWidth = 2778;
        //int myHeight = 1284;

        //int deviceWidth = Screen.width;
        //int deviceHeigth = Screen.height;

        //Screen.SetResolution(myWidth, (int)(((float)deviceHeigth / deviceWidth) * myWidth), true);

        //// ����� �ػ� ������ �� ū ���
        //if ((myWidth / myHeight) < (deviceWidth / deviceHeigth))
        //{
        //    float newWidth = ((float)(myWidth / myHeight) / (float)(deviceWidth / deviceHeigth));
        //    Camera.main.rect = new Rect((1 - newWidth) / 2f, 0f, newWidth, 1f);
        //}
        //// ������ �ػ� ������ �� ū ���
        //else
        //{
        //    float newWidth = ((float)(myWidth / myHeight) / (float)(deviceWidth / deviceHeigth));
        //    Camera.main.rect = new Rect(0f, 0f, 1f, 1f);
        //}



        int setWidth = 2778;
        int setHeight = 1284;

        int deviceWidth = Screen.width;
        int deviceHeight = Screen.height;

        float gameAspect = (float)setWidth / setHeight; // ������ ����
        float deviceAspect = (float)deviceWidth / deviceHeight; // ����� ����

        //// �ػ� ���� (�߰��� �κ�)
        //Screen.SetResolution(setWidth, (int)(setWidth / deviceAspect), true);

        float newWidth = gameAspect / deviceAspect;  // �ʺ� ���� ����
        float newHeight = deviceAspect / gameAspect; // ���� ���� ����

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
