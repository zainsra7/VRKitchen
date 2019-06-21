using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Contains logic for cup 
 * Is responsible for
 * 1) Updating the onScreen cup status
 * 2) Checking collision with water
 * 3) Checking collision with white/brown sugar cube
 * 4) Checking collision with milk
 * Created by @zainsra7
 */
public class CupLogic : MonoBehaviour
{
    public GameObject globalState;
    public Text cupStatus;
    int numberOfWhiteCubes;
    int numberOfBrownCubes;
    bool containsTeabag;
    bool containsWater;
    bool containsBoiledWater;
    bool containsMilk;

    public int getNumberOfWhiteCubes()
    {
        return numberOfWhiteCubes;
    }
    public int getNumberOfBrownCubes()
    {
        return numberOfBrownCubes;
    }
    public bool cupHasMilk()
    {
        return containsMilk;
    }
    public bool cupHasBoiledWater()
    {
        return containsBoiledWater;
    }
    public bool cupHasTeabag()
    {
        return containsTeabag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WhiteSugar"))
        {
            numberOfWhiteCubes++;
            other.gameObject.SetActive(false);
            updateCupStatus();
        }
        else if (other.CompareTag("BrownSugar"))
        {
            numberOfBrownCubes++;
            other.gameObject.SetActive(false);
            updateCupStatus();
        }
        else if (other.CompareTag("Teabag"))
        {
            containsTeabag = true;
            other.gameObject.SetActive(false);
            updateCupStatus();
        }
        else if (other.CompareTag("Water") && !containsBoiledWater)
        {
            if (globalState.GetComponent<GlobalLogic>().potHasBoiledWater())
            {
                containsBoiledWater = true;
                updateCupStatus();
            }
            else
            {
                containsWater = true;
                updateCupStatus();
            }
        }
        else if (other.CompareTag("Milk"))
        {
            containsMilk = true;
            updateCupStatus();
        }
    }

    private void updateCupStatus()
    {
        globalState.GetComponent<GlobalLogic>().checkTeaCompletion();

        if (!containsBoiledWater && !containsWater && !containsTeabag && numberOfWhiteCubes == 0 && numberOfBrownCubes == 0 && !containsMilk)
        {
            cupStatus.text = "Cup is empty!";
        }
        else
        {
            string display = "Cup contains ";
            if (containsBoiledWater)
            {
                display += " boiled water ";
            }
            else if (containsWater)
            {
                display += " cold water ";
            }
            if (containsMilk)
            {
                if (containsWater || containsBoiledWater)
                    display += " and milk";
                else display += "milk";
            }
            if (containsTeabag)
            {
                if (containsWater || containsBoiledWater || containsMilk)
                    display += " and teabag";
                else display += "teabag";
            }
            if (numberOfWhiteCubes > 0 || numberOfBrownCubes > 0)
            {
                if (numberOfWhiteCubes > 0)
                {
                    if (!containsTeabag && !containsWater && !containsBoiledWater && !containsMilk)
                        display += numberOfWhiteCubes + " white";
                    else display += " and " + numberOfWhiteCubes + " white";
                }
                if (numberOfBrownCubes > 0)
                {
                    if (!containsTeabag && !containsWater && !containsBoiledWater && numberOfWhiteCubes == 0 && !containsMilk)
                        display += numberOfBrownCubes + " brown";
                    else display += " and " + numberOfBrownCubes + " brown";
                }
                display += " sugar cube(s)!";
            }
            else display += "!";

            cupStatus.text = display;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        numberOfBrownCubes = 0;
        numberOfWhiteCubes = 0;
        containsTeabag = false;
        containsBoiledWater = false;
        containsWater = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
