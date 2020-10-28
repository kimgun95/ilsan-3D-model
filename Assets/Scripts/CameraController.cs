using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* gunkim의 주석 */
//카메라 컨트롤 기능이다. 키보드에서 w,a,s,d,q,e,r각각의 기능을 넣어주었다.

public class CameraController : MonoBehaviour
{
    CamMode currentCamMode = CamMode.Orthographic;

    [SerializeField, Range(0.1f, 100.0f)]
    private float positionStep = 100.0f;
    
    [SerializeField, Range(30.0f, 150.0f)]
    private float mouseSensitive = 90.0f;
    
    private Camera cam;
    private Transform camTransform;
    private float originCamSize;

    private float camSize;
    [SerializeField] private float minCamSize = 10f;
    [SerializeField] private float maxCamSize = 130f;

    [SerializeField] bool isApplyDistanceLimit;
    
    [SerializeField] private Vector2 distanceLimitX;
    [SerializeField] private Vector2 distanceLimitY;

    private Vector3 startMousePos;
    private Vector3 presentCamRotation;
    private Vector3 presentCamPos;
    private Vector3 originPosition;
    private Quaternion originCamRotation;

    void Start()
    {
        cam = GetComponent<Camera>();
        camTransform = gameObject.transform;
        originPosition = gameObject.transform.localPosition;
        originCamRotation = gameObject.transform.rotation;

        originCamSize = cam.orthographic ? cam.orthographicSize : cam.fieldOfView;
    }

    void Update()
    {
        ResetCameraTransform();
        CameraZoomControl();
        CameraRotationControl();
        CameraMoveControl();
        CameraMoveControlByKey();

        if(isApplyDistanceLimit) ApplyLimitDistance();
    }
    
    public void SetCamMode(CamMode camMode)
    {
        currentCamMode = camMode;
    }

    private void CameraZoomControl()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            camSize = cam.orthographic ? cam.orthographicSize : cam.fieldOfView;

            camSize -= Input.mouseScrollDelta.y * 2f;

            if (maxCamSize < camSize) camSize = maxCamSize;

            if (camSize < minCamSize) camSize = minCamSize;

            if (cam.orthographic)
                cam.orthographicSize = camSize;
            else
                cam.fieldOfView = camSize;
        }
    }

    private void CameraRotationControl()
    {
        if (Input.GetMouseButtonDown(1))
        {
            startMousePos = Input.mousePosition;
            presentCamRotation.x = camTransform.transform.eulerAngles.x;
            presentCamRotation.y = camTransform.transform.eulerAngles.y;
        }

        if (Input.GetMouseButton(1))
        {
            float x = (startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (startMousePos.y - Input.mousePosition.y) / Screen.height;

            float accel = cam.orthographic ? cam.orthographicSize : cam.fieldOfView;
            
            float eulerX = (currentCamMode == CamMode.Top) ? 90f : presentCamRotation.x + y * mouseSensitive;
            float eulerY = presentCamRotation.y - x * mouseSensitive;

            if (90f < eulerX) eulerX = 90f;
            else if (eulerX < 5f) eulerX = 5f;

            camTransform.rotation = Quaternion.Euler(eulerX, eulerY, 0);
        }
    }

    private void ApplyLimitDistance()
    {
        Vector3 v3 = camTransform.position;

        //if (camTransform.position.x < distanceLimitX.x)
        //{
        //    v3.x = distanceLimitX.x;
        //}
        //else if (distanceLimitX.y < camTransform.position.x)
        //{
        //    v3.x = distanceLimitX.y;
        //}

        if (camTransform.position.y < distanceLimitY.x)
        {
            v3.y = distanceLimitY.x;
        }
        else if (distanceLimitY.y < camTransform.position.y)
        {
            v3.y = distanceLimitY.y;
        }

        camTransform.position = v3;
    }
    
    private void CameraMoveControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startMousePos = Input.mousePosition;
            presentCamPos = camTransform.position;
        }

        if (Input.GetMouseButton(0))
        {
            float x = (startMousePos.x - Input.mousePosition.x) / Screen.width;
            float y = (startMousePos.y - Input.mousePosition.y) / Screen.height;

            float accel = cam.orthographic ? cam.orthographicSize : cam.fieldOfView;

            x = x * positionStep * (accel / 16);
            y = y * positionStep * (accel / 16);

            Vector3 velocity = camTransform.rotation * new Vector3(x, y, 0);
            velocity = velocity + presentCamPos;
            camTransform.position = velocity;
        }
    }

    private void CameraMoveControlByKey()
    {
        Vector3 camPos = camTransform.position;
        float camRotY = camTransform.rotation.eulerAngles.y;

        if (Input.GetKey(KeyCode.D)) { camPos += camTransform.right * Time.deltaTime * positionStep; }
        if (Input.GetKey(KeyCode.A)) { camPos -= camTransform.right * Time.deltaTime * positionStep; }

        if (Input.GetKey(KeyCode.W))
        {
            if (cam.orthographic)
                camPos += camTransform.up * Time.deltaTime * positionStep;
            else
                camPos += camTransform.forward * Time.deltaTime * positionStep;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (cam.orthographic)
                camPos -= camTransform.up * Time.deltaTime * positionStep;
            else
                camPos -= camTransform.forward * Time.deltaTime * positionStep;
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            if (cam.orthographic)
                camRotY += Time.deltaTime * positionStep;
            else
                camPos -= camTransform.up * Time.deltaTime * positionStep; ;
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (cam.orthographic)
                camRotY -= Time.deltaTime * positionStep;
            else
                camPos += camTransform.up * Time.deltaTime * positionStep; ;
        }
        
        camTransform.position = camPos;
        camTransform.localRotation = Quaternion.Euler(camTransform.rotation.eulerAngles.x, camRotY, camTransform.rotation.eulerAngles.z);
    }

    private void ResetCameraTransform()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetTransform();
    }

    public void ResetTransform()
    {
        gameObject.transform.localPosition = originPosition;
        gameObject.transform.rotation = originCamRotation;
        cam.orthographicSize = cam.fieldOfView = originCamSize;
    }
}