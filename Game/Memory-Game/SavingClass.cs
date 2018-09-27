using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;





namespace Memory_Game
{
    /// <summary>
    /// Deze class regeld het opslaan van de variable in het memory spel.
    /// Het gaat hier over de leaderboards en de speler specefieke variable zoals de scores en currency
    /// </summary>
    public class SavingClass
    {/// <summary>
    /// het pad waar de .sav bestanden opgeslagen worden
    /// </summary>
        public static string path = @"C:\TestDIR\";
        /// <summary>
        /// De speler naam
        /// </summary>
        public static string varplayername;
        /// <summary>
        /// De currency van de speler
        /// </summary>
        public static int varCurrency;
        /// <summary>
        /// De cardback die door de speler gebruikt wordt
        /// </summary>
        public static string varCardBack;
        /// <summary>
        /// Welke gamemode de speler gebruikt
        /// </summary>
        public static string varHardmode;
        /// <summary>
        /// variable voor het opslaan van de locaties in het spel(niet gebruikt)
        /// </summary>       
        public static string varpoint;
        /// <summary>
        /// Variable voor het kopen van OW cardback
        /// </summary>
        public static string varOWbought;
        /// <summary>
        /// Variable voor de eerste achievement
        /// </summary>
        public static string varAchievement1Have;
        /// <summary>
        /// Variable voor de tweede achievement
        /// </summary>
        public static string varAchievement2Have;
        /// <summary>
        /// Variable voor de derde achievement
        /// </summary>
        public static string varAchievement3Have;
        /// <summary>
        /// Variable voor de reward wanneer alle achievemts gehaald zijn.
        /// </summary>
        public static string varRewardsClaimed;
        /// <summary>
        /// De 10 scores van de normale leaderboard
        /// </summary>
        public static string varScore1,varScore2,varScore3,varScore4,varScore5,varScore6,varScore7,varScore8, varScore9,varScore10;
        /// <summary>
        /// De nieuwe naam en score
        /// </summary>
        public static string varNewname, varNewScore;
        /// <summary>
        /// De 10 scores van de hard leaderboard
        /// </summary>
        public static string varScore1Hard, varScore2Hard, varScore3Hard, varScore4Hard, varScore5Hard, varScore6Hard, varScore7Hard, varScore8Hard, varScore9Hard, varScore10Hard;
        /// <summary>
        /// De nieuwe hard naam en score
        /// </summary>
        public static string varNewnameHard, varNewScoreHard;
        /// <summary>
        /// De nieuwe mp naam en score
        /// </summary>
        public static string varNewScoreMP, varScore1MP, varScore2MP, varScore3MP, varScore4MP, varScore5MP, varScore6MP, varScore7MP, varScore8MP, varScore9MP, varScore10MP;
        /// <summary>
        /// De method die wordt gebruikt voor het bijwerken van de .sav bestanden die speler specefiek zijn.
        /// </summary>
        public static void savedata()
        {
            if (File.Exists(path + "memory" + varplayername + ".sav")) //controleerd of de save files bestaan, zoniet maakt hij de nodige bestanden aan.
            {
                string currency = Convert.ToString(varCurrency);

                string[] Lines = new string[11];
                Lines[0] = "";
                Lines[1] = currency;
                Lines[2] = varCardBack;
                Lines[3] = varHardmode;
                Lines[4] = "";
                Lines[5] = varpoint;
                Lines[6] = varOWbought;
                Lines[7] = varAchievement1Have;
                Lines[8] = varAchievement2Have;
                Lines[9] = varAchievement3Have;
                Lines[10] = varRewardsClaimed;
                System.IO.File.WriteAllLines(path + "memory" + SavingClass.varplayername + ".sav", Lines);
                string[] Name = new string[1];
                Name[0] = varplayername;
                System.IO.File.WriteAllLines(path + "PlayerName.sav", Name);
            }
            else
            {
                if (!File.Exists(path + "memory" + varplayername + ".sav"))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    varCardBack = "D";
                    varCurrency = 0;
                    varHardmode = "false";
                    varOWbought = "false";
                    varAchievement1Have = "false";
                    varAchievement2Have = "false";
                    varAchievement3Have = "false";
                    varRewardsClaimed = "false";
                }

                string[] Lines = new string[11];
                Lines[0] = "";
                Lines[1] = Convert.ToString(varCurrency);
                Lines[2] = varCardBack;
                Lines[3] = varHardmode;
                Lines[4] = "";
                Lines[5] = varpoint;
                Lines[6] = varOWbought;
                Lines[7] = varAchievement1Have;
                Lines[8] = varAchievement2Have;
                Lines[9] = varAchievement3Have;
                Lines[10] = varRewardsClaimed;
                System.IO.File.WriteAllLines(path + "memory" + SavingClass.varplayername + ".sav", Lines);

                string[] Name = new string[1];
                Name[0] = varplayername;
                System.IO.File.WriteAllLines(path + "PlayerName.sav", Name);
                if (!File.Exists(path + "Leaderboard.sav"))
                { 
                    String[] score = new string[12];
                    score[0] = "";
                    score[1] = "";
                    score[2] = "";
                    score[3] = "";
                    score[4] = "";
                    score[5] = "";
                    score[6] = "";
                    score[7] = "";
                    score[8] = "";
                    score[9] = "";
                    score[10] = "";
                    score[11] = "";
                    System.IO.File.WriteAllLines(path + "Leaderboard.sav", score);
                }
                if (!File.Exists(path + "LeaderboardHard.sav"))
                {
                    String[] scoreHard = new string[12];
                    scoreHard[0] = "";
                    scoreHard[1] = "";
                    scoreHard[2] = "";
                    scoreHard[3] = "";
                    scoreHard[4] = "";
                    scoreHard[5] = "";
                    scoreHard[6] = "";
                    scoreHard[7] = "";
                    scoreHard[8] = "";
                    scoreHard[9] = "";
                    scoreHard[10] = "";
                    scoreHard[11] = "";
                    System.IO.File.WriteAllLines(path + "LeaderboardHard.sav", scoreHard);
                }

                String[] scoreMP = new string[12];
                scoreMP[0] = "";
                scoreMP[1] = "";
                scoreMP[2] = "";
                scoreMP[3] = "";
                scoreMP[4] = "";
                scoreMP[5] = "";
                scoreMP[6] = "";
                scoreMP[7] = "";
                scoreMP[8] = "";
                scoreMP[9] = "";
                scoreMP[10] = "";
                scoreMP[11] = "";
                System.IO.File.WriteAllLines(path + "LeaderboardMP.sav", scoreMP);
            }

        }
        /// <summary>
        /// laad het normale leaderboard
        /// </summary>
        public static void LoadLeaderboard()
        {
            if (File.Exists(path + "Leaderboard.sav"))
            {
                string[] Leaderboardname2 = System.IO.File.ReadAllLines(SavingClass.path + "Leaderboard.sav");
                varScore1 = Leaderboardname2[0];
                varScore2 = Leaderboardname2[1];
                varScore3 = Leaderboardname2[2];
                varScore4 = Leaderboardname2[3];
                varScore5 = Leaderboardname2[4];
                varScore6 = Leaderboardname2[5];
                varScore7 = Leaderboardname2[6];
                varScore8 = Leaderboardname2[7];
                varScore9 = Leaderboardname2[8];
                varScore10 = Leaderboardname2[9];
            }

        }
        /// <summary>
        /// slaat de scores op. en sorteert ze 
        /// </summary>
        public static void Saveleaderboard()
        {
          
            
                int[] nameplace = new int[10];

                string[] Leaderboardname2 = System.IO.File.ReadAllLines(SavingClass.path + "Leaderboard.sav");
                int length = Leaderboardname2.Length;
                string[] Leaderboardname3 = new string[length];
                Leaderboardname3[10] = varNewScore;
                Array.Sort(Leaderboardname3);
                int count = 0;
                foreach (string i in Leaderboardname2)
                {
                    Leaderboardname3[count] = Leaderboardname2[count];
                    count++;
                }
                count = 0;
                Leaderboardname3[length - 1] = varNewScore;
                Array.Sort<string>(Leaderboardname3);
                foreach (string i in Leaderboardname3)
                {
                    Leaderboardname2[count] = Convert.ToString(Leaderboardname3[count]);
                    count++;
                }
                System.IO.File.WriteAllLines(path + "Leaderboard.sav", Leaderboardname2.Reverse());


                varScore1 = Leaderboardname2[0];
                varScore2 = Leaderboardname2[1];
                varScore3 = Leaderboardname2[2];
                varScore4 = Leaderboardname2[3];
                varScore5 = Leaderboardname2[4];
                varScore6 = Leaderboardname2[5];
                varScore7 = Leaderboardname2[6];
                varScore8 = Leaderboardname2[7];
                varScore9 = Leaderboardname2[8];
                varScore10 = Leaderboardname2[9];


            
  
        }
        /// <summary>
        /// //laad het hard leaderboard
        /// </summary>
        public static void LoadLeaderboardHard()
                                                
        {
            if (File.Exists(path + "Leaderboard.sav"))
            {
                string[] Leaderboardname2Hard = System.IO.File.ReadAllLines(SavingClass.path + "LeaderboardHard.sav");
                varScore1Hard = Leaderboardname2Hard[0];
                varScore2Hard = Leaderboardname2Hard[1];
                varScore3Hard = Leaderboardname2Hard[2];
                varScore4Hard = Leaderboardname2Hard[3];
                varScore5Hard = Leaderboardname2Hard[4];
                varScore6Hard = Leaderboardname2Hard[5];
                varScore7Hard = Leaderboardname2Hard[6];
                varScore8Hard = Leaderboardname2Hard[7];
                varScore9Hard = Leaderboardname2Hard[8];
                varScore10Hard = Leaderboardname2Hard[9];
            }
            
        }/// <summary>
         /// slaat de scores op. en sorteert ze 
         /// </summary>
        public static void SaveleaderboardHard()
        {
            int[] nameplaceHard = new int[10];

            string[] Leaderboardname2Hard = System.IO.File.ReadAllLines(SavingClass.path + "LeaderboardHard.sav");
            int lengthHard = Leaderboardname2Hard.Length;
            string[] Leaderboardname3Hard = new string[lengthHard];
            Leaderboardname3Hard[10] = varNewScoreHard;
            Array.Sort(Leaderboardname3Hard);
            int count = 0;
            foreach (string i in Leaderboardname2Hard)
            {
                Leaderboardname3Hard[count] = Leaderboardname2Hard[count];
                count++;
            }
            count = 0;
            Leaderboardname3Hard[lengthHard - 1] = varNewScoreHard;
            Array.Sort<string>(Leaderboardname3Hard);
            foreach (string i in Leaderboardname3Hard)
            {
                Leaderboardname2Hard[count] = Convert.ToString(Leaderboardname3Hard[count]);
                count++;
            }
            System.IO.File.WriteAllLines(path + "LeaderboardHard.sav", Leaderboardname2Hard.Reverse());

            varScore1Hard = Leaderboardname2Hard[0];
            varScore2Hard = Leaderboardname2Hard[1];
            varScore3Hard = Leaderboardname2Hard[2];
            varScore4Hard = Leaderboardname2Hard[3];
            varScore5Hard = Leaderboardname2Hard[4];
            varScore6Hard = Leaderboardname2Hard[5];
            varScore7Hard = Leaderboardname2Hard[6];
            varScore8Hard = Leaderboardname2Hard[7];
            varScore9Hard = Leaderboardname2Hard[8];
            varScore10Hard = Leaderboardname2Hard[9];
        }
        /// <summary>
        /// laad het mp leaderboard
        /// </summary>
        public static void LoadLeaderboardMP()
                                              
        {
            if (File.Exists(path + "Leaderboard.sav"))
            {
                string[] LeaderboardnameMP = System.IO.File.ReadAllLines(SavingClass.path + "LeaderboardMP.sav");
                varScore1MP = LeaderboardnameMP[0];
                varScore2MP = LeaderboardnameMP[1];
                varScore3MP = LeaderboardnameMP[2];
                varScore4MP = LeaderboardnameMP[3];
                varScore5MP = LeaderboardnameMP[4];
                varScore6MP = LeaderboardnameMP[5];
                varScore7MP = LeaderboardnameMP[6];
                varScore8MP = LeaderboardnameMP[7];
                varScore9MP = LeaderboardnameMP[8];
                varScore10MP = LeaderboardnameMP[9];
            }
        }
        /// <summary>
        /// slaat de scores op. en sorteert ze 
        /// </summary>
        public static void SaveleaderboardMP()
        {
            int[] nameplaceMP = new int[10];

            string[] Leaderboardname2MP = System.IO.File.ReadAllLines(SavingClass.path + "LeaderboardMP.sav");
            int lengthMP = Leaderboardname2MP.Length;
            string[] Leaderboardname3MP = new string[lengthMP];
            Leaderboardname3MP[10] = varNewScoreMP;
            Array.Sort(Leaderboardname3MP);
            int count = 0;
            foreach (string i in Leaderboardname2MP)
            {
                Leaderboardname3MP[count] = Leaderboardname2MP[count];
                count++;
            }
            count = 0;
            Leaderboardname3MP[lengthMP - 1] = varNewScoreMP;
            Array.Sort<string>(Leaderboardname3MP);
            foreach (string i in Leaderboardname3MP)
            {
                Leaderboardname2MP[count] = Convert.ToString(Leaderboardname3MP[count]);
                count++;
            }
            System.IO.File.WriteAllLines(path + "LeaderboardMP.sav", Leaderboardname2MP.Reverse());

            varScore1MP = Leaderboardname2MP[0];
            varScore2MP = Leaderboardname2MP[1];
            varScore3MP = Leaderboardname2MP[2];
            varScore4MP = Leaderboardname2MP[3];
            varScore5MP = Leaderboardname2MP[4];
            varScore6MP = Leaderboardname2MP[5];
            varScore7MP = Leaderboardname2MP[6];
            varScore8MP = Leaderboardname2MP[7];
            varScore9MP = Leaderboardname2MP[8];
            varScore10MP = Leaderboardname2MP[9];
        }
    }
}
