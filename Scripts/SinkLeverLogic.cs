using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;


/* Stove lever Logic class
 * Cloning the sugarcube: Record starting position and current position and if the offset in x & y axis is more than the threshold,
 * create a clone of the cube at the starting position
 */
public class SinkLeverLogic : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public GameObject globalState;
    public Text displayText;
    public GameObject water;
    bool tapOn = false;


    public bool isTapOn()
    {
        return tapOn;
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
