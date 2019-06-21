using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalLogic : MonoBehaviour
{
    public GameObject whiteSugarCube;
    public GameObject brownSugarCube;
    public GameObject cup;
    public GameObject teapot;
    public int requiredWhiteSugar;
    public int requiredBrownSugar;
    public Text stoveTimer;
    public Text teaCompletionText;
    int lastWhiteCubes;
    int lastBrownCubes;

    public void createWhiteSugarCube()
    {
        int currentWhiteCubes = cup.GetComponent<CupLogic>().getNumberOfWhiteCubes();
        if (currentWhiteCubes > lastWhiteCubes)
        {
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

    public void IncrementStoveTimer(int seconds) {
        stoveTimer.text = "Stove Timer(Till 1000ms): " + seconds + "ms";
    }
    public void stopTimer() {
        stoveTimer.text = "";
    }

    public bool potHasBoiledWater() {
        return teapot.GetComponent<TeapotLogic>().isWaterboiled();
    }

    //Called from CupLogic after adding into the cup
    public void checkTeaCompletion()
    {
        //Check if Cup contains -> boiledWater, required white and brown sugar, teabag and milk
        bool boilWaterCheck = cup.GetComponent<CupLogic>().cupHasBoiledWater();
        bool milkCheck = cup.GetComponent<CupLogic>().cupHasMilk();
        bool teabagCheck = cup.GetComponent<CupLogic>().cupHasTeabag();
        int whiteCubes = cup.GetComponent<CupLogic>().getNumberOfWhiteCubes();
        int brownCubes = cup.GetComponent<CupLogic>().getNumberOfBrownCubes();

        if (boilWaterCheck && milkCheck && teabagCheck && whiteCubes >= requiredWhiteSugar && brownCubes >= requiredBrownSugar)
        {
            teaCompletionText.text = "You made white tea! Good Job!";
        }
    }
    public void checkMistakes()
    {

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
