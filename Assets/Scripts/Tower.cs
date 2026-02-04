using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    //public Ring[] rings;
    public Stack rings;
    public GameObject ringContainer;
    public CanvasGroup selectionButton;
    public Game gameInstance;

    private void Start()
    {
        int biggestRingSize = ringContainer.transform.childCount;
        rings = new Stack();
        //Add references of rings to stack
        foreach (Ring ring in ringContainer.GetComponentsInChildren<Ring>())
        {
            ring.RingSize = biggestRingSize;
            biggestRingSize--;
            rings.Push(ring);
            Debug.Log($"Ring registered: {ring}");
        }
    }

    public void Clicked()
    {
        gameInstance.SelectTower(this);
    }
}
