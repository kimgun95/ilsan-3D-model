using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectController : MonoBehaviour
{
    [SerializeField] CamMode camMode = CamMode.Orthographic;
    [SerializeField] Text camModeText;
    [SerializeField] Text descriptionText;
    [SerializeField] Text dateText;
    [SerializeField] Text notifyText;

    [SerializeField] GameObject panelObj;
    [SerializeField] Text nameText;
    [SerializeField] Text valueText;
    [SerializeField] Text statText;
    
    [SerializeField] GameObject[] cameraList;
    [SerializeField] HudControl[] hudList;
    [SerializeField] Outline[] outlines;
    [SerializeField] SmokeControl[] smokeList;
    [SerializeField] GameObject[] pipeList;

    HudControl currentSelectedObject;

    Color green;
    Color red;
    Color yellow;
    Color blue;
    Color gray;
    Color black;
    Color orange;
    Color yellowOrange;
    Color orangeRed;
    Color deadRed;
    Color deadYellow;
    Color deadGreen;

    float duration = 0.5f;
    float smoothness = 0.02f;

    int flag = 0;
    int signal = 0;
    private Color originColor;

    private void Start()
    {
        DisableAllOutLine();
        black = new Color(Color.black.r, Color.black.g, Color.black.b, 1);
        yellow = new Color(1, 0.92f, 0.016f, 1);
        deadYellow = new Color(1, 0.7f, 0.1f, 1);
        //yellowOrange = new Color(1, 0.75f, 0, 1);
        //orange = new Color(255, 0.5f, 0, 1);
        //orangeRed = new Color(255, 0.25f, 0, 1);
        red = new Color(1, 0, 0, 1);
        deadRed = new Color(0.7f, 0.1f, 0.1f, 1);
        //gray = new Color(Color.gray.r, Color.gray.g, Color.gray.b, 1);
        blue = new Color(Color.blue.r, Color.blue.g, Color.blue.b, 1);
        green = new Color(0, 1, 0, 1);
        deadGreen = new Color(0.1f, 0.7f, 0.1f, 1);

        originColor = WarningImage.Instance.warningImage.color;
    }

    [Obsolete]
    private void Update()
    {
        dateText.text = DateTime.UtcNow.AddHours(9).ToString();

        if(flag != 0)
        {
            WarningImage.Instance.warningImageUI.SetActive(true);
            float flicker = Mathf.Abs(Mathf.Sin(Time.time * 0.4f * flag));
            WarningImage.Instance.warningImage.color = originColor * flicker;
        }
        else
            WarningImage.Instance.warningImageUI.SetActive(false);

        if(signal == 1)
        {
            //hudList[2].statusImage[6].gameObject.SetActive(true);
            float flicker = Mathf.Abs(Mathf.Sin(Time.time * 0.4f * 7));
            for(int i=0;i<5;i++)
                hudList[2].statusImage[i].color = yellow * flicker;
        }else if(signal == 2)
        {
            float flicker = Mathf.Abs(Mathf.Sin(Time.time * 0.4f * 7));
            for (int i = 0; i < 5; i++)
                hudList[2].statusImage[i].color = red * flicker;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeSmokeColor(0, 1);
            ChangeSmokeColor(1, 1);
            for(int i=0;i<7;i++)
            {
                hudList[0].valueText[i].color = green;
                hudList[1].valueText[i].color = green;
            }
            for (int i = 2; i < 7; i++)
            {
                hudList[0].valueText[i].text = "0.0 ppm";
                hudList[1].valueText[i].text = "0.0 ppm";
            }
            hudList[0].valueText[4].color = red;
            hudList[0].valueText[4].text = "2.3 ppm";
            hudList[1].valueText[3].color = red;
            hudList[1].valueText[3].text = "1.9 ppm";

            flag = 1;
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeSmokeColor(0, 2);
            ChangeSmokeColor(1, 2);
            for (int i = 0; i < 7; i++)
            {
                hudList[0].valueText[i].color = green;
                hudList[1].valueText[i].color = green;
            }
            for (int i = 2; i < 7; i++)
            {
                hudList[0].valueText[i].text = "0.0 ppm";
                hudList[1].valueText[i].text = "0.0 ppm";
            }
            hudList[0].valueText[3].color = red;
            hudList[0].valueText[3].text = "2.6 ppm";
            hudList[1].valueText[5].color = red;
            hudList[1].valueText[5].text = "3.0 ppm";

            flag = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeSmokeColor(0, 3);
            ChangeSmokeColor(1, 3);
            for (int i = 0; i < 7; i++)
            {
                hudList[0].valueText[i].color = green;
                hudList[1].valueText[i].color = green;
            }
            for (int i = 2; i < 7; i++)
            {
                hudList[0].valueText[i].text = "0.0 ppm";
                hudList[1].valueText[i].text = "0.0 ppm";
            }
            hudList[0].valueText[2].color = red;
            hudList[0].valueText[2].text = "4.5 ppm";
            hudList[0].valueText[5].color = red;
            hudList[0].valueText[5].text = "5.0 ppm";
            hudList[1].valueText[4].color = red;
            hudList[1].valueText[4].text = "5.2 ppm";
            hudList[1].valueText[5].color = red;
            hudList[1].valueText[5].text = "4.8 ppm";

            flag = 3;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeSmokeColor(0, 4);
            ChangeSmokeColor(1, 4);
            for (int i = 0; i < 7; i++)
            {
                hudList[0].valueText[i].color = green;
                hudList[1].valueText[i].color = green;
            }
            for (int i = 2; i < 7; i++)
            {
                hudList[0].valueText[i].text = "0.0 ppm";
                hudList[1].valueText[i].text = "0.0 ppm";
            }
            hudList[0].valueText[4].color = red;
            hudList[0].valueText[4].text = "7.7 ppm";
            hudList[0].valueText[3].color = red;
            hudList[0].valueText[3].text = "8.2 ppm";
            hudList[1].valueText[6].color = red;
            hudList[1].valueText[6].text = "8.9 ppm";
            hudList[1].valueText[2].color = red;
            hudList[1].valueText[2].text = "9.3 ppm";

            flag = 4;
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ChangeSmokeColor(0, 5);
            ChangeSmokeColor(1, 5);
            for (int i = 0; i < 7; i++)
            {
                hudList[0].valueText[i].color = green;
                hudList[1].valueText[i].color = green;
            }
            for (int i = 2; i < 7; i++)
            {
                hudList[0].valueText[i].text = "0.0 ppm";
                hudList[1].valueText[i].text = "0.0 ppm";
            }
            hudList[0].valueText[2].color = red;
            hudList[0].valueText[2].text = "10.0 ppm";
            hudList[0].valueText[6].color = red;
            hudList[0].valueText[6].text = "11.1 ppm";
            hudList[1].valueText[4].color = red;
            hudList[1].valueText[4].text = "10.9 ppm";
            hudList[1].valueText[3].color = red;
            hudList[1].valueText[3].text = "13.0 ppm";

            flag = 5;
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ChangeSmokeColor(0, 6);
            ChangeSmokeColor(1, 6);
            for (int i = 0; i < 7; i++)
            {
                hudList[0].valueText[i].color = green;
                hudList[1].valueText[i].color = green;
            }
            for (int i = 2; i < 7; i++)
            {
                hudList[0].valueText[i].text = "0.0 ppm";
                hudList[1].valueText[i].text = "0.0 ppm";
            }

            flag = 0;
        }
        //관로 누수
        if (Input.GetKeyDown(KeyCode.Z))
        {
            hudList[2].nameText.text = "Pipe Leak";
            pipeList[0].SetActive(false);
            pipeList[1].SetActive(true);
            pipeList[2].SetActive(false);
            pipeList[3].SetActive(false);
            ChangeLineColor(1);
            for (int i = 0; i < 19; i++)
                hudList[2].water[i].startColor = new Color(0.35f, 0.5f, 1, 1);
        }
        //관로 파손
        if (Input.GetKeyDown(KeyCode.X))
        {
            hudList[2].nameText.text = "Pipe Damage";
            pipeList[0].SetActive(false);
            pipeList[1].SetActive(false);
            pipeList[2].SetActive(true);
            pipeList[3].SetActive(true);
            ChangeLineColor(2);
            for (int i = 0; i < 19; i++)
                hudList[2].water[i].startColor = new Color(0.35f, 0.5f, 1, 0);
        }
        //관로 파손 및 누수
        if (Input.GetKeyDown(KeyCode.C))
        {
            hudList[2].nameText.text = "Pipe Damage & Leak";
            pipeList[0].SetActive(false);
            pipeList[1].SetActive(false);
            pipeList[2].SetActive(true);
            pipeList[3].SetActive(true);
            ChangeLineColor(3);
            for (int i = 0; i < 19; i++)
                hudList[2].water[i].startColor = new Color(0.35f, 0.5f, 1, 1);
        }
        //정상
        if (Input.GetKeyDown(KeyCode.V))
        {
            hudList[2].nameText.text = "Pipe Normal";
            pipeList[0].SetActive(true);
            pipeList[1].SetActive(false);
            pipeList[2].SetActive(false);
            pipeList[3].SetActive(false);
            ChangeLineColor(4);
            for(int i = 0; i < 19; i++)
                hudList[2].water[i].startColor = new Color(0.35f, 0.5f, 1, 0);
        }

        //if (Input.GetKeyDown(KeyCode.F1))
        //    ChangeStat(0);

        //if(Input.GetKeyDown(KeyCode.F2))
        //    ChangeStat(1);

        //if(Input.GetKeyDown(KeyCode.F3))
        //    ChangeStat(2);

        //DetectClickedObject();
    }

    //void DetectClickedObject()
    //{
    //    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            DisableAllOutLine();
    //            Outline outline = hit.transform.GetComponent<Outline>();
    //            outline.enabled = true;

    //            int index = 0;

    //            foreach (Outline ol in outlines)
    //            {
    //                if (ol == outline)
    //                {
    //                    currentSelectedObject = hudList[index];
    //                    SetText();
    //                }

    //                index++;
    //            }

    //            //if (panelObj.activeInHierarchy == false)
    //            //{
    //            //    panelObj.SetActive(true);
    //            //}
    //        }
    //    }
    //}

    //void SetText()
    //{
    //    if (currentSelectedObject != null)
    //    {
    //        nameText.text = currentSelectedObject.nameText.text;
    //        valueText.text = currentSelectedObject.valueText.text;
    //        statText.text = currentSelectedObject.statText.text;
    //    }
    //}

    void DisableAllOutLine()
    {
        foreach (Outline ol in outlines)
        {
            ol.enabled = false;
        }
    }

    //void ChangeStat(int index)
    //{
    //    if(hudList[index] != null)
    //    {
    //        //currentSelectedObject = hudList[index];

    //        Color targetColor;

    //        if (hudList[index].bgImage.color == green)
    //        {
    //            targetColor = red;
    //            hudList[index].statText.text = "이상";
    //            notifyText.text = hudList[index].nameText.text + " 이상 발생";
    //        }
    //        else
    //        {
    //            targetColor = green;
    //            hudList[index].statText.text = "정상";
    //            notifyText.text = "";
    //        }

    //        SetText();
    //        StartCoroutine(LerpColor(index, targetColor));
    //    }
    //}

    [Obsolete]
    void ChangeSmokeColor(int index, int stepColor)
    {
        if(smokeList[index] != null)
        {
            if (index==0)
                StartCoroutine(LerpColor(index, stepColor));
            else if(index==1)
                StartCoroutine(LerpColor(index, stepColor));
        }
    }

    [Obsolete]
    void ChangeLineColor(int index)
    {
        StartCoroutine(LerpLineColor(index));
    }

    [Obsolete]
    IEnumerator LerpColor(int index, int stepColor)
    {
        float progress = 0;
        float increment = smoothness / duration;

        while (progress < 1)
        {
            
            if (index==0)
            {
                for (int i = 0; i < 11; i++)
                    smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, black, progress);
                if (stepColor == 1)
                    for (int i = 0; i < 1; i++)
                        smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, yellow, progress);
                else if (stepColor == 2)
                    for (int i = 0; i < 3; i++)
                        smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, yellow, progress);
                else if (stepColor == 3)
                    for (int i = 0; i < 5; i++)
                        smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, yellow, progress);
                else if (stepColor == 4)
                    for (int i = 0; i < 7; i++)
                        smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, yellow, progress);
                else if (stepColor == 5)
                    for (int i = 0; i < 11; i++)
                        smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, yellow, progress);
            }
            if (index == 1)
            {
                for (int i = 0; i < 11  ; i++)
                    smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, black, progress);
                if (stepColor == 1)
                    for (int i = 0; i < 1; i++)
                        smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, yellow, progress);
                else if (stepColor == 2)
                    for (int i = 0; i < 3; i++)
                        smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, yellow, progress);
                else if (stepColor == 3)
                    for (int i = 0; i < 5; i++)
                        smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, yellow, progress);
                else if (stepColor == 4)
                    for (int i = 0; i < 7; i++)
                        smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, yellow, progress);
                else if (stepColor == 5)
                    for (int i = 0; i < 11; i++)
                        smokeList[index].smoke[i].startColor = Color.Lerp(smokeList[index].smoke[i].startColor, yellow, progress);
            }
            progress += increment;

            yield return new WaitForSeconds(smoothness);
        }

        yield return null;
    }

    [Obsolete]
    IEnumerator LerpLineColor(int index)
    {
        float progress = 0;
        float increment = smoothness / duration;

        while (progress < 1)
        {
            if (index == 1)
                signal = 1;
            if (index == 2 || index == 3)
                signal = 2;
            if (index == 4)
            {
                for (int i = 0; i < 5; i++)
                    hudList[2].statusImage[i].color = Color.Lerp(hudList[2].statusImage[i].color, green, progress);
                signal = 0;
            }
                
            
            progress += increment;

            yield return new WaitForSeconds(smoothness);
        }

        yield return null;
    }

    

    public void ChangeViewMode()
    {
        foreach (var go in cameraList)
        {
            go.SetActive(false);
        }

        CameraController camController = cameraList[(int)camMode].GetComponentInChildren<CameraController>();
        camController.ResetTransform();
        
        camMode = (camMode == CamMode.Perspective) ? CamMode.Orthographic : camMode + 1;

        camController = cameraList[(int)camMode].GetComponentInChildren<CameraController>();
        camController.SetCamMode(camMode);
        cameraList[(int)camMode].SetActive(true);
        
        camModeText.text = "뷰모드 : " + camMode.ToString();
        descriptionText.text = (camMode == CamMode.Perspective) ?
            "카메라 이동 : W, A, S, D, Q, E, 마우스 좌클릭 이동 / 카메라 회전 : 마우스 우클릭 이동 / 카메라 리셋 : R" :
            "카메라 이동 : W, A, S, D, 마우스 좌클릭 이동 / 카메라 회전 : Q, E, 마우스 우클릭 이동 / 카메라 리셋 : R";
    }
    
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
