using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SaveData : MonoBehaviour
{
    public static SaveData instance;
    [HideInInspector]
    public int perk;
    [HideInInspector]
    public int gem;

    [SerializeField]
    public float baseDmg;
    public float baseSpd;
    public float baseMHp;
    public int needPerk;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Ȯ�ο�
        // PlayerPrefs.SetInt("SavePerk", 1);
        PlayerPrefs.SetInt("SavePerk", PlayerPrefs.GetInt("SavePerk")+PlayerPrefs.GetInt("GainPerk"));  //GameManager���� ������ ���� ����ҿ� ����
        perk = PlayerPrefs.GetInt("SavePerk");
        print($"SavePerk: {PlayerPrefs.GetInt("SavePerk")}");
        print($"GainPerk: {PlayerPrefs.GetInt("GainPerk")}");
        print($"Perk����: {perk}");

        //Gem Setting
        PlayerPrefs.SetInt("SavePerk", PlayerPrefs.GetInt("SaveGem") + PlayerPrefs.GetInt("GainGem"));  //GameManager���� ������ ���� ����ҿ� ����
        gem = PlayerPrefs.GetInt("SaveGem");
        print($"SaveGem: {PlayerPrefs.GetInt("SaveGem")}");
        print($"GainGem: {PlayerPrefs.GetInt("GainGem")}");
        print($"Gem����: {gem}");
    }

    public void Reset()
    {
        //�� ���� �ʱ�ȭ
        PlayerPrefs.SetInt("SavePerk", 0);
        PlayerPrefs.SetInt("GainPerk", 0);
        perk = 0;

        //�� ���� �ʱ�ȭ
        PlayerPrefs.SetInt("SaveGem", 0);
        PlayerPrefs.SetInt("GainGem", 0);
        gem = 0;

        //�� ���� �ʱ�ȭ
        PlayerPrefs.SetFloat("BaseDmg", 0);
        PlayerPrefs.SetFloat("BaseSpd", 0);
        PlayerPrefs.SetFloat("BaseMHp", 0);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(0);
    }


    // �� ���׷��̵� �Լ���
    public void BaseDmgUpg()
    {
        //Weapon��ũ��Ʈ
        if (perk <= 0)
            return;
        PlayerPrefs.SetFloat("BaseDmg", PlayerPrefs.GetFloat("BaseDmg")+ baseDmg);
        perk -= needPerk;
        PlayerPrefs.SetInt("SavePerk", perk);
    }

    public void BaseSpdUpg()
    {
        //Gear��ũ��Ʈ, Player��ũ��Ʈ
        if (perk <= 0)
            return;
        PlayerPrefs.SetFloat("BaseSpd", PlayerPrefs.GetFloat("BaseSpd") + baseSpd);
        perk -= needPerk;
        PlayerPrefs.SetInt("SavePerk", perk);
    }
    public void BaseMHpUpg()
    {
        //GameManager��ũ��Ʈ
        if (perk <= 0)
            return;
        PlayerPrefs.SetFloat("BaseMHp", PlayerPrefs.GetFloat("BaseMHp") + baseMHp);
        perk -= needPerk;
        PlayerPrefs.SetInt("SavePerk", perk);
    }
}