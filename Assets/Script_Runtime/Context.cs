using System;
using UnityEngine;

public class Context {

    public ModuleAssets assetsContext;

    public UIcontext uiContext;

    public Context() {
        assetsContext = new ModuleAssets();
        uiContext = new UIcontext();
    }

    public void Inject(Canvas canvas) {
        uiContext.Inject(canvas, assetsContext);
    }

}
