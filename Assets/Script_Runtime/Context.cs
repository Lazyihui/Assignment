using System;
using UnityEngine;

public class Context {

    public ModuleAssets assetsContext;

    public AppUI uiApp;

    public Context() {
        assetsContext = new ModuleAssets();
        uiApp = new AppUI();
    }

    public void Inject(Canvas canvas) {
        uiApp.Inject(canvas, assetsContext);
    }

}
