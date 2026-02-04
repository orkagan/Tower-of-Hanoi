using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    //Quick singleton yaaaaaay
    public static Game instance;

    private Tower[] towers;
    private Tower selectedTower = null;
    public Tower SelectedTower
    {
        get { return selectedTower; }
        set
        {
            selectedTower = value;
            //Update selection UI
            foreach (Tower tower in towers)
            {
                if (selectedTower == tower)
                {
                    tower.selectionButton.color = Color.white;
                }
                else
                {
                    tower.selectionButton.color = new Color(0, 0, 0, 0);
                }
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        towers = GetComponentsInChildren<Tower>();
    }

    public void SelectTower(Tower newTower)
    {
        //If no tower selected, and target has rings
        if (SelectedTower == null & newTower.rings.Count != 0)
        {
            SelectedTower = newTower;
        }
        //Deselect currently selected tower
        else if (newTower == SelectedTower)
        {
            SelectedTower = null;
        }
        //Move ring from selected tower to new tower
        else if (newTower != SelectedTower)
        {
            //Move Ring if tower has no rings
            if (newTower.rings.Count == 0)
            {
                MoveRing(SelectedTower, newTower);
            }
            //Move Ring to new tower if ring on top of new tower is bigger than the ring being moved
            else if (((Ring)newTower.rings.Peek()).RingSize > ((Ring)SelectedTower.rings.Peek()).RingSize)
            {
                Debug.Log($"{((Ring)newTower.rings.Peek()).RingSize} > {((Ring)SelectedTower.rings.Peek()).RingSize}");
                MoveRing(SelectedTower, newTower);
            }
        }
        Debug.Log($"Selected Tower: {SelectedTower}");
    }

    public void MoveRing(Tower fromTower, Tower toTower)
    {
        Ring movingRing = (Ring)fromTower.rings.Pop();
        toTower.rings.Push(movingRing);
        movingRing.transform.SetParent(toTower.ringContainer.transform, false);
        //Deselect towers
        SelectedTower = null;
    }
}
