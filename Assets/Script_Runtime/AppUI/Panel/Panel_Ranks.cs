using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Ranks : MonoBehaviour {
    [SerializeField] public Panel_RanksElement ranksElements;

    [SerializeField] Transform selectGroup;

    Dictionary<int, Panel_RanksElement> ranksEle;

    public Action OnRanksClickHandle;

    public Panel_Ranks() {
        ranksEle = new Dictionary<int, Panel_RanksElement>();
    }

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
        ranksEle.Add(typeID,ele);

    }

    public void CDTick(int typeID,float cd,float maxCd) {
        bool has = ranksEle.TryGetValue(typeID, out Panel_RanksElement ranksElement);
        if (!has) {
            Debug.Log("没有ele");
            return;
        }

        ranksElement.SetCd(cd,maxCd);
    }

  

}