using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : Manager<SceneManager>
{
    // �� ��ȯ �ε� �ð�
    [Header("Scene Transition Settings")]
    public float transitionDelay = 1.0f;

    // ���� �ε�� ���� �̸��� �������� �Ӽ�
    public string CurrentSceneName
    {
        get { return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name; }
    }

    // �� ��ȯ �޼���
    public void LoadScene(string sceneName)
    {
        // �񵿱� �ε��� ���� �ڷ�ƾ ����
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    // �� ���ε� �޼��� (���� ���� �ٽ� �ε�)
    public void ReloadCurrentScene()
    {
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        LoadScene(currentSceneName);
    }

    // Ư�� �ð� ���� �� ���� ��ȯ�ϴ� �޼���
    public void LoadSceneWithDelay(string sceneName, float delay)
    {
        StartCoroutine(LoadSceneWithDelayCoroutine(sceneName, delay));
    }

    // �񵿱������� ���� �ε��ϴ� �ڷ�ƾ
    private IEnumerator LoadSceneAsync(string sceneName)
    {
        yield return new WaitForSeconds(transitionDelay); // ��ȯ ������ (optional)

        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);

        // ���� ������ �ε�� ������ ��ٸ�
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    // ���� �ð� ���� �� ���� �ε��ϴ� �ڷ�ƾ
    private IEnumerator LoadSceneWithDelayCoroutine(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene(sceneName);
    }
}
