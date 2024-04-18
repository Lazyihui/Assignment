using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Panel_RanksElement : MonoBehaviour {

    [SerializeField] Button ranksButton;

    [SerializeField] public Image ranksBg;

    public Action OnRanksClickHandle;

    int typeID;

    public void Init() { }


    public void Ctor() {
        ranksButton.onClick.AddListener(() => {
            OnRanksClickHandle.Invoke();
        });
    }

    public void Init(int typeID) {
        this.typeID = typeID;
    }



}