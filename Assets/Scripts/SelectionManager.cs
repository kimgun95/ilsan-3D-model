using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* gunkim의 주석 */
//기존에 있던 응집침전지, 농축조, 배출수지에 대해 마우스로 선택을 하게 되면 outline을 그려주는 기능을 수행한다.
//현재는 사용하지 않는 중이다. (20.10.06)

public class SelectionManager : MonoBehaviour
{
    [SerializeField] Outline[] outlines;

    // Start is called before the first frame update
    void Start()
    {
        DisableAllOutLine();
    }

    void DisableAllOutLine()
    {
        foreach (Outline ol in outlines)
        {
            ol.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                DisableAllOutLine();
                Outline outline = hit.transform.GetComponent<Outline>();
                outline.enabled = /*!outline.enabled*/true;

                //objectName.text = hit.transform.name;
                //if (hit.transform.name != "Terrain")
                //{
                //    DisableAllOutLine();
                //    Outline outline = hit.transform.GetComponent<Outline>();
                //    outline.enabled = /*!outline.enabled*/true;

                //    objectName.text = hit.transform.name;
                //}
                //else
                //{
                //    objectName.text = "";
                //}
            }
        }
            
    }
}
