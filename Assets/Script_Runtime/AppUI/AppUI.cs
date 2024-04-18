using System;
using UnityEngine;

public class AppUI {

    public Action OnStartClickHandle;

    public Action OnRanksClickHandle;

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

    public void Panel_Ranks_AddElement(UIcontext ctx, int typeID) {
        Panel_Ranks panel_Ranks = ctx.panel_Ranks;
        if (panel_Ranks != null) {
            panel_Ranks.AddElement(typeID);
        }
    }

    public void Panel_Ranks_CDTick(int typeID, float cd, float maxCd) {
        

    }


}