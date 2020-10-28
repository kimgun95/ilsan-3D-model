using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* gunkim의 주석 */
//HUD의 위치를 이동시키는 역할을 한다.
//UI 이동시 rectTransform을 이용하는 것이 그냥 Transform을 이용하는 것보다 에러를 만날 확률이 줄어든다고 한다.

public class HudControl : MonoBehaviour
{
    RectTransform rectTransform = null;
    [SerializeField] Transform target = null;

    public Image bgImage;
    public Text nameText;
    [SerializeField] Text[] keyText;

    [SerializeField] public Text[] valueText;
    [SerializeField] public Image[] statusImage;
    [SerializeField] public ParticleSystem[] water;
    //public Text valueText;
    //public Text valueTextHumidity;
    //public Text valueTextAmmonia;
    //public Text valueTextChlorine;
    //public Text valueTextHydrogenSulphide;
    //public Text valueTextMercaptan;
    //public Text valueTextMethane;
    [SerializeField] Image[] warningImage;
    //public Text statText;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.position = RectTransformUtility.WorldToScreenPoint(Camera.main, target.position);
    }
}