using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MakeDisappear : MonoBehaviour
{
    //The cube that will disappear and reappear
    [SerializeField]
    private GameObject disappearingCube;

    //Tells us whether the cube is active or not
    [SerializeField]
    private bool isActive = true;

    //Label for our button
    [SerializeField]
    private TMP_Text buttonLabel;

    //Coroutine delay
    public int delay = 2;

    //Calls our coroutine so we can use the onClick event attached to the button
    public void CallCoroutine()
    {
        StartCoroutine(DisappearReappear());    //Start our DisappearReappear() coroutine
    }

    //Make the cube disappear or reappear after a specified delay
    IEnumerator DisappearReappear()
    {
        yield return new WaitForSeconds(delay); //Waits for delay seconds

        if (isActive)                           //If the cube is active...
        {
            disappearingCube.SetActive(false);  //...Make it disappear,
            buttonLabel.text = "Make Reappear"; //Change the button label,
            isActive = false;                   //And change the boolean for next time.
        } else
        {                                       //If the cube is NOT active...
            disappearingCube.SetActive(true);   //...Make it reappear,
            buttonLabel.text = "Make Disappear";//Change the button label,
            isActive = true;                    //And change the boolean back
        }

        yield return null;
    }

}
