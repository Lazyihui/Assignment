using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Panel_RanksElement : MonoBehaviour {

    [SerializeField] Button ranksButton;

    [SerializeField] public Image ranksBg;

    public float cd;

    public float maxCd;

    public Action OnRanksClickHandle;

    int typeID;

    public void Init() { }


    public void Ctor() {
        ranksButton.onClick.AddListener(() => {
            OnRanksClickHandle.Invoke();
        });
    }

    public void Init(int typeID, float cd, float maxCd) {
        this.typeID = typeID;
        this.cd = cd;
        this.maxCd = maxCd;
    }



}