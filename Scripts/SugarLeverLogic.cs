using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;
/*
 * Contains logic for sugar lever
 * Is responsible for
 *  Cloning/Creating white/brown sugar cube (by calling GlobalLogic)
 * Created by @zainsra7
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
