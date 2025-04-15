using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PreventDeselect : MonoBehaviour
{
    public TMP_InputField inputField;
    void Update()
    {
        if (inputField.isFocused == false)
        {
            EventSystem.current.SetSelectedGameObject(inputField.gameObject, null);
            inputField.OnPointerClick(new PointerEventData(EventSystem.current));
        }
    }
}
