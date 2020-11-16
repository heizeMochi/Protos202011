using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 해당 클래스는 게임 내 로그창이 있다고 가정하에 만든 클래스입니다.

// Debug. 로 직접 ScrollLog로 접근하기위한 랩핑
public static class Debug
{
    public static void Log(object message)
    {
        UnityEngine.Debug.Log(message);
    }
    public static void LogError(string message)
    {
        UnityEngine.Debug.LogError(message);
    }
    /// <summary>
    /// 스크롤뷰 Content 자식으로 텍스트를 생성 (개행은 스페이스 두번으로 구분)
    /// </summary>
    /// <param name="_text">텍스트</param>
    public static void ScrollLog(string _text)
    {
        LogMng.instance.Log(_text);
    }
}

public class LogMng : MonoBehaviour
{
    public static LogMng instance;
    public Transform Content;
    public RectTransform trans;
    Text text;

    void Awake()
    {
        instance = this;
    }

    // String값을 매개변수로 받아서 Instantiate로 Resources에 있는 Text를 생성해 text에 들어갈 내용을 수정
    public void Log(string _text)
    {
        int size = 1;
        char[] _c = _text.ToCharArray();
        for (int i = 0; i < _c.Length; i++)
        {
            if (_c[i] == ' ' && _c[i + 1] == ' ')
            {
                _c[i + 1] = '`';
                _c[i] = '\n';
            }
        }
        _text = string.Empty;
        for (int i = 0; i < _c.Length; i++)
        {
            if (_c[i] == '`')
            {
                size++;
                continue;
            }
            _text += _c[i].ToString();
        }
        text = Resources.Load<Text>("Text");
        Text go = Instantiate<Text>(text, Content);
        go.text = _text;
        go.fontSize = go.fontSize / size;
        ContentInit();
    }

    // ScrollLog의 생성갯수에 따라 Content의 크기를 변경
    void ContentInit()
    {
        float height = 0f;
        for (int i = 0; i < Content.childCount; i++)
        {
            height += 75f;
            Debug.Log(i);
        }
        trans.sizeDelta = new Vector2(585f, height);
    }
}
