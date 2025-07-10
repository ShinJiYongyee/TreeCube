using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeLeavesColor : MonoBehaviour
{

    [Header("Leaves to Change")]
    public List<GameObject> leafRenderers_ToBrown; // �������� ������ ���ĸ����� Renderer
    public List<GameObject> leafRenderers_ToRed; // �������� ������ ���ĸ����� Renderer
    public List<GameObject> leafRenderers_ToYellow; // Ȳ������ ������ ���ĸ����� Renderer

    [Header("Target Color")]
    public Material targetColor_Brown;
    public Material targetColor_Red;
    public Material targetColor_Yellow;

    [Header("Color Transition Settings")]
    public float colorChangeSpeed = 1f; // �� ��ȭ �ӵ�

    void OnEnable()
    {
        StartCoroutine(FadeToColor(leafRenderers_ToBrown, targetColor_Brown));
        StartCoroutine(FadeToColor(leafRenderers_ToRed, targetColor_Red));
        StartCoroutine(FadeToColor(leafRenderers_ToYellow, targetColor_Yellow));

    }

    IEnumerator FadeToColor(List<GameObject> targets, Material targetColor)
    {
        foreach(GameObject target in targets)
        {
            Color startColor = target.GetComponentInChildren<Renderer>().material.color;
            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime * colorChangeSpeed;
                target.GetComponentInChildren<Renderer>().material.color = Color.Lerp(startColor, targetColor.color, t);
                yield return null;
            }

            target.GetComponentInChildren<Renderer>().material.color = targetColor.color;
        }
    }
}
