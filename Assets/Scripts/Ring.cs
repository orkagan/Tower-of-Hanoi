using UnityEngine;
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
            uiNumber.text = ringSize.ToString();
        }
    }

    public TMP_Text uiNumber;

    private void Awake()
    {
        uiNumber = GetComponentInChildren<TMP_Text>();
    }
}
