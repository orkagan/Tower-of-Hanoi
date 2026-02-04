using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Tower[] towers;
    private Tower selectedTower;
    public Tower SelectedTower
    {
        get { return selectedTower; }
        set
        {
            selectedTower = value;
            ChangeSelectionUI();
        }
    }

    private void Start()
    {
        //Get instances of towers
        towers = GetComponentsInChildren<Tower>();
        //Assign reference so that they can call SelectTower function
        foreach (Tower tower in towers)
        {
            tower.gameInstance = this;
        }
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
        //Pop ring from one tower (typecast as Ring)
        Ring movingRing = (Ring)fromTower.rings.Pop();
        toTower.rings.Push(movingRing);
        //Reparent actual game object
        movingRing.transform.SetParent(toTower.ringContainer.transform, false);
        //Deselect towers
        SelectedTower = null;
    }

    public void ChangeSelectionUI()
    {
        foreach (Tower tower in towers)
        {
            if (selectedTower == tower)
            {
                //tower.selectionButton.color = Color.white;
                tower.selectionButton.alpha = 1;
            }
            else
            {
                //tower.selectionButton.color = new Color(0, 0, 0, 0);
                tower.selectionButton.alpha = 0;
            }
        }
    }
}
