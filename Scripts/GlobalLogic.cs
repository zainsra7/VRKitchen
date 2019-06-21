using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Contains global state of the VR Kitchen 
 * Is responsible for
 * 1) Creating SugarCubes
 * 2) Starting/Stopping Stove Timer
 * 3) Checking completion of the experiment and mistakes made by user
 * 4) Being a medium in exchanging information between items
 * Created by @zainsra7
 * Reference to downloaded assets are at the end of this file
 */
public class GlobalLogic : MonoBehaviour
{
    public GameObject whiteSugarCube;
    public GameObject brownSugarCube;
    public GameObject cup;
    public GameObject teapot;
    public GameObject stove; //StoveLever
    public GameObject sink; //SinkLever
    public GameObject mistakesBoard;
    public Text stoveTimer;
    public Text teaCompletionText;
    public Text mistakes;
    public int requiredWhiteSugar;
    public int requiredBrownSugar;
    int lastWhiteCubes;
    int lastBrownCubes;

    //Sugar Functions
    public void createWhiteSugarCube()
    {
        int currentWhiteCubes = cup.GetComponent<CupLogic>().getNumberOfWhiteCubes();
        if (currentWhiteCubes > lastWhiteCubes)
        {
            //Position is relative to the cup's position
            Instantiate(whiteSugarCube, new Vector3(cup.transform.position.x + 1.07f,cup.transform.position.y, cup.transform.position.z), Quaternion.identity);
            lastWhiteCubes = currentWhiteCubes;
        }
    }
    public void createBrownSugarCube()
    {
        int currentBrownCubes = cup.GetComponent<CupLogic>().getNumberOfBrownCubes();
        if (currentBrownCubes > lastBrownCubes)
        {
            Instantiate(brownSugarCube, new Vector3(cup.transform.position.x + 1.37f, cup.transform.position.y, cup.transform.position.z), Quaternion.identity);
            lastBrownCubes = currentBrownCubes;
        }
    }

    //Timer Functions
    public void IncrementStoveTimer(int seconds) {
        stoveTimer.text = "Stove Timer(Till 1000ms): " + seconds + "ms";
    }
    public void stopTimer() {
        stoveTimer.text = "";
    }

    public void checkTeaCompletion()
    {
        /*
         * Assuming that a Tea can be made by just adding boiling water and teabag
         * So forgetting to add Milk and SugarCubes would be considered as a mistake
         */
        bool boilWaterCheck = cup.GetComponent<CupLogic>().cupHasBoiledWater();
        bool milkCheck = cup.GetComponent<CupLogic>().cupHasMilk();
        bool teabagCheck = cup.GetComponent<CupLogic>().cupHasTeabag();
        int whiteCubes = cup.GetComponent<CupLogic>().getNumberOfWhiteCubes();
        int brownCubes = cup.GetComponent<CupLogic>().getNumberOfBrownCubes();

        if (boilWaterCheck && teabagCheck)
        {
            teaCompletionText.text = "Good! You just made tea!!";
            checkMistakes(whiteCubes, brownCubes, milkCheck);
        }
    }
    public void checkMistakes(int whiteCubes, int brownCubes, bool milkCheck)
    {
        /*
         * Mistakes made after completing the Tea
         * 1) Adding more or less sugar than required
         * 2) Forgot to turn off stove or tap (Can also be checked during the experiment)
         * 3) Forgot to add sugar cubes
         */

        mistakesBoard.SetActive(true);
        string display = "";
        int countMistakes = 0;
        if (whiteCubes > requiredWhiteSugar)
        {
            display += "~ " + (whiteCubes - requiredWhiteSugar) + " more white sugar cubes added than required\n";
            countMistakes++;
        }
        else if (whiteCubes < requiredWhiteSugar)
        {
            if (whiteCubes == 0)
            {
                display += "~ " + "Forgot to add white sugar cubes\n";
            }
            else
            {
                display += "~ " + "Needed to add " + (requiredWhiteSugar - whiteCubes) + " more white sugar cubes\n";
            }
            countMistakes++;
        }
        if (brownCubes > requiredBrownSugar)
        {
            display += "~ " + (brownCubes - requiredBrownSugar) + " more brown sugar cubes added than required\n";
            countMistakes++;
        }
        else if (brownCubes < requiredBrownSugar)
        {
            if (brownCubes == 0)
            {
                display += "~ " + "Forgot to add brown sugar cubes\n";
            }
            else
            {
                display += "~ " + "Needed to add " + (requiredBrownSugar - brownCubes) + " more brown sugar cubes\n";
            }
            countMistakes++;
        }
        if (!milkCheck)
        {
            display += "~ " + "Forgot to add milk\n";
            countMistakes++;
        }
        if (stove.GetComponent<StoveLeverLogic>().isStoveOn())
        {
            display += "~ " + "Forgot to turn off the stove\n";
            countMistakes++;
        }
        if (sink.GetComponent<SinkLeverLogic>().isTapOn())
        {
            display += "~ " + "Forgot to turn off the tap\n";
            countMistakes++;
        }
        if (display != "")
        {
            if (countMistakes == 1)
            {
                display = "You made " + countMistakes + " mistake :(\n" + display;
            }
            else
            {
                display = "You made " + countMistakes + " mistakes :/ \n" + display;
            }
        }
        else
        {
            display += "You made no mistakes and followed all the requirements of making white tea!! Great Job!";
        }
        mistakes.text = display;

    }
    
    //Called by Cup
    public bool potHasBoiledWater() {
        return teapot.GetComponent<TeapotLogic>().isWaterboiled();
    }

    // Start is called before the first frame update
    void Start()
    {
        lastBrownCubes = 0;
        lastWhiteCubes = 0;
    }
    // Update is called once per frame
    void Update()
    {

    }
}

/*
 * VRKitchen - Using VRTKv3 
 * Following *free* assets are downloaded from Unity AssetStore for this project:
 * ~ Kitchen (Model) - "Simple Home Stuff" by MOHELM97
 * ~ Utentils - "Tableware for your Kitchen" by SEVASTIAN MAREVOY
 * ~ Water animation - "Rusty Water Tank" by FLAMINGSANDS
 * ~ Fire animation - "Fire & Spell effects" by DIGITAL RUBY (JEFF JOHNSON)
 */
