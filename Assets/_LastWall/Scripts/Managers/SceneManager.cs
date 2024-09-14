using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Manager<SceneManager>
{
    // 씬 전환 로딩 시간
    [Header("Scene Transition Settings")]
    public float transitionDelay = 1.0f;

    // 현재 로드된 씬의 이름을 가져오는 속성
    public string CurrentSceneName
    {
        get { return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name; }
    }

    // 씬 전환 메서드
    public void LoadScene(string sceneName)
    {
        // 비동기 로딩을 위해 코루틴 실행
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // 씬 리로드 메서드 (현재 씬을 다시 로드)
    public void ReloadCurrentScene()
    {
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        LoadScene(currentSceneName);
    }

    // 특정 시간 지연 후 씬을 전환하는 메서드
    public void LoadSceneWithDelay(string sceneName, float delay)
    {
        StartCoroutine(LoadSceneWithDelayCoroutine(sceneName, delay));
    }

    // 비동기적으로 씬을 로드하는 코루틴
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return new WaitForSeconds(transitionDelay); // 전환 딜레이 (optional)

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        // 씬이 완전히 로드될 때까지 기다림
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    // 일정 시간 지연 후 씬을 로드하는 코루틴
    private IEnumerator LoadSceneWithDelayCoroutine(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene(sceneName);
    }
}
