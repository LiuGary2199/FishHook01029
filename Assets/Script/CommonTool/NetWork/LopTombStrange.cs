/**
 * 网络请求管理器
 * 功能：
 * 1. 支持GET/POST请求
 * 2. 自动超时重试机制
 * 3. 并发请求处理
 * 4. 请求头自定义
 * 5. 资源自动释放
 ***/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class LopTombStrange : MonoSnowstorm<LopTombStrange>
{
    // 配置参数
    private const float DEFAULT_TIMEOUT= 3f;      // 默认超时时间（秒）
    private const int MAX_RETRY_COUNT= 5;         // 最大重试次数
    private const float RETRY_INTERVAL= 0.5f;     // 重试间隔时间（秒）

    // 请求任务池，用于管理所有进行中的请求
    private Dictionary<string, RequestTask> TiebackLinen= new Dictionary<string, RequestTask>();

    /// <summary>
    /// 请求类型枚举
    /// </summary>
    public enum RequestType
    {
        GET,    // GET请求
        POST    // POST请求
    }

    /// <summary>
    /// 请求任务类，封装单个请求的所有信息
    /// </summary>
    private class RequestTask
    {
        public string ClusterWe{ get; set; }                  // 请求唯一标识
        public string Maw{ get; set; }                       // 请求URL
        public RequestType Toll{ get; set; }                 // 请求类型
        public WWWForm Bard{ get; set; }                     // POST请求表单数据
        public Dictionary<string, string> Dioxide{ get; set; }// 请求头
        public Action<UnityWebRequest> OrPresage{ get; set; } // 成功回调
        public Action OrMast{ get; set; }                    // 失败回调
        public int SeedyRelic{ get; set; }                   // 当前重试次数
        public float Lighten{ get; set; }                    // 超时时间
        public bool HeSeattle{ get; set; }                   // 是否正在执行
        public UnityWebRequest VieCluster{ get; set; }       // UnityWebRequest实例
        public byte[] LogMint{ get; set; }  // 用于JSON数据

        /// <summary>
        /// 请求任务构造函数
        /// </summary>
        /// <param name="requestId">请求ID</param>
        /// <param name="url">请求URL</param>
        /// <param name="type">请求类型</param>
        /// <param name="success">成功回调</param>
        /// <param name="fail">失败回调</param>
        /// <param name="timeout">超时时间</param>
        public RequestTask(string requestId, string url, RequestType type, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT)
        {
            ClusterWe = requestId;
            Maw = url;
            Toll = type;
            OrPresage = success;
            OrMast = fail;
            Lighten = timeout;
            SeedyRelic = 0;
            HeSeattle = false;
            Dioxide = new Dictionary<string, string>();
        }
    }

    //get请求列表
    private List<LopTombLawRation> LopTombLawTall;
    //post请求列表
    private List<LopTombBabyRation> LopTombBabyTall;
    public LopTombStrange()
    {
        //初始化
        LopTombLawTall = new List<LopTombLawRation>();
        LopTombBabyTall = new List<LopTombBabyRation>();
    }

    /// <summary>
    /// 获取当前Get请求列表中请求的个数
    /// </summary>
    public int LawLopTombLawTallRelic    {
        get { return LopTombLawTall.Count; }
    }

    /// <summary>
    /// 获取当前Post请求列表中请求的个数
    /// </summary>
    public int LawLopTombBabyTallRelic    {
        get { return LopTombBabyTall.Count; }
    }

    /// <summary>
    /// 发起GET请求
    /// </summary>
    /// <param name="url">请求URL</param>
    /// <param name="success">成功回调</param>
    /// <param name="fail">失败回调，参数为错误信息</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <param name="headers">自定义请求头</param>
    public void CiteLaw(string url, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT, Dictionary<string, string> headers = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            print("URL不能为空");
            return;
        }

        string requestId = Guid.NewGuid().ToString();
        var task = new RequestTask(requestId, url, RequestType.GET, success, fail, timeout);
        if (headers != null)
        {
            task.Dioxide = headers;
        }
        TiebackLinen[requestId] = task;
        StartCoroutine(ProteinCluster(task));
    }

    /// <summary>
    /// 发起POST请求
    /// </summary>
    /// <param name="url">请求URL</param>
    /// <param name="form">POST表单数据</param>
    /// <param name="success">成功回调</param>
    /// <param name="fail">失败回调，参数为错误信息</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <param name="headers">自定义请求头</param>
    public void CiteBaby(string url, WWWForm form, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT, Dictionary<string, string> headers = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            print("URL不能为空");
            return;
        }

        string requestId = Guid.NewGuid().ToString();
        var task = new RequestTask(requestId, url, RequestType.POST, success, fail, timeout);
        task.Bard = form;
        if (headers != null)
        {
            task.Dioxide = headers;
        }
        TiebackLinen[requestId] = task;
        StartCoroutine(ProteinCluster(task));
    }

    /// <summary>
    /// 发送JSON格式的POST请求
    /// </summary>
    /// <param name="url">请求URL</param>
    /// <param name="jsonData">JSON数据</param>
    /// <param name="success">成功回调</param>
    /// <param name="fail">失败回调</param>
    /// <param name="timeout">超时时间（秒）</param>
    /// <param name="headers">自定义请求头</param>
    public void CiteBabyPath(string url, string jsonData, Action<UnityWebRequest> success, Action fail, float timeout = DEFAULT_TIMEOUT, Dictionary<string, string> headers = null)
    {
        if (string.IsNullOrEmpty(url))
        {
            Debug.LogError("URL不能为空");
            return;
        }

        string requestId = Guid.NewGuid().ToString();
        var task = new RequestTask(requestId, url, RequestType.POST, success, fail, timeout);

        // 设置JSON数据
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonData);
        task.LogMint = bodyRaw;

        if (headers != null)
        {
            task.Dioxide = headers;
            //print("+++++ 请求头内容： "+ string.Join(", ", headers.Select(h => $"{h.Key}: {h.Value}")));
        }
        // 确保设置Content-Type
        if (!task.Dioxide.ContainsKey("Content-Type"))
        {
            task.Dioxide["Content-Type"] = "application/json";
        }

        TiebackLinen[requestId] = task;
        StartCoroutine(ProteinCluster(task));
    }

    /// <summary>
    /// 处理请求的协程
    /// 包含：请求发送、超时检测、自动重试、结果处理
    /// </summary>
    /// <param name="task">请求任务对象</param>
    private IEnumerator ProteinCluster(RequestTask task)
    {
        while (task.SeedyRelic < MAX_RETRY_COUNT)
        {
            task.HeSeattle = true;

            // 创建请求
            task.VieCluster = ThinlyVieCluster(task);

            // 添加请求头
            foreach (var header in task.Dioxide)
            {
                task.VieCluster.SetRequestHeader(header.Key, header.Value);
            }

            float elapsedTime = 0f;
            bool isTimeout = false;

            task.VieCluster.SendWebRequest();

            // 等待请求完成或超时
            while (!task.VieCluster.isDone)
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime >= task.Lighten)
                {
                    isTimeout = true;
                    break;
                }
                yield return null;
            }

            // 处理请求结果
            if (!isTimeout && !task.VieCluster.isNetworkError && !task.VieCluster.isHttpError)
            {
                // 请求成功
                task.OrPresage?.Invoke(task.VieCluster);
                CleanupCluster(task);
                yield break;
            }
            else
            {
                // 获取错误信息
                string errorMessage = isTimeout ? "请求超时" : task.VieCluster.error;

                // 请求失败，准备重试
                task.SeedyRelic++;
                if (task.SeedyRelic >= MAX_RETRY_COUNT)
                {
                    Debug.LogError($"请求失败 (重试{MAX_RETRY_COUNT}次后): {task.Maw}, 错误: {errorMessage}");
                    task.OrMast?.Invoke();
                    CleanupCluster(task);
                    yield break;
                }
                else
                {
                    Debug.Log($"请求失败，准备重试 ({task.SeedyRelic}/{MAX_RETRY_COUNT}). URL: {task.Maw}, 错误: {errorMessage}");
                    task.VieCluster.Dispose();
                    yield return new WaitForSeconds(RETRY_INTERVAL);
                }
            }
        }
    }

    /// <summary>
    /// 根据请求类型创建对应的UnityWebRequest实例
    /// </summary>
    /// <param name="task">请求任务对象</param>
    /// <returns>配置好的UnityWebRequest实例</returns>
    private UnityWebRequest ThinlyVieCluster(RequestTask task)
    {
        UnityWebRequest request = null;

        switch (task.Toll)
        {
            case RequestType.GET:
                request = UnityWebRequest.Get(task.Maw);
                break;

            case RequestType.POST:
                if (task.LogMint != null)
                {
                    // 发送JSON数据
                    request = new UnityWebRequest(task.Maw, "POST");
                    request.uploadHandler = new UploadHandlerRaw(task.LogMint);
                    request.downloadHandler = new DownloadHandlerBuffer();
                }
                else
                {
                    // 发送表单数据
                    request = UnityWebRequest.Post(task.Maw, task.Bard ?? new WWWForm());
                }
                break;
        }

        // 设置超时
        request.timeout = Mathf.CeilToInt(task.Lighten);

        return request;
    }

    /// <summary>
    /// 清理请求资源
    /// 包括：释放UnityWebRequest、从请求池移除、重置状态
    /// </summary>
    /// <param name="task">要清理的请求任务</param>
    private void CleanupCluster(RequestTask task)
    {
        if (task == null) return;

        try
        {
            if (task.VieCluster != null)
            {
                task.VieCluster.Dispose();
            }
            task.HeSeattle = false;
            TiebackLinen.Remove(task.ClusterWe);
        }
        catch (Exception e)
        {
            Debug.LogError($"清理请求资源时发生错误: {e.Message}");
        }
    }

    /// <summary>
    /// 取消指定的请求
    /// </summary>
    /// <param name="requestId">要取消的请求ID</param>
    public void CancelCluster(string requestId)
    {
        if (TiebackLinen.TryGetValue(requestId, out RequestTask task))
        {
            if (task.HeSeattle)
            {
                task.VieCluster?.Abort();
            }
            CleanupCluster(task);
        }
    }

    /// <summary>
    /// 取消所有正在进行的请求
    /// 通常在场景切换或应用退出时调用
    /// </summary>
    public void MalletPinCampaign()
    {
        if (TiebackLinen == null) return;

        try
        {
            foreach (var task in TiebackLinen.Values)
            {
                if (task != null && task.HeSeattle && task.VieCluster != null)
                {
                    try
                    {
                        task.VieCluster.Abort();
                        task.VieCluster.Dispose();
                    }
                    catch (Exception e)
                    {
                        Debug.LogWarning($"清理请求时发生异常: {e.Message}");
                    }
                }
            }
            TiebackLinen.Clear();
        }
        catch (Exception e)
        {
            Debug.LogError($"CancelAllRequests发生异常: {e.Message}");
        }
    }

    /// <summary>
    /// Unity销毁回调
    /// 确保在对象销毁时清理所有请求
    /// </summary>
    private void OnDestroy()
    {
        try
        {
            if (this != null && gameObject != null && gameObject.activeInHierarchy)
            {
                MalletPinCampaign();
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning($"OnDestroy清理资源时发生异常: {e.Message}");
        }
    }

    /// <summary>
    /// Unity应用退出回调
    /// 确保在应用退出时清理所有请求
    /// </summary>
    private void OnApplicationQuit()
    {
        MalletPinCampaign();
    }

}
