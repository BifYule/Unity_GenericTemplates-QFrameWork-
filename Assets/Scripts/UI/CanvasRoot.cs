using QFramework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace FunCSpace
{
    public enum PanelType
    {
        UIPANEL,
        DIALOGPANEL,
        TIPPANEL,
        LOADINGPANEL,
    }

    public class CanvasRoot : MonoSingleton<CanvasRoot>
    {
        [SerializeField]
        private GameObject UIPanel;
        [SerializeField]
        private GameObject DialogPanel;
        [SerializeField]
        private GameObject TipPanel;
        [SerializeField]
        private GameObject LoadingPanel;


        private void Awake()
        {
            if (Instance != null)
            {
                DontDestroyOnLoad(this);
            }

            SetCanvasScale();
        }

        public void SetCanvasScale(int width = 1920, int height = 1080)
        {
            Vector2 newResolution = new Vector2(width, height);

            UIPanel.GetComponent<CanvasScaler>().referenceResolution = newResolution;
            DialogPanel.GetComponent<CanvasScaler>().referenceResolution = newResolution;
            TipPanel.GetComponent<CanvasScaler>().referenceResolution = newResolution;
            LoadingPanel.GetComponent<CanvasScaler>().referenceResolution = newResolution;
        }

        public void SetRenderMode(PanelType type, RenderMode mode)
        {
            switch (type)
            {
                case PanelType.UIPANEL:
                    UIPanel.GetComponent<Canvas>().renderMode = mode; break;
                case PanelType.DIALOGPANEL:
                    DialogPanel.GetComponent<Canvas>().renderMode = mode; break;
                case PanelType.TIPPANEL:
                    TipPanel.GetComponent<Canvas>().renderMode = mode; break;
                case PanelType.LOADINGPANEL:
                    LoadingPanel.GetComponent<Canvas>().renderMode = mode; break;
            }
        }

        public void EnterPanel(PanelType type, GameObject obj = null)
        {

            switch (type)
            {
                case PanelType.UIPANEL:
                    EnterPanelOnlyOne(UIPanel, obj); break;
                case PanelType.DIALOGPANEL:
                    EnterPanelOnlyOne(DialogPanel, obj); break;
                case PanelType.TIPPANEL:
                    EnterPanelOnlyOne(TipPanel, obj); break;
                case PanelType.LOADINGPANEL:
                    EnterPanelOnlyOne(LoadingPanel, obj); break;
            }
        }

        
        public void EnterPanelOnlyOne(GameObject panel, GameObject obj)
        {
            GameManager.Instance.RemoveAllChildren(panel);

            if(panel != null)
            {
                GameObject instObj = GameObject.Instantiate(obj, panel.transform);
                instObj.transform.localPosition = Vector3.zero;
            }

        }

    }
}

