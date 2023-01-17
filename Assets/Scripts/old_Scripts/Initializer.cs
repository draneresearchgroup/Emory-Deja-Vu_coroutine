using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Initializer : MonoBehaviour
{
    // Start is called before the first frame update
    private int counter;
    public int version;   //sets the version of the task
    private int condition; //sets whether or not it is study or test condition
    public int block; //sets which block we are in
    private int temp;
    public static List<DJV> StudyDJVlist;
    public static List<DJV> TestDJVlist;
    public VideoClip[] studyScenesL;
    public VideoClip[] studyScenesR;
    public VideoClip[] testScenesL;
    public VideoClip[] testScenesR;
    public VideoClip[] testScenes;
    public AudioClip[] sceneNames;
    public string[] StudySceneNameR;
    public string[] StudySceneNameL;
    public string[] TestSceneNameR;
    public string[] TestSceneNameL;
    public DJV element;
    public bool questionaire;


    void Start()
    {
        PlayerPrefs.DeleteAll();
        InitializeVersion(version, block);
        counter  = StudyDJVlist.Count;
        condition = 0; // default should be 0 = study condition
        if(questionaire ==false){
            SceneManager.LoadScene("Instructions");  //toggle this to use questionaire or not
        }


    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("counter", counter);
        PlayerPrefs.SetInt("Version", version);
        PlayerPrefs.SetInt("Condition", condition); 

    }

    void InitializeVersion(int version, int block)
    {
        if (version == 1)
        {
            if(block == 1)
            {
                InitializeVersion1_Block1();
            }
            else
            {
                InitializeVersion1_Block2();
            }
        }
        else if(version == 2)
        {
            if (block == 1)
            {
                InitializeVersion2_Block1();
            }
            else
            {
                InitializeVersion2_Block2();
            }
        }
        else if (version == 3)
        {
            if (block == 1)
            {
                InitializeVersion3_Block1();
            }
            else
            {
                InitializeVersion3_Block2();
            }
        }
        else if (version ==4)
        {
            if (block == 1)
            {
                InitializeVersion4_Block1();
            }
            else
            {
                InitializeVersion4_Block2();
            }
        }
        
        else if (version == 5)  //change back to else
        {
            if (block == 1)
            {
                InitializeVersion5_Block1();
            }
            else
            {
               InitializeVersion4_Block2();
            }
        }

        else
        {
            throw new System.Exception();
        }
    }

    
    void InitializeVersion1_Block1()
    {

        int[] version1 = new int[] { 4, 57, 21, 35, 40, 55, 14, 54, 56, 38, 22, 34, 51, 6, 45, 18 };  //left, then right
        char[] version1Turn = new char[] { 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R' }; //left, then right
        int[] version1Test = new int[] { 4, 57, 21, 35, 40, 55, 14, 54, 56, 38, 22, 34, 51, 6, 45, 18, 47, 12, 49, 10, 62, 52, 20, 5, 3, 13, 61, 15, 33, 2, 32, 11 }; 
        char[] version1TurnTest = new char[] { 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R' };
        char[] studiedConditionTest = new char[] { 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' };

        StudyDJVlist = new List<DJV>();
        TestDJVlist = new List<DJV>();

        PopulateStudyList(version1, version1Turn, StudyDJVlist);
        PopulateTestList(version1Test, version1TurnTest, studiedConditionTest, TestDJVlist);
    }

    void InitializeVersion1_Block2()
    {

        int[] version1 = new int[] { 30, 29, 39, 41, 23, 58, 26, 44, 48, 17, 60, 31, 43, 9, 36, 59 };  //left, then right
        char[] version1Turn = new char[] { 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R' }; //left, then right
        int[] version1Test = new int[] { 30, 29,39,41,23,58, 26,44,48,17,60,31,43,9,36,59,64,1,46,28,25,53,27,63,37,7,42,19,50,23,8,16 };
        char[] version1TurnTest = new char[] { 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R' };
        char[] studiedConditionTest = new char[] { 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' };


        StudyDJVlist = new List<DJV>();
        TestDJVlist = new List<DJV>();

        PopulateStudyList(version1, version1Turn, StudyDJVlist);
        PopulateTestList(version1Test, version1TurnTest, studiedConditionTest, TestDJVlist);
    }

    void InitializeVersion2_Block1()
    {

        int[] version2 = new int[] { 4, 57, 21, 35, 40, 55, 14, 54, 56, 38, 22, 34, 51, 6, 45, 18 }; //right, then left
        char[] version2Turn = new char[] { 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L' }; //right, then left

        int[] version2Test = new int[] { 4, 57, 21, 35, 40, 55, 14, 54, 56, 38, 22, 34, 51, 6, 45, 18, 47, 12, 49, 10, 62, 52, 20, 5, 3, 13, 61, 15, 33, 2, 32, 11 };
        char[] version2TurnTest = new char[] { 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L' };
        char[] studiedConditionTest = new char[] { 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' };


        StudyDJVlist = new List<DJV>();
        TestDJVlist = new List<DJV>();

        PopulateStudyList(version2, version2Turn, StudyDJVlist);
        PopulateTestList(version2Test, version2TurnTest, studiedConditionTest, TestDJVlist);
    }

    void InitializeVersion2_Block2()
    {

        int[] version2 = new int[] { 30, 29, 39, 41, 23, 58, 26, 44,48, 17, 60,31,43,9, 36,59 }; //right, then left
        char[] version2Turn = new char[] { 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L' }; //right, then left

        int[] version2Test = new int[] { 30, 29, 39, 41, 23, 58, 26, 44, 48, 17, 60, 31, 43, 9, 36, 59, 64, 1,46, 28,25,53,27,63, 37, 7, 42, 19, 50,23, 8, 16 };
        char[] version2TurnTest = new char[] { 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L' };
        char[] studiedConditionTest = new char[] { 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' };


        StudyDJVlist = new List<DJV>();
        TestDJVlist = new List<DJV>();

        PopulateStudyList(version2, version2Turn, StudyDJVlist);
        PopulateTestList(version2Test, version2TurnTest, studiedConditionTest, TestDJVlist);
    }


    void InitializeVersion3_Block1()
    {
        int[] version3 = new int[] { 47, 12, 49, 10, 62, 52, 20, 5, 3, 13, 61, 15, 33, 2, 32, 11  };  //left, then right 
        char[] version3Turn = new char[] { 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R' };
        int[] version3Test = new int[] { 47, 12, 49, 10, 62, 52, 20, 5, 3, 13, 61, 15, 33, 2, 32, 11, 4, 57, 21, 35, 40, 55, 14, 54, 56, 38, 22, 34, 51, 6, 45, 18 };
        char[] version3TurnTest = new char[] { 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R' };
        char[] studiedConditionTest = new char[] { 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' };



        StudyDJVlist = new List<DJV>();
        TestDJVlist = new List<DJV>();

        PopulateStudyList(version3, version3Turn, StudyDJVlist);
        PopulateTestList(version3Test, version3TurnTest, studiedConditionTest, TestDJVlist);
    }

    void InitializeVersion3_Block2()
    {
        int[] version3 = new int[] { 64,1,46,28,25,53,27,63,37,7,42,19,50,23,8,16 };  //left, then right
        char[] version3Turn = new char[] { 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R' };
        int[] version3Test = new int[] { 64, 1, 46, 28, 25, 53, 27, 63, 37, 7, 42, 19, 50, 23, 8, 16, 30,29,39,41,23,58,26,44,48,17,60,31,43,9,36,59 };
        char[] version3TurnTest = new char[] { 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R' };
        char[] studiedConditionTest = new char[] { 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' };

        StudyDJVlist = new List<DJV>();
        TestDJVlist = new List<DJV>();

        PopulateStudyList(version3, version3Turn, StudyDJVlist);
        PopulateTestList(version3Test, version3TurnTest, studiedConditionTest, TestDJVlist);
    }


    void InitializeVersion4_Block1()
    {
        int[] version4 = new int[] { 47, 12, 49, 10, 62, 52, 20, 5, 3, 13, 61, 15, 33, 2, 32, 11 }; //right then left
        char[] version4Turn = new char[] { 'R','R','R','R', 'R','R', 'R','R','L','L','L','L','L','L','L','L' }; //right then left

        int[] version4Test = new int[] { 47, 12, 49, 10, 62, 52, 20, 5, 3, 13, 61, 15, 33, 2, 32, 11, 4, 57, 21, 35, 40, 55, 14, 54, 56, 38, 22, 34, 51, 6, 45, 18 }; //right then left
        char[] version4TurnTest = new char[] { 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L' }; //right then left
        char[] studiedConditionTest = new char[] { 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N', 'N' };

        StudyDJVlist = new List<DJV>();
        TestDJVlist = new List<DJV>();


        PopulateStudyList(version4, version4Turn, StudyDJVlist);
        PopulateTestList(version4Test, version4TurnTest, studiedConditionTest, TestDJVlist);
    }

    void InitializeVersion4_Block2()
    {
        int[] version4 = new int[] { 64, 1, 46, 28, 25, 53, 27, 63, 37, 7, 42, 19, 50, 23, 8, 16 }; //right then left
        char[] version4Turn = new char[] { 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L' }; //right then left

        int[] version4Test = new int[] { 64, 1, 46, 28, 25, 53, 27, 63, 37, 7, 42, 19, 50, 23, 8, 16, 30, 29, 39, 41, 23, 58, 26, 44, 48, 17, 60, 31, 43, 9, 36, 59 }; //right then left
        char[] version4TurnTest = new char[] { 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'R', 'L', 'L', 'L', 'L', 'L', 'L', 'L', 'L' }; //right then left
        char[] studiedConditionTest = new char[] { 'Y', 'Y', 'Y', 'Y','Y','Y','Y','Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'Y', 'N','N','N','N','N','N','N','N','N','N','N','N','N','N','N','N'};

        StudyDJVlist = new List<DJV>();
        TestDJVlist = new List<DJV>();

        PopulateStudyList(version4, version4Turn, StudyDJVlist);
        PopulateTestList(version4Test, version4TurnTest, studiedConditionTest, TestDJVlist);
    }
    
    void InitializeVersion5_Block1()
    {
        int[] version4 = new int[] { 64, 1, 46 }; //right then left
        char[] version4Turn = new char[] { 'R', 'R', 'R'}; //right then left

        int[] version4Test = new int[] { 64, 1, 46 }; //right then left
        char[] version4TurnTest = new char[] { 'R', 'R', 'R' }; //right then left
        char[] studiedConditionTest = new char[] { 'Y', 'Y', 'Y' };

        StudyDJVlist = new List<DJV>();
        TestDJVlist = new List<DJV>();

        PopulateStudyList(version4, version4Turn, StudyDJVlist);
        PopulateTestList(version4Test, version4TurnTest, studiedConditionTest, TestDJVlist);
    }




    void Shuffle(List<DJV> t)
    {
        int n = t.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n);
            DJV value = t[k];
            t[k] = t[n];
            t[n] = value;
        }

    }

    void PopulateStudyList(int[] version, char[] turn, List<DJV> djv)
    {
        for (int i = 0; i < version.Length; i++)  // populate the study list
        {
            if (turn[i] == 'L') //left turn
            {
                temp = version[i] - 1;
                element = new DJV(version[i], studyScenesL[temp],  sceneNames[temp], StudySceneNameL[temp], 'L');
                djv.Add(element);
               
            }
            else  //right turn
            {
                temp = version[i] - 1;
                element = new DJV(version[i], studyScenesR[temp], sceneNames[temp], StudySceneNameR[temp], 'R');
                djv.Add(element);
                
            }
        }
        Shuffle(djv);
    }


    void PopulateTestList(int[] version, char[] turn, char[] studied, List<DJV> djv)
    {
        for (int i = 0; i < version.Length; i++)  // populate the study list
        {
            if (turn[i] == 'L') //left turn
            {
                temp = version[i] - 1;
                element = new DJV(version[i], testScenes[temp], 'L', TestSceneNameL[temp],studied[i]);
                djv.Add(element);
            }
            else  //right turn
            {
                temp = version[i] - 1;
                element = new DJV(version[i],testScenes[temp], 'R', TestSceneNameR[temp], studied[i]);
                djv.Add(element);
 
            }

        }
        Shuffle(djv);
    }

}
