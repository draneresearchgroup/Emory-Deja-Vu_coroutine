using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class IDEAResponses : MonoBehaviour
{

    private DataPrint DataPrinter;  // to write file info


    // Start is called before the first frame update
    void Start()
    {
        DataPrinter = new DataPrint();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void A1_never()
    {
        DataPrinter.WriteToFile("\n" + "IDEA Questions Subset" + "\n");

        DataPrinter.WriteToFile("A1: never\n");
    }
    public void A1_yes_infrequently()
    {
        DataPrinter.WriteToFile("\n" + "IDEA Questions Subset" + "\n");

        DataPrinter.WriteToFile("A1: Yes very infrequently\n");
    }
   
    public void A1_yes_sometimes()
    {
        DataPrinter.WriteToFile("\n" + "IDEA Questions Subset" + "\n");

        DataPrinter.WriteToFile("A1: Yes sometimes\n");
    }
    public void A1_yes_often()
    {
        DataPrinter.WriteToFile("\n" + "IDEA Questions Subset" + "\n");

        DataPrinter.WriteToFile("A1: Yes often\n");
    }
    public void A1_yes_more_frequently()
    {
        DataPrinter.WriteToFile("\n" + "IDEA Questions Subset" + "\n");

        DataPrinter.WriteToFile("A1: Yes more frequently\n");
    }
    public void A1_dontknow()
    {
        DataPrinter.WriteToFile("\n" + "IDEA Questions Subset" + "\n");

        DataPrinter.WriteToFile("A1: Don't know\n");
    }




    public void B2_no()
    {
        DataPrinter.WriteToFile("B2: No\n");
    }
    public void B2_vaguely()
    {
        DataPrinter.WriteToFile("B2: I vaguely remember\n");
    }
    public void B2_yes_i_remeber()
    {
        DataPrinter.WriteToFile("B2: Yes, I can remember exactly\n");
    }
    public void B2_Dont_Know()
    {
        DataPrinter.WriteToFile("B2: Don’t know\n");
    }


    public void B3_more_than5()
    {
        DataPrinter.WriteToFile("B2: More than 5 years ago\n");
    }
    public void B3_1to5()
    {
        DataPrinter.WriteToFile("B2: 1 to 5 years ago\n");
    }
    public void B3_6moto1yr()
    {
        DataPrinter.WriteToFile("B2: 6 months to 1 year ago\n");
    }
    public void B3_2to6months()
    {
        DataPrinter.WriteToFile("B2: 2 to 6 months ago\n");
    }
    public void B3_1to2months()
    {
        DataPrinter.WriteToFile("B2: 1 to 2 months ago\n");
    }
    public void B3_lastmonth()
    {
        DataPrinter.WriteToFile("B2: Last month\n");
    }
    public void B3_dontknow()
    {
        DataPrinter.WriteToFile("B2: Don’t know\n");
    }



    public void B4_onesec()
    {
        DataPrinter.WriteToFile("B4: One second or less\n");
    }
    public void B4_fewsec()
    {
        DataPrinter.WriteToFile("B4: A few seconds\n");
    }
    public void B4_mins()
    {
        DataPrinter.WriteToFile("B4: One minute or a couple of minutes\n");
    }
    public void B4_halfhour()
    {
        DataPrinter.WriteToFile("B4: Half an hour to one hour\n");
    }
    public void B4_fewhours()
    {
        DataPrinter.WriteToFile("B4: A few hours\n");
    }
    public void B4_morethanafewhours()
    {
        DataPrinter.WriteToFile("B4: More than a few hours\n");
    }
    public void B4_dontknow()
    {
        DataPrinter.WriteToFile("B4: Don’t know\n");
    }



    public void B5_total()
    {
        DataPrinter.WriteToFile("B5: Total\n");
    }
    public void B5_somepart()
    {
        DataPrinter.WriteToFile("B5: Some part of it\n");
    }
    public void B5_depends()
    {
        DataPrinter.WriteToFile("B5: It depends\n");
    }
    public void B5_dontknow()
    {
        DataPrinter.WriteToFile("B5: Don’t know\n");
    }


    public void B6_no()
    {
        DataPrinter.WriteToFile("B6: No\n");
    }
    public void B6_inthemorning()
    {
        DataPrinter.WriteToFile("B6: In the morning shortly after waking\n");
    }
    public void B6_daytime()
    {
        DataPrinter.WriteToFile("B6: In the Daytime\n");
    }
    public void B6_dark()
    {
        DataPrinter.WriteToFile("B6: When it gets dark\n");
    }
    public void B6_evening()
    {
        DataPrinter.WriteToFile("B6: In the evening (with the lights on)\n");
    }
    public void B6_beforebed()
    {
        DataPrinter.WriteToFile("B6: Just before or after going to bed\n");
    }
    public void B6_dontknow()
    {
        DataPrinter.WriteToFile("B6: Don’t know\n");
    }


    public void B7_never()
    {
        DataPrinter.WriteToFile("B7: Never\n");
    }
    public void B7_veryinfrequently()
    {
        DataPrinter.WriteToFile("B7: Very infrequently (less than once per year)\n");
    }
    public void B7_sometimes()
    {
        DataPrinter.WriteToFile("B7: Sometimes (a few times a year)\n");
    }
    public void B7_often()
    {
        DataPrinter.WriteToFile("B7: Often (a few times a month)\n");
    }
    public void B7_morefrequently()
    {
        DataPrinter.WriteToFile("B7: More frequently (at least weekly)\n");
    }
    public void B7_dontknow()
    {
        DataPrinter.WriteToFile("B6: Don’t know\n");
    }



    public void endIdea()
    {
        DataPrinter.WriteToFile("\n" + "============================================" + "\n");
    }
}

