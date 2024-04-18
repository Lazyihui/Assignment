using UnityEngine;
public class UIcontext {


    public Panel_Login panel_Login;

    public Canvas canvas;

    public ModuleAssets assetsContext;

    public AppUI appUI;


    public UIcontext() {
        appUI = new AppUI();
    }

    public void Inject(Canvas canvas, ModuleAssets assetsContext) {
        this.canvas = canvas;
        this.assetsContext = assetsContext;
    }

}