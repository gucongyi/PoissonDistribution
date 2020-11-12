using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemProbComponent : MonoBehaviour
{
    public Text textEnterCount;
    public Text textProb;
    public void ShowInfo(int willCalcCount, float averageCount)
    {
        textEnterCount.text = $"{willCalcCount}";
        textProb.text = CalcProbText(averageCount, willCalcCount);
    }

    private string CalcProbText(float averageCount, int willCalcCount)
    {
        string textProb = string.Empty;
        float problility = Mathf.Pow(averageCount, willCalcCount)/ CalcFactorial(willCalcCount)*Mathf.Exp(-averageCount);
        problility = problility * 100;
        textProb = $"{problility}%";
        return textProb;
    }

    //计算阶乘
    public int CalcFactorial(int m)
    {
        int result = 1;
        for (int i = m; i >= 1; i--)
        {
            result *= i;
        }
        return result;
    }
}
