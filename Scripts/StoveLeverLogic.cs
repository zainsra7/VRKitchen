using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;
/*
 * Contains logic for stove lever
 * Is responsible for
 *  Animating fire on stove (turning stove on/off)
 * Created by @zainsra7
 */
public class StoveLeverLogic : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public GameObject globalState;
    public GameObject fire;
    public Text displayText;
    bool stoveOn = false;

    public bool isStoveOn() {
        return stoveOn;
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
        fire.SetActive(true);
        stoveOn = true;
        displayText.text = "ON";
    }

    protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        fire.SetActive(false);
        stoveOn = false;
        displayText.text = "OFF";
    }
}
