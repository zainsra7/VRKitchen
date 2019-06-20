using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupLogic : MonoBehaviour
{
    public GameObject globalState;
    public Text cupStatus;
    int numberOfWhiteCubes;
    int numberOfBrownCubes;
    bool containsTeabag;

    public int getNumberOfWhiteCubes()
    {
        return numberOfWhiteCubes;
    }
    public int getNumberOfBrownCubes()
    {
        return numberOfBrownCubes;
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
        else if (other.CompareTag("Teabag")) {
            containsTeabag = true;
            other.gameObject.SetActive(false);
            updateCupStatus();
        }
    }

    private void updateCupStatus()
    {

        if (!containsTeabag && numberOfWhiteCubes == 0 && numberOfBrownCubes == 0)
        {
            cupStatus.text = "Cup is empty!";
        }
        else
        {
            string display = "Cup contains ";
            if (containsTeabag)
            {
                display += "Teabag";
            }
            if (numberOfWhiteCubes > 0 || numberOfBrownCubes > 0)
            {
                if (numberOfWhiteCubes > 0)
                {
                    if (!containsTeabag)
                        display += numberOfWhiteCubes + " white";
                    else display += " and " + numberOfWhiteCubes + " white";
                }
                if (numberOfBrownCubes > 0)
                {
                    if (!containsTeabag && numberOfWhiteCubes == 0)
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
