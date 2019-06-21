using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;


/* Stove lever Logic class
 * Cloning the sugarcube: Record starting position and current position and if the offset in x & y axis is more than the threshold,
 * create a clone of the cube at the starting position
 */
public class StoveLeverLogic : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public GameObject globalState;
    public Text displayText;
    public GameObject fire;
    bool stoveOn = false;


    public bool isStoveOn() {
        return stoveOn;
    }

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
