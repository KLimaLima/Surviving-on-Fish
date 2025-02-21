using UnityEngine;
using UnityEngine.UI;
public class NewMonoBehaviourScript : MonoBehaviour

{
    public class ExampleScript : MonoBehaviour
    {
        public int score, happiness, NPCwants, AmountGive, timesUnbalance;
        public float last_score;
        //public int happiness;
        //public int NPCwants;
        //public int AmountGive;

        void Start()
        {
            //while (go_to_fishing != true)
            //{ newCustmer;

                if (AmountGive > NPCwants)
                {

                score = score + (NPCwants * 100);
                happiness += 5;
                    timesUnbalance++;
                }

                else if (AmountGive < NPCwants)
                {

                int happinessdiff = NPCwants - AmountGive;
                    score = score + ((AmountGive - (happinessdiff)) *100);
                     happiness = 5 * happinessdiff;
                     timesUnbalance++;
                }

                else if (AmountGive == NPCwants)
                {

                //new = old
                score = score + ((AmountGive * 100) * 2);
                happiness += 10;

                }

                if (timesUnbalance > 2)
            {
                //Total Happiness
                //new     =   old 
                happiness = happiness * 90 / 100 ;
            }

            //}

            last_score = score;
        }




     
    }
}