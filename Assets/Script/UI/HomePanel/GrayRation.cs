using UnityEngine;

public class GrayRation : MonoBehaviour
{
    private const string TuneTag= "Wall";
    private const string SoonEye= "Fish";

    private bool m_GazeTerrainConstantMildGolf;
    private bool m_GazeRutHonestFewConstantMildGrayGolf;

    private void OnEnable()
    {
        m_GazeTerrainConstantMildGolf = false;
        m_GazeRutHonestFewConstantMildGrayGolf = false;
        LuxuryHop.OrGrayGolfReplant -= PrimeGazeGolfSweet;
        LuxuryHop.OrGrayGolfReplant += PrimeGazeGolfSweet;
    }

    private void OnDisable()
    {
        LuxuryHop.OrGrayGolfReplant -= PrimeGazeGolfSweet;
    }

    void PrimeGazeGolfSweet()
    {
        m_GazeTerrainConstantMildGolf = false;
        m_GazeRutHonestFewConstantMildGrayGolf = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if (!RopeStrange.Instance.HeGrayAdjoin)
        {
            return;
        }
        if (RopeStrange.Instance.LawHerGrayHP() <= 0)
        {
            return;
        }
        if (other.CompareTag(TuneTag))
        {
            LuxuryHop.OrFolkTune?.Invoke();
            Debug.Log($"GrayRation 碰到墙体(Trigger): {other.name}");
        }

        if (RopeStrange.Instance.LawHerGrayHP () > 0)
        {
            // 允许弱点/子碰撞器不带 Tag=Fish：只要它隶属 UISoonMandan 就算命中。
            UISoonMandan uIFishEntity = other.GetComponentInParent<UISoonMandan>();
            if (uIFishEntity != null)
            {
                LuxuryHop.OrFolkSoon?.Invoke();
                UISoonMandan.KeaStifleGazeTerrainSituateMossDewGolf(uIFishEntity, other, ref m_GazeTerrainConstantMildGolf);
                uIFishEntity.FoodFewBeDevotion(other, ref m_GazeRutHonestFewConstantMildGrayGolf);
                Debug.Log($"GrayRation 碰到鱼(Trigger): {other.name}");
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag(TuneTag)) return;
        Debug.Log($"GrayRation 碰到墙体(Collision): {collision.collider.name}");
    }
}
