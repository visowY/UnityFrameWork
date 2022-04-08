using System.Collections;
using System.Collections.Generic;
using PlasticPipe.PlasticProtocol.Messages;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class OverrideCreateUI
{
    [MenuItem("GameObject/UI/Button")]
    static void CreateButton()
    {
        CreateUI(CreateGButton);
    }

    private static GameObject CreateGButton()
    {
        // var config = ScriptableManager.GetDefaultConfig();
        System.Action<GameObject> callback = (go) =>
        {
            GButton btn = go.GetComponent<GButton>();
            
        };
        return CreateGo<GButton>("btn_", callback);
    }



    private static GameObject CreateGo<T>(string defaulName, System.Action<GameObject> callback)
    {
        GameObject go  = new GameObject(defaulName, typeof(T));
        callback(go);
        go.transform.SetParent(Selection.activeTransform);
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = Vector3.one;
        Selection.activeGameObject = go;
        return go;
    }

    private static void CreateUI(System.Func<GameObject> callback)
    {
        var canvasObj = SecurityCheck();
        if (!Selection.activeTransform ||
            !Selection.activeTransform.GetComponentInParent<Canvas>()
                )
        {
            callback().transform.SetParent(canvasObj.transform);
        }
        else
        {
            callback();
        }
    }


    private static GameObject SecurityCheck()
    {
        GameObject canvasGo;
        var cc = Object.FindObjectOfType<Canvas>();
        if (!cc)
        {
            canvasGo = new GameObject("Canvas", typeof(Canvas));
            canvasGo.AddComponent<CanvasScaler>();
            canvasGo.AddComponent<GraphicRaycaster>();
            Canvas canvas = canvasGo.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        }
        else
        {
            canvasGo = cc.gameObject;
        }

        if (!Object.FindObjectOfType<UnityEngine.EventSystems.EventSystem>())
        {
            GameObject eventSystemGo = new GameObject("EventSystem", typeof(EventSystem));
            eventSystemGo.AddComponent<UnityEngine.EventSystems.EventSystem>();
            eventSystemGo.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        }


        return canvasGo;
    }
}
