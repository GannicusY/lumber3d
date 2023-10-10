using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace _Game.Scripts.Net
{
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Networking;

    public class NetWorkManager : MonoBehaviour
    {
        public static NetWorkManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SendRequest(string url, HttpMethod method, Action<string> onSuccess, Action<string> onFail)
        {
            StartCoroutine(SendRequestCoroutine(url, method, onSuccess, onFail));
        }

        private IEnumerator SendRequestCoroutine(string url, HttpMethod method, Action<string> onSuccess, Action<string> onFail)
        {
            UnityWebRequest request = null;

            switch (method)
            {
                case HttpMethod.GET:
                    request = UnityWebRequest.Get(url);
                    break;
                case HttpMethod.POST:
                    request = UnityWebRequest.PostWwwForm(url, "");
                    break;
                case HttpMethod.PUT:
                    request = UnityWebRequest.Put(url, "");
                    break;
                case HttpMethod.DELETE:
                    request = UnityWebRequest.Delete(url);
                    break;
                default:
                    Debug.LogError("Unsupported HTTP method: " + method);
                    yield break;
            }

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                onSuccess?.Invoke(request.downloadHandler.text);
            }
            else
            {
                onFail?.Invoke(request.error);
            }
        }
    }

    public enum HttpMethod
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}

