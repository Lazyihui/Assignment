using UnityEngine;
public class UIcontext {


    public Panel_Login panel_Login;

    public Panel_Ranks panel_Ranks;

    public Canvas canvas;

    public ModuleAssets assetsContext;

    public int[] ranksTypeID;


    public UIcontext() {
    }

    public void Inject(Canvas canvas, ModuleAssets assetsContext) {
        this.canvas = canvas;
        this.assetsContext = assetsContext;
    }

}