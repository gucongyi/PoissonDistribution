﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Awake()
    {
        buttonHome.onClick.RemoveAllListeners();
        buttonHome.onClick.AddListener(OnButtonHomeClick);
        buttonAway.onClick.RemoveAllListeners();
        buttonAway.onClick.AddListener(OnButtonAwayClick);
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
