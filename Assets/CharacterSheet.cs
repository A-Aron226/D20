
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Stats : MonoBehaviour
{

    [SerializeField] string nameChar;
    [SerializeField] int proficiency;
    [SerializeField] [RangeAttribute(-5, 5)] int str, dex;
    [SerializeField] bool finesse;
    int hit, enemy, pHealth, eHealth;

    // Start is called before the first frame update
    void Start()
    {
        pHealth = 100;
        eHealth = 100;
        enemy = Random.Range(10, 21); //randomizes enemy armor rating
        if (finesse) //calculates hit modifer if finesse is true or not
        {
            if (str > dex)
            {
                hit = str + proficiency;
            }
            else
            {
                hit = dex + proficiency;
            }
        }

        else
        {
            hit = str + proficiency;
        }

        if (hit > 0)
        {
            Debug.Log(nameChar + "'s hit modifer is +" + hit);
        }
        else
        {
            Debug.Log(nameChar + "'s hit modifer is " + hit);
        }
        Debug.Log(nameChar + "'s has " + pHealth + " in total");

        Debug.Log("Enemy's armor class is " + enemy + " and has " + eHealth + " health in total");

        Debug.Log("Press 'R' to roll the D20 die to attack the enemy."); //prompts user to hit the 'r' key

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r")) //updates events every time 'r' is pressed
            {
            int dice = Random.Range(1, 21); //simulates a d20 dice
            Debug.Log(nameChar + " rolled a " + dice);

            if (dice + hit > enemy)
            {
                eHealth -= (dice + hit); //calculates remaining enemy health
                Debug.Log("The enemy has been hit! The enemy now has " + eHealth + ". Roll again for another strike!");


            }

            else
            {
                pHealth -= Random.Range(5, 11); //calculates remaining player health
                Debug.Log(nameChar + "'s strike missed the enemy." + nameChar + " now has " + pHealth + " left! Roll again to strike!");


            }

            if (eHealth <= 0)
            {
                Debug.Log(nameChar + " has defeated the enemy and emerges victorious!");
                UnityEditor.EditorApplication.isPlaying = false; //exits editor play mode once player or enemy health reaches zero or below
            }

            if (pHealth <= 0)
            {
                Debug.Log(nameChar + " fell in battle and lost!");
                UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
}
