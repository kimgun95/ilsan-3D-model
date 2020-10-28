using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* gunkim의 주석 */
//카메라의 위치를 Debug.Log로 출력해주는 기능이다.
//사용하지 않는 기능이며 테스트를 위해 만든 것 같다.

public class CameraDetector : MonoBehaviour
{
    private void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        Debug.Log(pos);
    }
}
