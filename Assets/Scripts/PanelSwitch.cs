using UnityEngine;

public class PanelSwitch : MonoBehaviour
{
    public void SwitchToPanel(GameObject panelToSwitchTo)
    {
        GameObject parent = transform.parent.gameObject;
        panelToSwitchTo.SetActive(true);
        parent.SetActive(false);
    }
}
