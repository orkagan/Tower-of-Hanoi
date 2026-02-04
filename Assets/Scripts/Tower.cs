using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    //public Ring[] rings;
    public Stack rings;
    public GameObject ringContainer;
    public Image selectionButton;

    private void Start()
    {
        int biggestRingSize = ringContainer.transform.childCount;
        rings = new Stack();
        //Add rings to stack
        foreach (Ring ring in ringContainer.GetComponentsInChildren<Ring>())
        {
            ring.ringSize = biggestRingSize;
            biggestRingSize--;
            rings.Push(ring);
        }
    }

    public void Clicked()
    {
        Game.instance.SelectTower(this);
    }
}
