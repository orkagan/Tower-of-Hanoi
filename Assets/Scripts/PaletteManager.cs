using UnityEngine;
using UnityEngine.UI;

public class PaletteManager : MonoBehaviour
{
    public Image backgroundImage;
    public Image[] towerImages;
    public Image[] ringImages;

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

            for (int i = 0; i < ringImages.Length; i++)
            {
                ringImages[i].color = currentPalette.tileColors[i % currentPalette.tileColors.Length];
            }
        }
    }

    private void Start()
    {
        //Find all child towers and get referrences to image componenets
        Tower[] foundTowers = GetComponentsInChildren<Tower>();
        Image[] foundTowerImages = new Image[foundTowers.Length];
        for (int i = 0; i < foundTowers.Length; i++)
        {
            foundTowerImages[i] = foundTowers[i].GetComponent<Image>();
        }
        towerImages = foundTowerImages;

        //Find all child rings and get referrences to image componenets
        Ring[] foundRings = GetComponentsInChildren<Ring>();
        Image[] foundRingImages = new Image[foundRings.Length];
        for (int i = 0; i < foundRings.Length; i++)
        {
            foundRingImages[i] = foundRings[i].GetComponent<Image>();
        }
        ringImages = foundRingImages;
        
        if (currentPalette!=null) currentPalette_prop = currentPalette;
    }
}
