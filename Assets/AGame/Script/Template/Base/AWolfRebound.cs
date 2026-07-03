using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWolfRebound : MonoBehaviour
{
[UnityEngine.Serialization.FormerlySerializedAs("gamePanel")]    // ��ק��ֵ����ϵ� AReapInner_A
    public AReapInner_A ExamInner;
[UnityEngine.Serialization.FormerlySerializedAs("CatshFish")]
    public Transform MountCorp;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ExamInner._NotReapFaint == AGameType.Drop)
            return;
        CorpWish fish = other.GetComponent<CorpWish>();
        // ������ / �Ѿ�����ס / �Ѵ����������ֱ������
        if (fish == null || fish.SoCosmic) return;
        if (ExamInner.WebCorpWinner >= AReapEarning.Slowness.PlayCorpFee) return;

        // �����߼�����ȫ������ԭ����ҵ���߼���
        fish.SoCosmic = true;
        fish.KeenCarton = MountCorp;
        other.transform.SetParent(MountCorp);
        other.transform.localPosition = new Vector3(0, -ExamInner.WebCorpWinner, 0);

        ExamInner._DeviseCorp.Add(fish);
        ExamInner.WebCorpWinner++;
        ExamInner.CorpPath.text = (AReapEarning.Slowness.PlayCorpFee - ExamInner.WebCorpWinner).ToString();
        ExamInner._VanLightCorp.Remove(other.gameObject);
    }
}
