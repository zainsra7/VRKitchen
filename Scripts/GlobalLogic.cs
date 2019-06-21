using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLogic : MonoBehaviour
{
    public GameObject whiteSugarCube;
    public GameObject brownSugarCube;
    public GameObject cup;
    public GameObject teapot;
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
