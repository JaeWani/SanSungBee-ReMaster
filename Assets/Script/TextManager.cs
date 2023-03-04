using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextManager : Singleton<TextManager>
{   
    [Header ("텍스트 관리")]
    [SerializeField] GameObject TextPrefeb;
    [SerializeField]Canvas canvas;
    [SerializeField] List<GameObject> objs = new List<GameObject>(); // 텍스트 오브젝트를 직접적으로 관리해주는 리스트
    [SerializeField]List<TextInfo> objScript = new List<TextInfo>(); //텍스트 오브젝트에 들어있는 스크립트를 담아주는 리스트

    [SerializeField] List<string> TextKind = new List<string>(); // 랜덤하게 나올 텍스트들을 담아주는 리스트
    public void ObjScriptSet(int index) // objs 리스트의 TextInfo를 인덱스 번호에 맞게 할당해주는 함수
    {
        objScript[index] = objs[index].GetComponent<TextInfo>();
    }
    public void CheckText(string txt)
    {
        foreach(GameObject obj in objs)
        {
            TextInfo info = obj.GetComponent<TextInfo>();
            Debug.Log(info.OrignalText);
            Debug.Log(txt);
            if(info.OrignalText == txt) 
            {
                Destroy(obj.gameObject);
                Debug.Log("조건문 통과");
            }
        }
    }
    public void SpawnLogic(float SpawnDelay)
    {
        StartCoroutine(_Spawn());
        IEnumerator _Spawn()
        {
            _SpawnText();
            yield return new WaitForSeconds(SpawnDelay);
            StartCoroutine(_Spawn());
        }
    }
    void _SpawnText() // 랜덤한 지정된 장소에 Text를 생성 및 초기 값을 할당 해주는 함수
    {
        GameObject obj = Instantiate(TextPrefeb,canvas.transform); // TextPrefeb을 canvas의 자식으로 하나 생성 후 obj 변수에 할당
        TextInfo info = obj.GetComponent<TextInfo>(); // obj 에서 TextInfo 클래스를 참조해서 info 변수에 할당
        _SetWord(info,_RandomWord()); //_SetWord 함수를 호출해서 info의 OrignalText 및 charText의 값을 할당
        int pos = Random.Range(-845,845); // pos 변수의 값을 -845 ~ 845로 할당
        obj.transform.localPosition = new Vector3(pos,586,0); // obj의 위치를 지정
        objs.Add(obj); // objs 리스트에 obj 할당
        int index = objs.IndexOf(obj);
        ObjScriptSet(index); // 할당 완료 후 ObjScriptSet 함수를 호출해 TextInfo를 새로 할당
    }
    void _SetWord(TextInfo info, string text)
    {
        info.OrignalText = text;
        info.charText = text.ToCharArray();
    }
    string _RandomWord()
    {
        int rand = Random.Range(0,TextKind.Count);
        return TextKind[rand];
    }
    void Start()
    {
    }

    void Update()
    {
        
    }
}
