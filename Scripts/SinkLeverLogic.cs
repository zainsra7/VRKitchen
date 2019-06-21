using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;
/*
 * Contains logic for sink lever
 * Is responsible for
 *  Animating water from tap (turning tap on/off)
 * Created by @zainsra7
 */
public class SinkLeverLogic : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public GameObject globalState;
    public GameObject water;
    public Text displayText;
    bool tapOn = false;


    public bool isTapOn()
    {
        return tapOn;
    }

    //Functions of "Controllable Reactor" Script from VRTK3
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
        water.SetActive(true);
        tapOn = true;
        displayText.text = "ON";
    }

    protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        water.SetActive(false);
        tapOn = false;
        displayText.text = "OFF";
    }
}
