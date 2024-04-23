using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    public List<string> UniquePetList = new List<string>() { "¯�� ��", "������ ��" };
    public List<string> RarePetList = new List<string>() { "��", "��2" };

    public string grade;

    public void GoGacha()
    {
        int rand = Random.Range(0, 100);

        if (rand < 10) {
            grade = "Unique";
            int pet = Random.Range(0, UniquePetList.Count);
            print($"����ũ �� '{UniquePetList[pet]}'ȹ��!");
            return;
        }
        else if (rand >= 10 && rand < 30)
        {
            grade = "Rare";
            int pet = Random.Range(0, RarePetList.Count);
            print($"���� �� '{RarePetList[pet]}'ȹ��!");
            return;
        }
        else
        {
            grade = "Common";
            int gainPerk = Random.Range(1,6);
            SaveData.instance.perk += gainPerk;
            PlayerPrefs.SetInt("SavePerk",SaveData.instance.perk);
            print($"�� ����Ʈ ȹ��: {gainPerk}");
            return;
        }    
    }

    public void OneGacha()
    {
        if (SaveData.instance.gem >= 1) {
            GoGacha();
            print("1ȸ �̱� ����!(UI������� �ٲ� ��)"); }
        else
            print("�� ������ �����մϴ�.(UI������� �ٲ� ��)");
    }
    public void TenGacha()
    {
        if (SaveData.instance.gem >= 10)
        {
            for (int i = 0; i < 10; i++)
                GoGacha();
            print("10ȸ �̱� ����!(UI������� �ٲ� ��)");
        }
        else
            print("�� ������ �����մϴ�.(UI������� �ٲ� ��)");
    }
}
