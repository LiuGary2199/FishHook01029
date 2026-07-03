using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum AGameType
{
    NotStart,   
    Drop,       // �³�
    Recycle     // ����
}

public class AReapInner_A : AUIDrench
{
[UnityEngine.Serialization.FormerlySerializedAs("BackGroundIcon")]    public Sprite[] LawnReliefTomb; 
[UnityEngine.Serialization.FormerlySerializedAs("BgImg1")]    public Image HeRub1;
[UnityEngine.Serialization.FormerlySerializedAs("BgImg2")]    public Image HeRub2;
    private RectTransform _MeOx1;
    private RectTransform _MeOx2;
    private RectTransform _MeLateOx;

    private float _PeopleHeFrigid;
    private float _MeNoisyHerY;

    [Header("ʵ����Ǳ��ȿ���")]
[UnityEngine.Serialization.FormerlySerializedAs("MaxDropDepth")]    public float FeeLampPlumb; 
    //�㹳��ǰ���
    private float _NotLampPlumb;
    private bool SoNear= true;

    [Header("��Ⱥ����")]
[UnityEngine.Serialization.FormerlySerializedAs("FishParent")]    public Transform CorpCarton;
[UnityEngine.Serialization.FormerlySerializedAs("FishDisplay")]    public Transform CorpCheapen;
[UnityEngine.Serialization.FormerlySerializedAs("FishPrefabs")]    public GameObject[] CorpSwimmer;
    private int CorpSapHaste= 70;

    [Header("������ť����")]
[UnityEngine.Serialization.FormerlySerializedAs("StartGame")]    public Button NoisyReap;
[UnityEngine.Serialization.FormerlySerializedAs("AddDepth")]    public Button PutPlumb;
    public Text AddDepthDesc;
[UnityEngine.Serialization.FormerlySerializedAs("AddFishMax")]    public Button PutCorpFee;
    public Text AddFishMaxDesc;
[UnityEngine.Serialization.FormerlySerializedAs("AddEarn")]    public Button PutCone;
    public Text AddEarnDesc;
[UnityEngine.Serialization.FormerlySerializedAs("BoardObj")]    public GameObject JuiceSky;
[UnityEngine.Serialization.FormerlySerializedAs("SettingBtn")]
    public Button AttractAny;
[UnityEngine.Serialization.FormerlySerializedAs("TujianBtn")]    public Button ShovelAny;
[UnityEngine.Serialization.FormerlySerializedAs("SignBtn")]    public Button CoaxAny;
[UnityEngine.Serialization.FormerlySerializedAs("FishTest")]    public Text CorpPath;

    [Header("�ٶ�����")]
[UnityEngine.Serialization.FormerlySerializedAs("DropSpeed")]    private float LampScope= 1000f;
[UnityEngine.Serialization.FormerlySerializedAs("NormalRecycleSpeed")]    private float InviteRoutineScope= 700;
[UnityEngine.Serialization.FormerlySerializedAs("FastRecycleSpeed")]    private float FortRoutineScope= 700;
[UnityEngine.Serialization.FormerlySerializedAs("CurFishNumber")]
    public int WebCorpWinner= 0;
    private int WebFeeCorpWinner;
[UnityEngine.Serialization.FormerlySerializedAs("_curGameState")]
    public AGameType _NotReapFaint= AGameType.NotStart;
[UnityEngine.Serialization.FormerlySerializedAs("_allSceneFish")]    public List<GameObject> _VanLightCorp= new List<GameObject>();
[UnityEngine.Serialization.FormerlySerializedAs("_hookedFish")]    public List<CorpWish> _DeviseCorp= new List<CorpWish>();
[UnityEngine.Serialization.FormerlySerializedAs("_hookTrans")]    public Transform _KeenShelf;
    private RectTransform _KeenOx;
    private int _FlockHence= 0;
    private float _KeenGroupY;
    private float _KeenLidX;
    private float _KeenFeeX;

    private bool _AtPureWolf;
    private Canvas UIAtomUnable;
    private List<RaycastResult> _KitExamine= new List<RaycastResult>();
    private float ReadFeeArgon= 500;
    private float ReadWebArgon= 0;
    private bool BoardFollowShui = false;
    public GameObject BoardFollow;
    private Vector2 CurHootSize;

    public override void OnCreate()
    {
        base.OnCreate();
        Debug.Log(Screen.height);
        HeRub1.rectTransform.sizeDelta = new Vector2(HeRub1.rectTransform.sizeDelta.x, Screen.height);
        HeRub2.rectTransform.sizeDelta = new Vector2(HeRub2.rectTransform.sizeDelta.x, Screen.height);
        Debug.Log(HeRub1);
        UIAtomUnable = GetComponentInParent<Canvas>();
        if (UIAtomUnable == null) UIAtomUnable = FindObjectOfType<Canvas>();

        _MeOx1 = HeRub1.rectTransform;
        _MeOx2 = HeRub2.rectTransform;
        _MeLateOx = _MeOx1.parent.GetComponent<RectTransform>();

        Vector2 topAnchorMin = new Vector2(0, 1);
        Vector2 topAnchorMax = new Vector2(1, 1);
        Vector2 topPivot = new Vector2(0.5f, 1f);

        _MeOx1.anchorMin = topAnchorMin;
        _MeOx1.anchorMax = topAnchorMax;
        _MeOx1.pivot = topPivot;
        _MeOx2.anchorMin = topAnchorMin;
        _MeOx2.anchorMax = topAnchorMax;
        _MeOx2.pivot = topPivot;

        _PeopleHeFrigid = _MeOx1.rect.height;
        _MeNoisyHerY = 0f;

        SaintTedHeHer();
        CurHootSize = _KeenShelf.GetComponent<RectTransform>().sizeDelta;
        _KeenOx = _KeenShelf.GetComponent<RectTransform>();
        _KeenGroupY = _KeenOx.anchoredPosition.y;
        //_KeenShelf.gameObject.SetActive(false);

        Rect viewRect = _MeLateOx.rect;
        _KeenLidX = viewRect.xMin;
        _KeenFeeX = viewRect.xMax;

        NoisyReap.onClick.AddListener(NoisyReapGood);
        PutPlumb.onClick.AddListener(() => {
            if (AReapEarning.Slowness.PlaySpur >= AReapEarning.Slowness.CurrdepthPrice)
            {
                AttractPlumb(50);
            }
            else
            {
                KingUI<AFuelInner>("Not enough gold coins");
            }
        });
        PutCorpFee.onClick.AddListener(() => {
            if (AReapEarning.Slowness.PlaySpur >= AReapEarning.Slowness.CurrFishPrice)
            {
                AttractCorpFee(1);
            }
            else
            {
                KingUI<AFuelInner>("Not enough gold coins");
            }
        });
        PutCone.onClick.AddListener(() =>
        {
            if (AReapEarning.Slowness.PlaySpur >= AReapEarning.Slowness.CurrEarnPrice)
            {
                AttractCone(10);
            }
            else
            {
                KingUI<AFuelInner>("Not enough gold coins");
            }
        });
        AttractAny.onClick.AddListener(() =>
        {
            var callback = new Action(() => BeCorpCheapen());
            KingUI<AAttractInner>(callback);
        });
        ShovelAny.onClick.AddListener(() => KingUI<ABuyerProbeInner>());
        CoaxAny.onClick.AddListener(() => KingUI<ACoaxUpInner>());
    }

    void SaintTedHeHer()
    {
        _MeOx1.anchoredPosition = new Vector2(0, _MeNoisyHerY);
        _MeOx2.anchoredPosition = new Vector2(0, _MeNoisyHerY - _PeopleHeFrigid);
        _NotLampPlumb = 0f;
        SoNear = true;
    }


    public override void OnRefresh()
    {
        base.OnRefresh();
        AddDepthDesc.text = AReapEarning.Slowness.CurrdepthPrice.ToString();
        AddFishMaxDesc.text = AReapEarning.Slowness.CurrFishPrice.ToString();
        AddEarnDesc.text = AReapEarning.Slowness.CurrEarnPrice.ToString();
        SoNear = true;
        WebFeeCorpWinner = AReapEarning.Slowness.PlayCorpFee;
        CorpPath.text = (WebFeeCorpWinner - WebCorpWinner).ToString() ;
        FeeLampPlumb = AReapEarning.Slowness.PlayPlumb;
        if (FeeLampPlumb >= 20000) FeeLampPlumb = 20000;
        TimeSpan offlineDuration = AReapInstall.Slowness.UpliftYork - AReapInstall.Slowness.SpatialYork;
        float totalMin = (float)offlineDuration.TotalMinutes;
        //����û��60���ӣ�û����������
        if (totalMin < 60)
        {
            totalMin = 0;
        }
        else
        {
            ReadWebArgon = totalMin * AReapEarning.Slowness.PlayRichArgon;
            if (ReadWebArgon >= ReadFeeArgon)
            {
                ReadWebArgon = ReadFeeArgon;
            }
            KingUI<BeneathInner>((int)ReadWebArgon);
        }
    }

    private void Update()
    {
        if (_NotReapFaint == AGameType.NotStart) return;
        CashNarrowPureSenator();
        ShroudSapHillCorpLaurasia();
    }

    #region �㹳��ק
    void CashNarrowPureSenator()
    {
        GameObject hitUI = JobMeanderGinUI();
        if (hitUI != null && hitUI.GetComponent<Button>() != null)
        {
            _AtPureWolf = false;
            return;
        }
        Vector2 screenInput = Input.mousePosition;
        Touch touch = new Touch();
        bool hasTouch = Input.touchCount > 0;
        if (hasTouch)
        {
            touch = Input.GetTouch(0);
            screenInput = touch.position;
        }
        bool isDown = Input.GetMouseButtonDown(0) || (hasTouch && touch.phase == TouchPhase.Began);
        if (isDown) _AtPureWolf = true;
        if (_AtPureWolf)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_MeLateOx, screenInput, UIAtomUnable.worldCamera, out Vector2 localPoint);
            Vector2 newAnchor = _KeenOx.anchoredPosition;
            newAnchor.x = Mathf.Clamp(localPoint.x, _KeenLidX, _KeenFeeX);
            newAnchor.y = _KeenGroupY;
            //_KeenOx.anchoredPosition = newAnchor;

            float xRatio = Mathf.InverseLerp(_KeenLidX, _KeenFeeX, newAnchor.x);
            float rotateZ = Mathf.Lerp(-10, 10, xRatio);
            // �����㹳Z����תʵ��������б
            _KeenOx.localEulerAngles = new Vector3(0, 0, rotateZ);
        }
        bool isUp = Input.GetMouseButtonUp(0) || (hasTouch && touch.phase == TouchPhase.Ended);
        if (isUp) _AtPureWolf = false;
    }
    GameObject JobMeanderGinUI()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Input.touchCount > 0 ? Input.GetTouch(0).position : Input.mousePosition;
        _KitExamine.Clear();
        EventSystem.current.RaycastAll(pointerData, _KitExamine);
        return _KitExamine.Count > 0 ? _KitExamine[0].gameObject : null;
    }
    #endregion

    #region ��Ⱥ
    void SpawnSapCorpDeaf()
    {
        Rect bgTexRect = _MeOx1.rect;
        float minX = bgTexRect.xMin;
        float maxX = bgTexRect.xMax;
        float totalBgOffset = _MeOx1.anchoredPosition.y;
        for (int i = 0; i < CorpSapHaste; i++)
        {
            int randomIdx = UnityEngine.Random.Range(0, CorpSwimmer.Length);
            GameObject fishObj = Instantiate(CorpSwimmer[randomIdx], CorpCarton);
            RectTransform fishRt = fishObj.GetComponent<RectTransform>();
            CorpWish fishItem = fishObj.GetComponent<CorpWish>();
            float randomX = UnityEngine.Random.Range(minX, maxX);
            float randomDepth = fishItem.BrawlLid <= fishItem.BrawlFee ? UnityEngine.Random.Range(fishItem.BrawlLid, fishItem.BrawlFee) : UnityEngine.Random.Range(fishItem.BrawlFee, fishItem.BrawlLid);
            randomDepth = Mathf.Max(randomDepth, 0f);
            fishItem.StarPlumb = randomDepth;
            fishItem.SoCosmic = false;
            fishItem.leftMedium = minX;
            fishItem.GuildMedium = maxX;
            fishItem.CellBet = UnityEngine.Random.value > 0.5f ? 1 : -1;
            float initY = totalBgOffset - randomDepth;
            fishRt.anchoredPosition = new Vector2(randomX, initY);
            _VanLightCorp.Add(fishObj);
        }
    }
    void ShroudSapHillCorpLaurasia()
    {
        foreach (var fishObj in _VanLightCorp)
        {
            CorpWish fishItem = fishObj.GetComponent<CorpWish>();
            if (fishItem.SoCosmic) continue;
            RectTransform fishRt = fishObj.GetComponent<RectTransform>();
            Vector2 curPos = fishRt.anchoredPosition;
            curPos.x += fishItem.CellBet * fishItem.CellScope * Time.deltaTime;
            if (curPos.x <= fishItem.leftMedium)
            {
                curPos.x = fishItem.leftMedium;
                fishItem.CellBet = 1;
            }
            else if (curPos.x >= fishItem.GuildMedium)
            {
                curPos.x = fishItem.GuildMedium;
                fishItem.CellBet = -1;
            }
            fishRt.anchoredPosition = curPos;
            fishRt.localScale = new Vector3(fishItem.CellBet, 1, 1);
        }
    }
    #endregion

    #region ˫��������
    private void FixedUpdate()
    {
        if (!SoNear || _NotReapFaint == AGameType.NotStart) return;
        float speed = _NotReapFaint == AGameType.Drop ? LampScope : (WebCorpWinner >= WebFeeCorpWinner ? FortRoutineScope : InviteRoutineScope);
        float delta = speed * Time.fixedDeltaTime;
        if (BoardFollowShui)
        {
            JuiceSky.transform.position = BoardFollow.transform.position;
        }
        if (_NotReapFaint == AGameType.Drop)
        {
            _NotLampPlumb += delta;
            if (_NotLampPlumb >= FeeLampPlumb)
            {
                _NotLampPlumb = FeeLampPlumb;
                _NotReapFaint = AGameType.Recycle;
                SoNear = false;
                DOVirtual.DelayedCall(1f, () =>
                {
                    if (_NotReapFaint == AGameType.Recycle)
                    {
                        SoNear = true;
                    }
                });
            }
            if (SoNear)
            {
                _MeOx1.anchoredPosition += new Vector2(0, delta);
                _MeOx2.anchoredPosition += new Vector2(0, delta);
                
                AsianHeCast_Lamp();
                
                ThatSapCorpYCredit(delta);
            }
        }
        else if (_NotReapFaint == AGameType.Recycle)
        {
            _NotLampPlumb -= delta;
            if (_NotLampPlumb < 0) _NotLampPlumb = 0;
            _MeOx1.anchoredPosition -= new Vector2(0, delta);
            _MeOx2.anchoredPosition -= new Vector2(0, delta);
            AsianHeCast_Routine();
            ThatSapCorpYCredit(-delta);

            if (_NotLampPlumb <= 0)
            {
                SoNear = false;
                BeCorpCheapen();
                return;
            }
        }
    }

    void AsianHeCast_Lamp()
    {
        float bg1Y = _MeOx1.anchoredPosition.y;
        float bg2Y = _MeOx2.anchoredPosition.y;

        if (bg1Y > _PeopleHeFrigid)
        {

            if (_NotLampPlumb >= _PeopleHeFrigid && _NotLampPlumb <= _PeopleHeFrigid*2)
            {
                BoardFollowShui = false;
                HeRub1.sprite = LawnReliefTomb[2];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid * 3 && _NotLampPlumb <= _PeopleHeFrigid * 4)
            {
                HeRub1.sprite = LawnReliefTomb[4];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid * 5 && _NotLampPlumb <= _PeopleHeFrigid * 6)
            {
                HeRub1.sprite = LawnReliefTomb[6];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid * 6)
            {
                HeRub1.sprite = LawnReliefTomb[6];
            }
            _MeOx1.anchoredPosition = new Vector2(0, bg2Y - _PeopleHeFrigid);
        }  
        if (bg2Y > _PeopleHeFrigid)
        {
            if (_NotLampPlumb >= _PeopleHeFrigid*2 && _NotLampPlumb <= _PeopleHeFrigid * 3)
            {
                HeRub2.sprite = LawnReliefTomb[3];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid * 4 && _NotLampPlumb <= _PeopleHeFrigid * 5)
            {
                HeRub2.sprite = LawnReliefTomb[5];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid * 6)
            {
                HeRub2.sprite = LawnReliefTomb[6];
            }
            _MeOx2.anchoredPosition = new Vector2(0, bg1Y - _PeopleHeFrigid);
        }  
    }
    void AsianHeCast_Routine()
    {
        float bg1Y = _MeOx1.anchoredPosition.y;
        float bg2Y = _MeOx2.anchoredPosition.y;
        if (bg1Y < -_PeopleHeFrigid)
        {
            if (_NotLampPlumb >= _PeopleHeFrigid && _NotLampPlumb <= _PeopleHeFrigid * 2)
            {
                BoardFollowShui = true;
                Vector2 targetSize = _KeenOx.GetComponent<RectTransform>().sizeDelta;
                targetSize.y = 200;
                _KeenOx.GetComponent<RectTransform>().DOSizeDelta(targetSize, 2)
                    .SetEase(Ease.Linear); 
                HeRub1.sprite = LawnReliefTomb[0];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid * 3 && _NotLampPlumb <= _PeopleHeFrigid * 4)
            {
                HeRub1.sprite = LawnReliefTomb[2];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid * 5 && _NotLampPlumb <= _PeopleHeFrigid * 6)
            {
                HeRub1.sprite = LawnReliefTomb[4];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid * 7)
            {
                HeRub1.sprite = LawnReliefTomb[6];
            }
            _MeOx1.anchoredPosition = new Vector2(0, bg2Y + _PeopleHeFrigid);
        }
            
        if (bg2Y < -_PeopleHeFrigid)
        {
            if (_NotLampPlumb <= _PeopleHeFrigid)
            {
                HeRub2.sprite = LawnReliefTomb[1];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid*2 && _NotLampPlumb <= _PeopleHeFrigid * 3)
            {
                HeRub2.sprite = LawnReliefTomb[1];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid * 4 && _NotLampPlumb <= _PeopleHeFrigid * 5)
            {
                HeRub2.sprite = LawnReliefTomb[3];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid * 6 && _NotLampPlumb <= _PeopleHeFrigid * 7)
            {
                HeRub2.sprite = LawnReliefTomb[5];
            }
            if (_NotLampPlumb >= _PeopleHeFrigid * 7)
            {
                HeRub2.sprite = LawnReliefTomb[6];
            }

            
            _MeOx2.anchoredPosition = new Vector2(0, bg1Y + _PeopleHeFrigid);
        } 
    }
    void ThatSapCorpYCredit(float offsetY)
    {
        foreach (var fishObj in _VanLightCorp)
        {
            CorpWish fishItem = fishObj.GetComponent<CorpWish>();
            if (fishItem.SoCosmic) continue;
            RectTransform rt = fishObj.GetComponent<RectTransform>();
            rt.anchoredPosition += new Vector2(0, offsetY);
        }
    }
    #endregion

    private void AttractPlumb(int depth)
    {
        FeeLampPlumb = AReapEarning.Slowness.PlayPlumb + depth;
        if (FeeLampPlumb >= 12000) FeeLampPlumb = 12000;
        AReapEarning.Slowness.PlayPlumb += depth;
        AReapEarning.Slowness.PlaySpur -= AReapEarning.Slowness.CurrdepthPrice;
        AReapEarning.Slowness.CurrdepthPrice += 50;
        AddDepthDesc.text = AReapEarning.Slowness.CurrdepthPrice.ToString();
        
    }
    private void AttractCorpFee(int fishMax)
    {
        WebFeeCorpWinner = AReapEarning.Slowness.PlayCorpFee + fishMax;
        CorpPath.text = (WebFeeCorpWinner - WebCorpWinner).ToString();
        AReapEarning.Slowness.PlaySpur -= AReapEarning.Slowness.CurrFishPrice;
        AReapEarning.Slowness.PlayCorpFee += fishMax;
        AReapEarning.Slowness.CurrFishPrice += 50;
        AddFishMaxDesc.text = AReapEarning.Slowness.CurrFishPrice.ToString();
    }
    private void AttractCone(int earn)
    {
        AReapEarning.Slowness.PlayCone += earn;
        AReapEarning.Slowness.PlaySpur -= AReapEarning.Slowness.CurrEarnPrice;
        AReapEarning.Slowness.CurrEarnPrice += 50;
        AddEarnDesc.text = AReapEarning.Slowness.CurrEarnPrice.ToString();
    }

    #region ����/��ͣ
    private void BeCorpCheapen()
    {

        //JuiceSky.SetActive(true);
        if (_DeviseCorp.Count == 0)
        {
            ReapOverSpyFront();
            return;
        }
        List<CorpWish> tempHookFish = new List<CorpWish>(_DeviseCorp);
        _DeviseCorp.Clear();
        Sequence settleSeq = DOTween.Sequence();
        int total = tempHookFish.Count;
        int addScore = 0;
        for (int i = 0; i < total; i++)
        {
            CorpWish fish = tempHookFish[i];
            fish.transform.parent = CorpCheapen;
            int score = fish.LilyHence;
            addScore += score;
            settleSeq.Append(fish.GetComponent<RectTransform>().DOAnchorPos(Vector3.zero, 0.2f).SetEase(Ease.OutBack));
            settleSeq.Join(fish.GetComponent<RectTransform>().DOScale(Vector3.one * 1.3f, 0.2f).SetEase(Ease.OutBack));
            settleSeq.AppendCallback(() =>
            {
                _FlockHence += score;
            });
            settleSeq.Append(fish.GetComponent<CanvasGroup>()
            .DOFade(0, 0.1f));
            settleSeq.AppendCallback(() => Destroy(fish.gameObject));

            // ÿ������һ��ʱ��
            settleSeq.AppendInterval(0.1f);
        }
        settleSeq.OnComplete(() =>
        {
            ReapOverSpyFront();
        });
    }

    public void ReapOverSpyFront()
    {
        foreach (var fish in _DeviseCorp)
        {
            Destroy(fish.gameObject);
        }
        _DeviseCorp.Clear();
        WebCorpWinner = 0;
        CorpPath.text = (WebFeeCorpWinner - WebCorpWinner).ToString();
        RemodelHenceUI();
        foreach (var fishObj in _VanLightCorp) Destroy(fishObj);
        _VanLightCorp.Clear();
        SaintTedHeHer();
        NoisyReap.gameObject.SetActive(true);
        //_KeenShelf.gameObject.SetActive(false);
        PutPlumb.gameObject.SetActive(true);
        PutCorpFee.gameObject.SetActive(true);
        PutCone.gameObject.SetActive(true);
        SoNear = true;
        _NotReapFaint = AGameType.NotStart;
        _AtPureWolf = false;
    }
    void NoisyReapGood()
    {
        NoisyReap.gameObject.SetActive(false);
        BoardFollowShui = true;
        PutPlumb.gameObject.SetActive(false);
        PutCorpFee.gameObject.SetActive(false);
        PutCone.gameObject.SetActive(false);
        _FlockHence = 0;
        if (_NotReapFaint != AGameType.NotStart) return;
        SaintTedHeHer();
        SpawnSapCorpDeaf();
        _NotReapFaint = AGameType.Drop;
        _KeenOx.localEulerAngles = Vector3.zero;
        //_KeenShelf.gameObject.SetActive(true);
        //_KeenOx.anchoredPosition = new Vector2(0, _KeenGroupY);
        Vector2 targetSize = _KeenOx.GetComponent<RectTransform>().sizeDelta;
        targetSize.y = Screen.height + 500;
        _KeenOx.GetComponent<RectTransform>().DOSizeDelta(targetSize, 2)
            .SetEase(Ease.Linear); // 匀速放大，去掉这句会有缓动效果
        
        SoNear = true;
    }
    void RemodelHenceUI()
    {
        KingUI<ACitherInner>(_FlockHence);
    }
    #endregion
}