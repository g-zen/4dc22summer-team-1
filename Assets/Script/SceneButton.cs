using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneButton : MonoBehaviour
{
    [Header("遷移先シーン名"), SerializeField] string NextSceneName;

    public void TranceNextScene()
    {
        FadeManager.Instance.LoadScene(NextSceneName, 0.8f);
    }
}
