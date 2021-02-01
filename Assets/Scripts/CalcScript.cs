using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class CalcScript : MonoBehaviour
{
    public Toggle man;
    public Toggle women;
    public Dropdown birthDay;
    public Dropdown birthMonth;
    public Dropdown birthYear;
    public GameObject expField2;
    public Dropdown exp1;
    public InputField exp1Months;
    public InputField exp1Years;
    public InputField pensionDate;

    private int dateYear = DateTime.Now.Year;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }

    private void defaultPension(int bYear, ref int defPensionYear, ref int defPensionMonth, bool forMan)
    {
        if (forMan)
        {
            if (bYear < 1960)
            {
                defPensionYear += 60;
                defPensionMonth += 6;
            }
            else if (bYear < 1961)
            {
                defPensionYear += 61;
                defPensionMonth += 6;
            }
            else if (bYear < 1962) defPensionYear += 63;
            else if (bYear < 1963) defPensionYear += 64;
            else defPensionYear += 65;
        }
        else
        {
            if (bYear < 1964)
            {
                defPensionYear += 55;
                defPensionMonth += 6;
            }
            else if (bYear < 1965)
            {
                defPensionYear += 56;
                defPensionMonth += 6;
            }
            else if (bYear < 1966) defPensionYear += 58;
            else if (bYear < 1967) defPensionYear += 59;
            else defPensionYear += 60;
        }

        if (defPensionMonth > 12)
        {
            defPensionYear++;
            defPensionMonth -= 12;
        }
    }

    private void ped_medPension(int bYear, int stageYear, ref int defPensionYear, ref int defPensionMonth, bool forMan)
    {
        int stageYearTail = 30 - stageYear;
        int finalStageYear = dateYear + stageYearTail;

        if (finalStageYear < 2020) defPensionYear = finalStageYear;
        else if (finalStageYear == 2020) defPensionYear = finalStageYear + 2;
        else if (finalStageYear == 2021) defPensionYear = finalStageYear + 3;
        else if (finalStageYear == 2022) defPensionYear = finalStageYear + 4;
        else if (finalStageYear > 2022) defPensionYear = finalStageYear + 5;

        if(forMan)
        {
            if (defPensionYear - bYear > 65) defaultPension(bYear, ref defPensionYear, ref defPensionMonth, forMan);
        }
        else
        {
            if(defPensionYear - bYear > 60) defaultPension(bYear, ref defPensionYear, ref defPensionMonth, forMan);
        }
    }

    private void actorPension(int bYear, int stageYear, ref int defPensionYear, ref int defPensionMonth, bool forMan)
    {
        int stageYearTail = 15 - stageYear;
        int finalStageYear = dateYear + stageYearTail;

        if (finalStageYear < 2020) defPensionYear = finalStageYear;
        else if (finalStageYear == 2020) defPensionYear = finalStageYear + 2;
        else if (finalStageYear == 2021) defPensionYear = finalStageYear + 3;
        else if (finalStageYear == 2022) defPensionYear = finalStageYear + 4;
        else if (finalStageYear > 2022) defPensionYear = finalStageYear + 5;

        if (forMan)
        {
            if (defPensionYear - bYear > 65) defaultPension(bYear, ref defPensionYear, ref defPensionMonth, forMan);
        }
        else
        {
            if (defPensionYear - bYear > 60) defaultPension(bYear, ref defPensionYear, ref defPensionMonth, forMan);
        }
    }

    private void list_1Pension(int bYear, int stageYear, int stageMonth, ref int defPensionYear, ref int defPensionMonth, bool forMan)
    {
        defaultPension(bYear, ref defPensionYear, ref defPensionMonth, forMan);

        if (stageYear >= 10)
        {
                        defPensionYear -= 10;
        }
        else if (stageYear >= 9)
        {
            if (forMan) defPensionYear -= 9;
            else        defPensionYear -= 10;
        }
        else if (stageYear >= 8)
        {
            if (forMan) defPensionYear -= 8;
            else        defPensionYear -= 10;
        }
        else if (stageYear >= 7 && stageMonth >= 6)
        {
            if (forMan) defPensionYear -= 7;
            else        defPensionYear -= 10;
        }
        else if (stageYear >= 7)
        {
                        defPensionYear -= 7;
        }
        else if (stageYear >= 6)
        {
                        defPensionYear -= 6;
        }
        else if (stageYear >= 5)
        {
                        defPensionYear -= 5;
        }
        else if (stageYear >= 4)
        {
            if (!forMan) defPensionYear -= 4;
        }
        else if (stageYear >= 3 && stageMonth >= 9)
        {
            if (!forMan) defPensionYear -= 3;
        }
    }

    private void list_2Pension(int bYear, int stageYear, int stageMonth, ref int defPensionYear, ref int defPensionMonth, bool forMan)
    {
        defaultPension(bYear, ref defPensionYear, ref defPensionMonth, forMan);

        if (stageYear >= 12 && stageMonth >= 6)
        {
            defPensionYear -= 5;
        }
        else if (stageYear >= 10)
        {
            if (forMan) defPensionYear -= 4;
            else defPensionYear -= 5;
        }
        else if (stageYear >= 8)
        {
            if (forMan) defPensionYear -= 3;
            else defPensionYear -= 4;
        }
        else if (stageYear >= 7 && stageMonth >= 6)
        {
            defPensionYear -= 3;
        }
        else if (stageYear >= 6 && stageMonth >= 3)
        {
            if (forMan) defPensionYear -= 2;
            else defPensionYear -= 3;
        }
        else if (stageYear >= 6)
        {
            if (!forMan) defPensionYear -= 3;
        }
        else if (stageYear >= 5)
        {
            if (!forMan) defPensionYear -= 2;
        }
    }

    private void NorthPension(int bYear, int stageYear, int stageMonth, ref int defPensionYear, ref int defPensionMonth, bool forMan)
    {

    }

    public void updatePensionDate()
    {
        if (((man.isOn || women.isOn)
           && !(man.isOn && women.isOn)) &&
           birthDay.captionText.text != "הה" &&
           birthMonth.captionText.text != "לל" &&
           birthYear.captionText.text != "דדדד")
        {
            int bYearNum = Convert.ToInt32(birthYear.captionText.text);
            int bMonthNum = Convert.ToInt32(birthMonth.captionText.text);
            int bDayNum = Convert.ToInt32(birthDay.captionText.text);
            int defPensionYear = bYearNum;
            int defPensionMonth = bMonthNum;

            defaultPension(bYearNum, ref defPensionYear, ref defPensionMonth, man.isOn);
            pensionDate.text = Convert.ToString(bDayNum) + "." + Convert.ToString(defPensionMonth) + "." + Convert.ToString(defPensionYear);
        }
        else
        {
            pensionDate.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
