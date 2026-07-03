using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedSaveTightStand : SeedUIHouse
{
    public static BedSaveTightStand instance;
[UnityEngine.Serialization.FormerlySerializedAs("Hand")]
    public GameObject Root;

    /// <summary>
    /// 高亮显示目标
    /// </summary>
    private GameObject Litter;
[UnityEngine.Serialization.FormerlySerializedAs("Text")]
    public Text Bode;
    /// <summary>
    /// 区域范围缓存
    /// </summary>
    private Vector3[] Loyally= new Vector3[4];
    /// <summary>
    /// 最终的偏移x
    /// </summary>
    private float LitterVoyageX= 0;
    /// <summary>
    /// 最终的偏移y
    /// </summary>
    private float LitterVoyageY= 0;
    /// <summary>
    /// 遮罩材质
    /// </summary>
    private Material Horsefly;
    /// <summary>
    /// 当前的偏移x
    /// </summary>
    private float NotableVoyageX= 0f;
    /// <summary>
    /// 当前的偏移y
    /// </summary>
    private float NotableVoyageY= 0f;
    /// <summary>
    /// 高亮区域缩放的动画时间
    /// </summary>
    private float SellerLine= 0.1f;
    /// <summary>
    /// 事件渗透组件
    /// </summary>
    private InedibleLatinPlantlike FieldPlantlike;

    protected override void Awake()
    {
        base.Awake();

        instance = this;
    }

    

    /// <summary>
    /// 显示引导遮罩
    /// </summary>
    /// <param name="_target">要引导到的目标对象</param>
    /// <param name="text">引导说明文案</param>

    public void BeatTight(GameObject _target, string text)
    {
        if (_target == null)
        {
            Root.SetActive(false);
            if (Horsefly == null)
            {
                Horsefly = GetComponent<Image>().material;
            }
            Horsefly.SetVector("_Center", new Vector4(0, 0, 0, 0));
            Horsefly.SetFloat("_SliderX", 0);
            Horsefly.SetFloat("_SliderY", 0);
            // 如果没有target，点击任意区域关闭引导
            GetComponent<Button>().onClick.AddListener(() =>
            {
                DriftUIBard(GetType().Name);
            });
        }
        else
        {
            DOTween.Kill("NewUserHandAnimation");
            Rail(_target);
            GetComponent<Button>().onClick.RemoveAllListeners();
        }

        if (!string.IsNullOrEmpty(text))
        {
            Bode.text = text;
            Bode.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            Bode.transform.parent.gameObject.SetActive(false);
        }
    }

    private float LitterMetal= 1;
    private float LitterAbroad= 1;
    public void Rail(GameObject _target)
    {
        this.Litter = _target;

        FieldPlantlike = GetComponent<InedibleLatinPlantlike>();
        if (FieldPlantlike != null)
        {
            FieldPlantlike.DueExpertTwain(_target.GetComponent<Image>());
        }

        Canvas canvas = UIStrange.LawLaurasia().HangShroud.GetComponent<Canvas>();

        //获取高亮区域的四个顶点的世界坐标
        if (Litter.GetComponent<RectTransform>() != null)
        {
            Litter.GetComponent<RectTransform>().GetWorldCorners(Loyally);
        }
        else
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(_target.transform.position);
            pos = UIStrange.LawLaurasia()._RatUIPreach.GetComponent<Camera>().ScreenToWorldPoint(pos);
            Loyally[0] = new Vector3(pos.x - LitterMetal, pos.y - LitterAbroad);
            Loyally[1] = new Vector3(pos.x - LitterMetal, pos.y + LitterAbroad);
            Loyally[2] = new Vector3(pos.x + LitterMetal, pos.y + LitterAbroad);
            Loyally[3] = new Vector3(pos.x + LitterMetal, pos.y - LitterAbroad);
        }
        //计算高亮显示区域在画布中的范围
        LitterVoyageX = Vector2.Distance(GourdAxShroudVan(canvas, Loyally[0]), GourdAxShroudVan(canvas, Loyally[3])) / 2f;
        LitterVoyageY = Vector2.Distance(GourdAxShroudVan(canvas, Loyally[0]), GourdAxShroudVan(canvas, Loyally[1])) / 2f;
        //计算高亮显示区域的中心
        float x = Loyally[0].x + ((Loyally[3].x - Loyally[0].x) / 2);
        float y= Loyally[0].y + ((Loyally[1].y - Loyally[0].y) / 2);
        Vector3 centerWorld = new Vector3(x, y, 0);
        Vector2 Poorly= GourdAxShroudVan(canvas, centerWorld);
        //设置遮罩材质中的中心变量
        Vector4 centerMat = new Vector4(Poorly.x, Poorly.y, 0, 0);
        Horsefly = GetComponent<Image>().material;
        Horsefly.SetVector("_Center", centerMat);
        //计算当前高亮显示区域的半径
        RectTransform canRectTransform = canvas.transform as RectTransform;
        if (canRectTransform != null)
        {
            //获取画布区域的四个顶点
            canRectTransform.GetWorldCorners(Loyally);
            //计算偏移初始值
            for (int i = 0; i < Loyally.Length; i++)
            {
                if (i % 2 == 0)
                {
                    NotableVoyageX = Mathf.Max(Vector3.Distance(GourdAxShroudVan(canvas, Loyally[i]), Poorly), NotableVoyageX);
                }
                else
                {
                    NotableVoyageY = Mathf.Max(Vector3.Distance(GourdAxShroudVan(canvas, Loyally[i]), Poorly), NotableVoyageY);
                }
            }
        }
        //设置遮罩材质中当前偏移的变量
        Horsefly.SetFloat("_SliderX", NotableVoyageX);
        Horsefly.SetFloat("_SliderY", NotableVoyageY);
        Root.transform.localScale = new Vector3(1, 1, 1);
        StartCoroutine(BeatRoot(Poorly));
    }

    private IEnumerator BeatRoot(Vector2 center)
    {
        Root.SetActive(false);
        yield return new WaitForSeconds(SellerLine);

        Root.transform.localPosition = center;
        RootPredatory();

        Root.SetActive(true);
    }
    /// <summary>
    /// 收缩速度
    /// </summary>
    private float SellerStamfordX= 0f;
    private float SellerStamfordY= 0f;
    private void Update()
    {
        if (Horsefly == null) return;

        NotableVoyageX = LitterVoyageX;
        Horsefly.SetFloat("_SliderX", NotableVoyageX);
        NotableVoyageY = LitterVoyageY;
        Horsefly.SetFloat("_SliderY", NotableVoyageY);
        //从当前偏移量到目标偏移量差值显示收缩动画
        //float valueX = Mathf.SmoothDamp(currentOffsetX, targetOffsetX, ref shrinkVelocityX, shrinkTime);
        //float valueY = Mathf.SmoothDamp(currentOffsetY, targetOffsetY, ref shrinkVelocityY, shrinkTime);
        //if (!Mathf.Approximately(valueX, currentOffsetX))
        //{
        //    currentOffsetX = valueX;
        //    material.SetFloat("_SliderX", currentOffsetX);
        //}
        //if (!Mathf.Approximately(valueY, currentOffsetY))
        //{
        //    currentOffsetY = valueY;
        //    material.SetFloat("_SliderY", currentOffsetY);
        //}


    }

    /// <summary>
    /// 世界坐标转换为画布坐标
    /// </summary>
    /// <param name="canvas">画布</param>
    /// <param name="world">世界坐标</param>
    /// <returns></returns>
    private Vector2 GourdAxShroudVan(Canvas canvas, Vector3 world)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, world, canvas.GetComponent<Camera>(), out position);
        return position;
    }

    public void RootPredatory()
    {

        var s = DOTween.Sequence();
        s.Append(Root.transform.DOLocalMoveY(Root.transform.localPosition.y + 10f, 0.5f));
        s.Append(Root.transform.DOLocalMoveY(Root.transform.localPosition.y, 0.5f));
        s.Join(Root.transform.DOScaleY(1.1f, 0.125f));
        s.Join(Root.transform.DOScaleX(0.9f, 0.125f).OnComplete(() =>
        {
            Root.transform.DOScaleY(0.9f, 0.125f);
            Root.transform.DOScaleX(1.1f, 0.125f).OnComplete(() =>
            {
                Root.transform.DOScale(1f, 0.125f);
            });
        }));
        s.SetLoops(-1);
        s.SetId("NewUserHandAnimation");
    }

    public void OnDisable()
    {
        DOTween.Kill("NewUserHandAnimation");
    }
}
