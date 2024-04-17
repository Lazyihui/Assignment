using UnityEngine;
public class UIcontext {


    public Panel_Login panel_Login;

    public Canvas canvas;


    public UIcontext() {
    }

    public void Inject(Canvas canvas) {
        this.canvas = canvas;
    }

}