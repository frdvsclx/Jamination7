using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    CharacterController controller;
    string CheckTag = "Urgot";
    public int VoidHeal;
    public int VoidHealMax;
    string NewTag;

    private void Start()
    {
        VoidHealMax = VoidHeal;
    }
    private void Update()
    {
        if(controller != null)
        {
            WhoAmI();
        }else
        {
            //
        }

        CalculatedHp();
    }

    void WhoAmI()
    {
        controller = GameObject.FindAnyObjectByType<CharacterController>();
        GameObject WhoIAm = controller.gameObject;
        string WhoTag = WhoIAm.tag;
        if(CheckTag.CompareTo(WhoTag) != 0)
        {
            NewTag = WhoTag;
            HpController(NewTag);
            CheckTag = WhoTag;

        }
        if(controller ==null)
        {
            VoidHeal = VoidHeal - 10;
            if(VoidHeal <=0  )
            {
                //GameOver;
            }
            
        }


        
    }


    void HpController(string Tag)
    {
        switch (Tag)
        {
            case "Deer":
                VoidHeal = 70;
                VoidHealMax = VoidHeal;
                break;
            case "Bird":
                VoidHeal = 40;
                VoidHealMax = VoidHeal;
                break;
            case "Rabbit":
                VoidHeal = 50;
                VoidHealMax = VoidHeal;
                break;
        }
    }
    
    void CalculatedHp()
    {
    
    }
   
}
