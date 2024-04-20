using System;
using System.Collections.Generic;
using UnityEngine;

public class AppUI {

    UIcontext ctx;

    public Action OnStartClickHandle;

    public Action OnRanksClickHandle;


    public AppUI() {
        ctx = new UIcontext();
    }

    public void Inject(Canvas canvas, ModuleAssets assetsContext){
        ctx.Inject(canvas,assetsContext);

    }

    //登入页面
    public void Panel_Login_Open() {
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

    public void Panel_Login_Close() {
        Panel_Login panel_Login = ctx.panel_Login;
        if (panel_Login != null) {
            panel_Login.Close();
        }
    }

    public void Panel_Ranks_Open() {
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

    public void Panel_Ranks_Close() {
        Panel_Ranks panel_Ranks = ctx.panel_Ranks;
        if (panel_Ranks != null) {
            panel_Ranks.Close();
        }
    }

    public void Panel_Ranks_AddElement(int typeID, float cd, float maxCd) {
        Panel_Ranks panel_Ranks = ctx.panel_Ranks;
        // !=不等于空
        if (panel_Ranks != null) {
            panel_Ranks.AddElement(typeID, cd, maxCd);
        }
    }

    public void Panel_Ranks_CDTick(int typeID, float cd, float maxCd) {
        Panel_Ranks panel_Ranks = ctx.panel_Ranks;
        if (panel_Ranks != null) {
            panel_Ranks.CDTick(typeID, cd, maxCd);
        }
    }


}