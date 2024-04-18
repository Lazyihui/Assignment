using System;
using UnityEngine;

public class AppUI {

    public Action OnStartClickHandle;

    //登入页面
    public  void Panel_Login_Open(UIcontext ctx) {
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


}