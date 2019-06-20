﻿using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;


/* Sugar Logic class
 * Cloning the sugarcube: Record starting position and current position and if the offset in x & y axis is more than the threshold,
 * create a clone of the cube at the starting position
 */
public class SugarLeverLogic : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public string cubeType;
    public GameObject globalState;

    protected virtual void OnEnable()
    {
        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        controllable.ValueChanged += ValueChanged;
        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
    {
    }

    protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
            if (cubeType == "white")
            {
                globalState.GetComponent<GlobalLogic>().createWhiteSugarCube();
            }
            else if (cubeType == "brown")
            {
                globalState.GetComponent<GlobalLogic>().createBrownSugarCube();
            }
    }

    protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
    }
}
