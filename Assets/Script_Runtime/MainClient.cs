using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainClient : MonoBehaviour {

    [SerializeField] Canvas ScreenCanvas;

    public Context ctx;


    void Start() {
        Application.targetFrameRate = 120;

        // === Instantiation ====
        ctx = new Context();
        Canvas canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        Camera mainCamera = gameObject.GetComponentInChildren<Camera>();

        // ==== Injection ====
        ctx.Inject(canvas);

        // ==== Load ====

        ctx.assetsContext.Load();

        // ==== Binding ====

        // ==== Init ====

        // ==== Enter ====
        AppUI appUI = ctx.uiContext.appUI;

        appUI.Panel_Login_Open(ctx.uiContext);

        appUI.OnStartClickHandle = () => {
            Debug.Log("开始游戏  1 ddfs");
        };
    }

    void Update() {

    }
}
