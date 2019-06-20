using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;


/* Sugar Logic class
 * Cloning the sugarcube: Record starting position and current position and if the offset in x & y axis is more than the threshold,
 * create a clone of the cube at the starting position
 */
public class SugarLeverLogic : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public Text displayText;
    public string outputOnMax = "Maximum Reached";
    public string outputOnMin = "Minimum Reached";
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
        if (displayText != null)
        {
            if (e.value == 0.0f)
            {
                displayText.text = "OFF";
            }
            else {
                
                displayText.text = "ON";
            }
        }
    }

    protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        if (outputOnMax != "")
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
    }

    protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
    }
}
