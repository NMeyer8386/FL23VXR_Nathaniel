using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopsExample : MonoBehaviour
{
    //Declaring an array of strings
    private string[] words = { "these", "are", "some", "words" };
    private int index = 0;
    private int doWhileIndex = 0;

    //Call the thing when the game starts
    private void Start()
    {
        //Print the strings to the console using a do while loop
        /* While the index of the array is less than or equal 
         * to the length of the array, loop through the thing
         * This loops once before checking if the condition is true or false */
        do
        {
            //Print the word at index
            Debug.Log(words[index]);
            //Increment index to print the next word
            index++;
        } while (doWhileIndex <= words.Length);

        //Print the strings to the console using a while loop
        /* While the index of the array is less than or equal 
         * to the length of the array, loop through the thing */
        while (index <= words.Length)
        {
            //Print the word at index
            Debug.Log(words[index]);
            //Increment index to print the next word
            index++;
        }

        //Print the strings to the console using a for loop
        //for (integer declaration; max value; incremental value)
        for (int i = 0; i < words.Length; i++)
        {
            //Print the word in the array at the index i
            Debug.Log(words[i]);
        }
    }
}
