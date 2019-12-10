using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

namespace HFramework
{
    public enum UILayer
    {
        Bg,
        Common,
        Top
    }

    public class GUIManager
    {
        private static Dictionary<string, GameObject> _panelDicts = new Dictionary<string, GameObject>();
        private static GameObject _uiRoot;

        public static GameObject UIRoot
        {
            get
            {
                if (_uiRoot == null)
                {
                    _uiRoot = Object.Instantiate(Resources.Load<GameObject>("UIRoot"));
                    _uiRoot.name = "UIRoot";
                }
                return _uiRoot;
            }
        }

        public static void SetResolution(float width, float height, float matchWidthOrHeight)
        {
            CanvasScaler canvasScaler = _uiRoot.GetComponent<CanvasScaler>();
            canvasScaler.referenceResolution = new Vector2(width, height);
            canvasScaler.matchWidthOrHeight = matchWidthOrHeight;
        }

        public static GameObject LoadPanel(string panelName, UILayer uiLayer)
        {
            GameObject panel = Object.Instantiate(Resources.Load<GameObject>(panelName));
            panel.transform.SetParent(UIRoot.transform);
            panel.name = panelName;
            _panelDicts.Add(panelName, panel);

            switch (uiLayer)
            {
                case UILayer.Bg:
                    panel.transform.SetParent(UIRoot.transform.Find("Bg"));
                    break;
                case UILayer.Common:
                    panel.transform.SetParent(UIRoot.transform.Find("Common"));
                    break;
                case UILayer.Top:
                    panel.transform.SetParent(UIRoot.transform.Find("Top"));
                    break;
                default:
                    break;
            }

            RectTransform panelRectTrans = panel.transform as RectTransform;
            panelRectTrans.offsetMin = Vector2.zero;
            panelRectTrans.offsetMax = Vector2.zero;
            panelRectTrans.anchoredPosition3D = Vector3.zero;
            panelRectTrans.anchorMin = Vector2.zero;
            panelRectTrans.anchorMax = Vector2.one;

            return panel;
        }

        public static void UnLoadPanel(string panelName)
        {
            if (_panelDicts.ContainsKey(panelName))
            {
                Object.Destroy(_panelDicts[panelName]);
            }
        }
    }
}
