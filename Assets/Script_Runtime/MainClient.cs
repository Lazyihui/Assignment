using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainClient : MonoBehaviour {

    [SerializeField] Canvas ScreenCanvas;

    public Context ctx;

    bool isGame = false;
    float time;

    float cd;
    float maxCd;

    void Start() {
        Application.targetFrameRate = 120;
        cd = 0.5f;
        maxCd = 0.5f;

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
            appUI.Panel_Login_Close(ctx.uiContext);
            appUI.Panel_Ranks_Open(ctx.uiContext);



            appUI.Panel_Ranks_AddElement(ctx.uiContext, 1, cd, maxCd);
            isGame = true;
        };

        appUI.OnRanksClickHandle = () => {
            Debug.Log("小兵");
        };
    }




    void Update() {
        float dt = Time.deltaTime;

        if (isGame) {
            AppUI appUI = ctx.uiContext.appUI;
            if (Input.GetMouseButtonDown(0)) {
                cd -= 0.1f;
                appUI.Panel_Ranks_CDTick(1, cd, maxCd);
            }
        }

    }


}
