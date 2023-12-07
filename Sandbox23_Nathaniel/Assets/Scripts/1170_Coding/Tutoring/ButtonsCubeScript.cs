using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class ButtonsCubeScript : MonoBehaviour
{
    //Declare booleans
    [SerializeField]
    bool thingA;
    [SerializeField]
    bool thingB;
    [SerializeField]
    bool thingC;
    [SerializeField]
    bool cubeActive;

    //Declare gameobject to make active or not
    [SerializeField]
    GameObject cube;

    /*
     * 
     * void ButtonPress(){
     *  if (button is thingA){
     *    thingA = true;
     *  }
     *  if (button is thingB){
     *    thingB = true;
     *  }
     *  if (button is thingC){
     *    thingC = true;
     *  }
     *  
     *  if (any thing is false){
     *    make cube dissapear;
     *  }
     *  if (all things are true){
     *    make cube appear;
     *  }
     * }
     * 
     */

    /*
     * Function that changes booleans on button press 
     * and checks to see if they are all true
     * 
     * Is passed a string that corresponds to the button that is pressed
     */
    public void ButtonPress(string thing)
    {
        if (thing == "thingA")  //If the string (button) is thingA...
        {
            thingA = !thingA;   //...flip the thingA boolean
        }
        else if (thing == "thingB") //If it isn't thingA, do the same check but for thingB
        {
            thingB = !thingB;
        }
        else if (thing == "thingC")
        {
            thingC = !thingC;
        }

        if (thingA && thingB && thingC) //If all booleans are true...
        {
            cube.SetActive(true);       //Nake the cube appear
        }
                                        //If any boolean is false...
        else
        {
            cube.SetActive(false);      //Make the cube disappear
        }
    }
}
