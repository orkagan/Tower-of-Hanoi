using UnityEngine;

public class Tower : MonoBehaviour
{
    public void Clicked()
    {
        Game.instance.SelectTower(this);
    }
}
