using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeapotLogic : MonoBehaviour
{
    public GameObject globalData;
    public GameObject waterContainer;
    int countCollisionWithFire;
    public Text teapotStatus;
    bool containsWater;
    bool waterBoiled;

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
            if (countCollisionWithFire == 1000) {
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
    public bool isWaterboiled()
    {
        return waterBoiled;
    }
    public bool potHasWater()
    {
        return containsWater;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
