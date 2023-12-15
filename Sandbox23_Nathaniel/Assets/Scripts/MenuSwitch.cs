using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VInspector;

public class MenuSwitch : MonoBehaviour
{
    [SerializeField] GameObject placementMenu;
    [SerializeField] GameObject instructionsMenu;

    [Button]
    public void SwitchToPlacement()
    {
        instructionsMenu.SetActive(false);
        placementMenu.SetActive(true);
    }

    [Button]
    public void SwitchToInstructions()
    {
        placementMenu.SetActive(false);
        instructionsMenu.SetActive(true);
    }
}
