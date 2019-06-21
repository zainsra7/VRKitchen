using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Contains logic for teapot 
 * Is responsible for
 * 1) Updating the onScreen teapot status
 * 2) Checking collision with water
 * 3) Checking collision with fire
 * Created by @zainsra7
 */
public class TeapotLogic : MonoBehaviour
{
    public GameObject globalData;
    public GameObject waterContainer;
    public Text teapotStatus;
    public int waitMilliseconds;
    int countCollisionWithFire;
    bool containsWater;
    bool waterBoiled;

    public bool isWaterboiled()
    {
        return waterBoiled;
    }
    public bool potHasWater()
    {
        return containsWater;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water")){
            containsWater = true;
            waterContainer.SetActive(true);
            updateStatus();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fire") && containsWater && !waterBoiled){
            countCollisionWithFire++;
            globalData.GetComponent<GlobalLogic>().IncrementStoveTimer(countCollisionWithFire);
            if (countCollisionWithFire == waitMilliseconds) {
                waterBoiled = true;
                updateStatus();
                globalData.GetComponent<GlobalLogic>().stopTimer();
            }
        }
    }
    private void updateStatus() {
        string display = "Teapot contains ";
        if (waterBoiled)
        {
            display += "boiled water!";
        }
        else if(containsWater)
        {
            display += "cold water!";
        }
        teapotStatus.text = display;
    }

    // Start is called before the first frame update
    void Start()
    {
        countCollisionWithFire = 0;
        containsWater = false;
        waterBoiled = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
