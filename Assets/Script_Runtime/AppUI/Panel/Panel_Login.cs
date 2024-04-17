using System;
using UnityEngine;
using UnityEngine.UI;

public class Panel_Login : MonoBehaviour {

    
    [SerializeField] Button startButton;

    public Action OnStartClickHandle;
    public void Ctor() {

        startButton.onClick.AddListener(() => {
            OnStartClickHandle.Invoke();

        });
    }

    public void Show() {
        gameObject.SetActive(true);
    }
    public void Close() {
        gameObject.SetActive(false);
    }


    void OnStartClicked() {
        Debug.Log("Start Button Clicked");
    }

}