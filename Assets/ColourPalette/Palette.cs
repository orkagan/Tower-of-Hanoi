using UnityEngine;

[CreateAssetMenu(fileName = "Palette", menuName = "Scriptable Objects/Palette")]
public class Palette : ScriptableObject
{
    public Color backgroundColor = Color.white;
    public Color towerColor = Color.white;
    public Color[] tileColors;
}
