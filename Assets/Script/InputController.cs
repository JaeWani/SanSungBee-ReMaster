using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputController : Singleton<InputController>
{
    [SerializeField] TextMeshProUGUI TextBox;
    public string InputText;
    TMP_InputField Field;
    void Start()
    {
        Field = GetComponent<TMP_InputField>();
        Field.onSubmit.AddListener(delegate{_GetInput();});
    }
    void Update()
    {
    
    }
    void _GetInput()
    {
        Field.ActivateInputField(); // inputField 포커스를 맞춰준다.
        InputText = TextBox.text;
        TextManager.Instance.CheckText(InputText);
    }
}
