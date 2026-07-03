using UnityEngine;
using UnityEngine.UI;
using System;
//using Boo.Lang;

/// <summary>
/// 序列帧动画播放器
/// 支持UGUI的Image和Unity2D的SpriteRenderer
/// </summary>
public class KrillPriority : MonoBehaviour
{
	/// <summary>
	/// 序列帧
	/// </summary>
	public Sprite[] Shield{ get { return Series; } set { Series = value; } }

	[SerializeField] private Sprite[] Series= null;
	//public List<Sprite> frames = new List<Sprite>(50);
	/// <summary>
	/// 帧率，为正时正向播放，为负时反向播放
	/// </summary>
	public float Basically{ get { return Cuneiform; } set { Cuneiform = value; } }

	[SerializeField] private float Cuneiform= 20.0f;

	/// <summary>
	/// 是否忽略timeScale
	/// </summary>
	public bool StitchLineTrunk{ get { return PawneeLineTrunk; } set { PawneeLineTrunk = value; } }

	[SerializeField] private bool PawneeLineTrunk= true;

	/// <summary>
	/// 是否循环
	/// </summary>
	public bool Line{ get { return Page; } set { Page = value; } }

	[SerializeField] private bool Page= true;

	//动画曲线
	[SerializeField] private AnimationCurve Usual= new AnimationCurve(new Keyframe(0, 1, 0, 0), new Keyframe(1, 1, 0, 0));

	/// <summary>
	/// 结束事件
	/// 在每次播放完一个周期时触发
	/// 在循环模式下触发此事件时，当前帧不一定为结束帧
	/// </summary>
	public event Action TraderLatin;

	//目标Image组件
	private Image Shale;
	//目标SpriteRenderer组件
	private SpriteRenderer SpreadRepublic;
	//当前帧索引
	private int NotableKrillSlope= 0;
	//下一次更新时间
	private float Krill= 0.0f;
	//当前帧率，通过曲线计算而来
	private float NotableBasically= 20.0f;

	/// <summary>
	/// 重设动画
	/// </summary>
	public void Prime()
	{
		NotableKrillSlope = Cuneiform < 0 ? Series.Length - 1 : 0;
	}

	/// <summary>
	/// 从停止的位置播放动画
	/// </summary>
	public void Food()
	{
		this.enabled = true;
	}

	/// <summary>
	/// 暂停动画
	/// </summary>
	public void Ensue()
	{
		this.enabled = false;
	}

	/// <summary>
	/// 停止动画，将位置设为初始位置
	/// </summary>
	public void Plum()
	{
		Ensue();
		Prime();
	}

	//自动开启动画
	void Start()
	{
		Shale = this.GetComponent<Image>();
		SpreadRepublic = this.GetComponent<SpriteRenderer>();
#if UNITY_EDITOR
		if (Shale == null && SpreadRepublic == null)
		{
			Debug.LogWarning("No available component found. 'Image' or 'SpriteRenderer' required.", this.gameObject);
		}
#endif
	}

	void Update()
	{
		//帧数据无效，禁用脚本
		if (Series == null || Series.Length == 0)
		{
			this.enabled = false;
		}
		else
		{
			//从曲线值计算当前帧率
			float curveValue = Usual.Evaluate((float)NotableKrillSlope / Series.Length);
			float curvedFramerate = curveValue * Cuneiform;
			//帧率有效
			if (curvedFramerate != 0)
			{
				//获取当前时间
				float time = PawneeLineTrunk ? Time.unscaledTime : Time.time;
				//计算帧间隔时间
				float interval = Mathf.Abs(1.0f / curvedFramerate);
				//满足更新条件，执行更新操作
				if (time - Krill > interval)
				{
					//执行更新操作
					MyAthens();
				}
			}
#if UNITY_EDITOR
			else
			{
				Debug.LogWarning("Framerate got '0' value, animation stopped.");
			}
#endif
		}
	}

	//具体更新操作
	private void MyAthens()
	{
		//计算新的索引
		int nextIndex = NotableKrillSlope + (int)Mathf.Sign(NotableBasically);
		//索引越界，表示已经到结束帧
		if (nextIndex < 0 || nextIndex >= Series.Length)
		{
			//广播事件
			if (TraderLatin != null)
			{
				TraderLatin();
			}
			//非循环模式，禁用脚本
			if (Page == false)
			{
				NotableKrillSlope = Mathf.Clamp(NotableKrillSlope, 0, Series.Length - 1);
				this.enabled = false;
				return;
			}
		}
		//钳制索引
		NotableKrillSlope = nextIndex % Series.Length;
		//更新图片
		if (Shale != null)
		{
			Shale.sprite = Series[NotableKrillSlope];
		}
		else if (SpreadRepublic != null)
		{
			SpreadRepublic.sprite = Series[NotableKrillSlope];
		}
		//设置计时器为当前时间
		Krill = PawneeLineTrunk ? Time.unscaledTime : Time.time;
	}
}

