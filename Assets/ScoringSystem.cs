using UnityEngine;
using UnityEngine.UI;
public class NewMonoBehaviourScript : MonoBehaviour

{
    public class ExampleScript : MonoBehaviour
    {
        public int score_progress, happiness, NPCwants, AmountGive, timesUnbalance;
        public int final_score,new_happiness;
        //public int happiness;
        //public int NPCwants;
        //public int AmountGive;

        public void Socresystem()

        {
            score_progress = 0;
            //while (go_to_fishing != true)
            //{ newCustmer;

            if (GameData.Instance.amountGive > GameData.Instance.amountFishNeed)
                {

                score_progress = score_progress + (GameData.Instance.amountFishNeed * 100);
                happiness += 5;
                    timesUnbalance++;
                }

                else if (GameData.Instance.amountFish < GameData.Instance.amountFishNeed)
                {

                int happinessdiff = GameData.Instance.amountFishNeed - GameData.Instance.amountGive;
                score_progress = score_progress + ((GameData.Instance.amountGive - (happinessdiff)) *100);
                     happiness = 5 * happinessdiff;
                     timesUnbalance++;
                }

                else if (GameData.Instance.amountFish == GameData.Instance.amountFishNeed)
                {

                // new         =          old
                score_progress = score_progress + ((GameData.Instance.amountGive * 100) * 2);
                happiness += 10;

                }

                if (timesUnbalance > 2)
            {
                //Total Happiness
                //new     =   old 
                happiness = happiness * 90 / 100 ;
            }

            //}

            final_score = score_progress;
            new_happiness = happiness;
            GameData.Instance.last_score = final_score;
            GameData.Instance.new_happiness = new_happiness;
        }




     
    }
}