using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UITip : MonoBehaviour
{
    public Text m_TipText;  //便签文字
    public UISelectable m_Selectable;//可选择的UI
    public GameObject m_TipPanel;//便签面板
    void Awake()
    {
        m_Selectable.OnDeselectAction += OnTipPanelDeselect;
    }

    void OnTipPanelDeselect()
    {
        gameObject.SetActive(false);
    }

    public void Init(string tipMessage, Vector3 position)
    {
        m_TipText.text = tipMessage;
        if (gameObject.activeInHierarchy == false)
        {
            gameObject.SetActive(true);
        }
        m_TipPanel.transform.position = position;
    }
}
