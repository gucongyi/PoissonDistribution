using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PoissonDistributionComponent : MonoBehaviour
{
    public InputField inputFieldHome;
    public Button buttonHome;
    public Transform rootHomeScrollViewContent;

    public InputField inputFieldAway;
    public Button buttonAway;
    public Transform rootAwayScrollViewContent;

    public GameObject goItemProb;

    public InputField InputFieldLate5;
    public InputField InputFieldLate10;
    public InputField InputFieldLate15;
    public Button buttonCalcLate;
    public Text TextRetLate;

    private void Awake()
    {
        buttonHome.onClick.RemoveAllListeners();
        buttonHome.onClick.AddListener(OnButtonHomeClick);
        buttonAway.onClick.RemoveAllListeners();
        buttonAway.onClick.AddListener(OnButtonAwayClick);
        buttonCalcLate.onClick.RemoveAllListeners();
        buttonCalcLate.onClick.AddListener(onButtonCalcLateClick);
    }

    private void onButtonCalcLateClick()
    {
        if (string.IsNullOrEmpty(InputFieldLate5.text))
            return;
        if (string.IsNullOrEmpty(InputFieldLate10.text))
            return;
        if (string.IsNullOrEmpty(InputFieldLate15.text))
            return;
        float ret = float.Parse(InputFieldLate5.text) * 0.4f + float.Parse(InputFieldLate10.text) * 0.3f + float.Parse(InputFieldLate15.text) * 0.3f;
        TextRetLate.text = $"{ret}";
    }

    private void OnButtonHomeClick()
    {
        if (string.IsNullOrEmpty(inputFieldHome.text))
            return;
        rootHomeScrollViewContent.DestroyAllTransChild();
        for (int i = 0; i < 6; i++)
        {
            var goInstant=CreateItem(goItemProb, rootHomeScrollViewContent);
            ItemProbComponent itemCom = goInstant.GetComponent<ItemProbComponent>();
            itemCom.ShowInfo(i, float.Parse(inputFieldHome.text));
        }
    }

    private void OnButtonAwayClick()
    {
        if (string.IsNullOrEmpty(inputFieldAway.text))
            return;
        rootAwayScrollViewContent.DestroyAllTransChild();
        for (int i = 0; i < 6; i++)
        {
            var goInstant = CreateItem(goItemProb, rootAwayScrollViewContent);
            ItemProbComponent itemCom = goInstant.GetComponent<ItemProbComponent>();
            itemCom.ShowInfo(i, float.Parse(inputFieldAway.text));
        }
    }

    private GameObject CreateItem(GameObject prefab,Transform rootTrans)
    {
        var go = GameObject.Instantiate<GameObject>(prefab);
        go.transform.parent = rootTrans;
        go.transform.localScale = Vector3.one;
        go.SetActive(true);
        return go;
    }
}
public static class ExtHelper
{
    public static void DestroyAllTransChild(this Transform transRoot)
    {
        if (transRoot.childCount < 0) return;
        int count = transRoot.childCount;
        for (int i = count - 1; i >= 0; i--)
        {
            GameObject.Destroy(transRoot.GetChild(i).gameObject);
        }
    }
}
