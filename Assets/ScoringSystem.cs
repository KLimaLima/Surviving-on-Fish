using UnityEngine;
using UnityEngine.UI;
public class NewMonoBehaviourScript : MonoBehaviour

{
    public class ExampleScript : MonoBehaviour
    {
        public int score_progress, happiness, NPCwants, AmountGive, timesUnbalance;
        public float last_score,new_happiness;
        //public int happiness;
        //public int NPCwants;
        //public int AmountGive;

        void Start()
        {
            //while (go_to_fishing != true)
            //{ newCustmer;

                if (AmountGive > NPCwants)
                {

                score_progress = score_progress + (NPCwants * 100);
                happiness += 5;
                    timesUnbalance++;
                }

                else if (AmountGive < NPCwants)
                {

                int happinessdiff = NPCwants - AmountGive;
                score_progress = score_progress + ((AmountGive - (happinessdiff)) *100);
                     happiness = 5 * happinessdiff;
                     timesUnbalance++;
                }

                else if (AmountGive == NPCwants)
                {

                //new = old
                score_progress = score_progress + ((AmountGive * 100) * 2);
                happiness += 10;

                }

                if (timesUnbalance > 2)
            {
                //Total Happiness
                //new     =   old 
                happiness = happiness * 90 / 100 ;
            }

            //}

            last_score = score_progress;
            new_happiness = happiness;
            last_score = GameData.Instance.last_score;
            new_happiness = GameData.Instance.new_happiness;
        }




     
    }
}