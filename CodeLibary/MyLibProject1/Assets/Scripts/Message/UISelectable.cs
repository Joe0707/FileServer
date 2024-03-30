using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class UISelectable : MonoBehaviour, IDeselectHandler
{
    public UnityAction OnDeselectAction;
    public Selectable m_Selectable;
    void OnEnable()
    {
        m_Selectable.Select();
    }
    public void OnDeselect(BaseEventData eventData)
    {
        var ed = eventData as PointerEventData;
        if (ed == null) return;
        if (ed.hovered.Contains(this.gameObject)) return;
        if (OnDeselectAction != null)
        {
            OnDeselectAction();
        }
    }

}
