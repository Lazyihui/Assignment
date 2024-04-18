using System;
using System.Collections.Generic;
using UnityEngine;

public class AppUI {

    public Action OnStartClickHandle;

    public Action OnRanksClickHandle;

    Dictionary<int, Panel_RanksElement> ranksEle;

    public AppUI() {
        ranksEle = new Dictionary<int, Panel_RanksElement>();
    }

    //登入页面
    public void Panel_Login_Open(UIcontext ctx) {
        Panel_Login panel_Login = ctx.panel_Login;
        if (panel_Login == null) {

            bool has = ctx.assetsContext.TryGetUIPrefab("Panel_Login", out GameObject prefab);
            if (has == false) {
                Debug.LogError("prefab==null err");
                return;
            }

            panel_Login = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Login>();
            panel_Login.Ctor();
            panel_Login.OnStartClickHandle = () => {
                OnStartClickHandle.Invoke();
                // ctx.events.Login_StartGame();
            };
            ctx.panel_Login = panel_Login;
        }
        panel_Login.Show();
    }

    public void Panel_Login_Close(UIcontext ctx) {
        Panel_Login panel_Login = ctx.panel_Login;
        if (panel_Login != null) {
            panel_Login.Close();
        }
    }

    public void Panel_Ranks_Open(UIcontext ctx) {
        Panel_Ranks panel_Ranks = ctx.panel_Ranks;

        if (panel_Ranks == null) {
            bool has = ctx.assetsContext.TryGetUIPrefab("Panel_Ranks", out GameObject prefab);
            if (has == false) {
                Debug.LogError("prefab==null err");
                return;
            }

            panel_Ranks = GameObject.Instantiate(prefab, ctx.canvas.transform).GetComponent<Panel_Ranks>();
            panel_Ranks.Ctor();
            panel_Ranks.Init();
            panel_Ranks.OnRanksClickHandle = () => {
                OnRanksClickHandle.Invoke();
            };
            ctx.panel_Ranks = panel_Ranks;
        }
        panel_Ranks.Show();

    }

    public void Panel_Ranks_Close(UIcontext ctx) {
        Panel_Ranks panel_Ranks = ctx.panel_Ranks;
        if (panel_Ranks != null) {
            panel_Ranks.Close();
        }
    }

    public void Panel_Ranks_AddElement(UIcontext ctx, int typeID, float cd, float maxCd) {
        Panel_Ranks panel_Ranks = ctx.panel_Ranks;
        if (panel_Ranks != null) {
            panel_Ranks.AddElement(typeID, cd, maxCd);
            ranksEle.Add(typeID, panel_Ranks.ranksElements);
        }
    }

    public void Panel_Ranks_CDTick(int typeID, float cd, float maxCd) {

        bool has = ranksEle.TryGetValue(typeID, out Panel_RanksElement ranksElements);
        if (!has) {
            Debug.Log("没有ele");
            return;
        }

        ranksElements.SetCd(cd, maxCd);
    }


}