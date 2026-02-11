using UnityEngine;
using UnityEngine.UI;

public class PaletteManager : MonoBehaviour
{
    public Image backgroundImage;
    public Image[] towerImages;
    public Image[] tileImages;

    public Palette currentPalette;
    public Palette currentPalette_prop
    {
        get
        {
            return currentPalette;
        }
        set
        {
            currentPalette = value;
            backgroundImage.color = currentPalette.backgroundColor;

            foreach (Image towerImage in towerImages)
            {
                towerImage.color = currentPalette.towerColor;
            }

            for (int i = 0; i < tileImages.Length; i++)
            {
                tileImages[i].color = currentPalette.tileColors[i % currentPalette.tileColors.Length];
            }
        }
    }

    private void Start()
    {
        currentPalette_prop = currentPalette;
    }
}
