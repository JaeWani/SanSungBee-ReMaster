using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextScript : MonoBehaviour
{
    TextInfo info;
    TextMeshProUGUI tmp;
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        info = GetComponent<TextInfo>();
        _SetText();
        _Move();
    }
    void _Move()
    {
        float moveDelay = 3 / (int)GameManager.Instance.CurrentDifficulty;
        StartCoroutine(_move());
        IEnumerator _move()
        {
            var pos = transform.localPosition;
            transform.localPosition = new Vector3(pos.x,pos.y - 100,pos.z);
            yield return new WaitForSeconds(moveDelay);
            StartCoroutine(_move());
        }
    }
    void _SetText()
    {
        int index = 0;
        foreach(char text in info.charText)
        {
            string setText = tmp.text;
            tmp.text = setText + info.charText[index];
            index++;
        }
    }
}
