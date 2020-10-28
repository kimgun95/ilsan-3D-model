using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* gunkim의 주석 */
//FPS를 화면에 text형식으로 표출하는 기능이다.
//현재는 필요하지 않아 사용하지 않고 있다. (20.10.06)

public class FpsDisplay : MonoBehaviour
{
    int frameCount;
    float nextTime;
    [SerializeField] Text text;

    // Use this for initialization
    void Start()
    {
        nextTime = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        frameCount++;

        if (Time.time >= nextTime)
        {
            text.text = "FPS " + frameCount.ToString();
            frameCount = 0;
            nextTime += 1;
        }
    }
}