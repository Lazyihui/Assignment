using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Ranks : MonoBehaviour {
    [SerializeField] public Panel_RanksElement ranksElements;

    [SerializeField] Transform selectGroup;

    public Action OnRanksClickHandle;

    public void Ctor() { }

    public void Init() { }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void AddElement(int typeID,float cd,float maxCd) {

        Panel_RanksElement ele = GameObject.Instantiate(ranksElements, selectGroup);

        ele.Ctor();
        ele.SetCd(cd,maxCd);
        ele.OnRanksClickHandle = () => {
            OnRanksClickHandle.Invoke();
        };
        ele.Init(typeID);
    }

  

}