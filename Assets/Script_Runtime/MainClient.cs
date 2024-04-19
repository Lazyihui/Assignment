using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainClient : MonoBehaviour {

    [SerializeField] Canvas ScreenCanvas;

    public Context ctx;

    bool isGame = false;

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

        ctx.uiApp.Panel_Login_Open();


        ctx.uiApp.OnStartClickHandle = () => {
            Debug.Log("开始游戏  1 ddfs");
            ctx.uiApp.Panel_Login_Close();
            ctx.uiApp.Panel_Ranks_Open();



            ctx.uiApp.Panel_Ranks_AddElement( 1, cd, maxCd);
            isGame = true;
        };

        ctx.uiApp.OnRanksClickHandle = () => {
            Debug.Log("小兵");
        };
    }




    void Update() {
        float dt = Time.deltaTime;

        if (isGame) {
            if (Input.GetMouseButtonDown(0)) {
                cd -= 0.1f;
                ctx.uiApp.Panel_Ranks_CDTick( 1, cd, maxCd);
            }
        }

    }


}
