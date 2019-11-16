using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButtonController : MonoBehaviour
{
    public BaseButtonController button;

    public void OnClick()
    {
        if (button == null)
        {
            throw new System.Exception("ボタンがnull");
        }

        // 自身のオブジェクト名を渡す
        button.OnClick(this.gameObject.name);
    }

    protected virtual void OnClick(string objectName)
    {
        // 呼ばれない
        Debug.Log("Base Button");
    }
}
