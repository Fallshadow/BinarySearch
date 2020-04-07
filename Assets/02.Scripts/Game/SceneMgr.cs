using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

namespace act.game
{
    public enum SceneEnum
    {
        Entry = 0,
        MainMenu,
        Study,
    }
    public class SceneMgr : SingletonMonoBehavior<SceneMgr>
    {
        public SceneEnum NextScene = SceneEnum.Entry;
        public float refreshTime = 0.2f;
        public float process = 0;

        public void LoadSceneAsync(SceneEnum index, Action completeCB = null)
        {
            StartCoroutine(_loadSceneAsync(index, completeCB));
        }

        IEnumerator _loadSceneAsync(SceneEnum index,Action completeCB = null)
        {
            process = 0;
            AsyncOperation operation = SceneManager.LoadSceneAsync((int)index);

            while(true)
            {
                if(operation.isDone)
                {
                    process = 1;
                    completeCB?.Invoke();
                    yield break;
                }
                process = operation.progress;
                yield return new WaitForSeconds(refreshTime);
            }
        }
    }
}