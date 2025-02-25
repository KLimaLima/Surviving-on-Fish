using UnityEngine;
using UnityEngine.UI;
public class ScoringSystem : MonoBehaviour

{
        public int score_progress;
        public int happiness;
        public int timesUnbalance;
        public int final_score;
        public int final_happiness;

    //public int happiness;
    //public int NPCwants;
    //public int AmountGive;


    public void CalculateScore()

        {
            //player give too much fish
            if (GameData.Instance.amountGive > GameData.Instance.amountFishNeed)

            {
                score_progress = score_progress + (GameData.Instance.amountFishNeed * 100);
                happiness += 5;
                timesUnbalance++;
            }

            //player give less fish
            else if (GameData.Instance.amountGive < GameData.Instance.amountFishNeed)
            {

                int happinessdiff = GameData.Instance.amountFishNeed - GameData.Instance.amountGive;
                score_progress = score_progress + ((GameData.Instance.amountGive - (happinessdiff)) * 100);
                happiness = 5 * happinessdiff;
                timesUnbalance++;
            }

            //player give exaclty amount of fish
            else if (GameData.Instance.amountGive == GameData.Instance.amountFishNeed)
            {

                // new         =          old
                score_progress = score_progress + ((GameData.Instance.amountGive * 100) * 2);
                happiness += 10;

            }

            if (timesUnbalance > 2)

            {

                //Total Happiness
                //new     =   old 
                happiness = happiness * 90 / 100;

            }
            final_score = score_progress;
            final_happiness = happiness;
        }

        void Update()
        {

            GameData.Instance.last_score = final_score;
            GameData.Instance.new_happiness = final_happiness;
        }
    }

