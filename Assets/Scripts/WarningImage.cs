using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningImage : MonoBehaviour
{
    public GameObject warningImageUI;
    public Image warningImage;
    public static WarningImage Instance;

    private void Awake()
    {
        WarningImage.Instance = this;
    }

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
