using UnityEngine;

public class Game : MonoBehaviour
{
    //Quick singleton yaaaaaay
    public static Game instance;
    
    public Tower selectedTower = null;

    private void Awake()
    {
        instance = this;
    }

    public void SelectTower(Tower newTower)
    {
        Debug.Log($"Clicked Tower: {newTower}");
        //No tower selected
        if (selectedTower == null)
        {
            selectedTower = newTower;
        }
        //Deselect currently selected tower
        else if (newTower == selectedTower)
        {
            selectedTower = null;
        }
        //Move ring from selected tower to new tower
        else if (newTower != selectedTower)
        {
            //TODO: Move Ring to new tower
            //Deselect towers
            selectedTower = null;
        }
        Debug.Log($"Selected Tower: {selectedTower}");
    }
}
