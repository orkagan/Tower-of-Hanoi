using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ring : MonoBehaviour
{
    private int ringSize = 0;
    public int RingSize
    {
        get { return ringSize; }
        set
        {
            ringSize = value;
            if (uiNumber)
            {
                uiNumber.text = ringSize.ToString();
            }
        }
    }

    public TMP_Text uiNumber;

    private void Awake()
    {
        uiNumber = GetComponentInChildren<TMP_Text>();
        //GetComponent<Image>().color = Random.ColorHSV(0f, 1f, 0.4f, 1f, 0.4f, 1f);
    }
}
