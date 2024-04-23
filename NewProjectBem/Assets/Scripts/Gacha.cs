using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gacha : MonoBehaviour
{
    public List<string> UniquePetList = new List<string>() { "Â¯¼¾ Æê", "Á¸³ª¼¾ Æê" };
    public List<string> RarePetList = new List<string>() { "Æê", "Æê2" };

    public string grade;

    public void GoGacha()
    {
        int rand = Random.Range(0, 100);

        if (rand < 10) {
            grade = "Unique";
            int pet = Random.Range(0, UniquePetList.Count);
            print($"À¯´ÏÅ© Æê '{UniquePetList[pet]}'È¹µæ!");
            return;
        }
        else if (rand >= 10 && rand < 30)
        {
            grade = "Rare";
            int pet = Random.Range(0, RarePetList.Count);
            print($"·¹¾î Æê '{RarePetList[pet]}'È¹µæ!");
            return;
        }
        else
        {
            grade = "Common";
            int gainPerk = Random.Range(1,6);
            SaveData.instance.perk += gainPerk;
            PlayerPrefs.SetInt("SavePerk",SaveData.instance.perk);
            print($"ÆÜ Æ÷ÀÎÆ® È¹µæ: {gainPerk}");
            return;
        }    
    }

    public void OneGacha()
    {
        if (SaveData.instance.gem >= 1) {
            GoGacha();
            print("1È¸ »Ì±â ¼º°ø!(UIÃâ·ÂÀ¸·Î ¹Ù²Ü °Í)"); }
        else
            print("Áª °³¼ö°¡ ºÎÁ·ÇÕ´Ï´Ù.(UIÃâ·ÂÀ¸·Î ¹Ù²Ü °Í)");
    }
    public void TenGacha()
    {
        if (SaveData.instance.gem >= 10)
        {
            for (int i = 0; i < 10; i++)
                GoGacha();
            print("10È¸ »Ì±â ¼º°ø!(UIÃâ·ÂÀ¸·Î ¹Ù²Ü °Í)");
        }
        else
            print("Áª °³¼ö°¡ ºÎÁ·ÇÕ´Ï´Ù.(UIÃâ·ÂÀ¸·Î ¹Ù²Ü °Í)");
    }
}
