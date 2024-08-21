using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCodeTrails
{
    internal class EnumCodes
    {
        enum State
        {
            LookingForEnemy,
            MovingToEnemy,
            AttackingEnemy
        }

        enum Stages
        {
            stage1,
            stage2,
            stage3,
            stage4,
        }

        private State currentState;
        private void HandleStates()
        {
                switch (currentState)
                {
                    case State.LookingForEnemy:
                        break;
                    case State.MovingToEnemy:
                        break;
                    case State.AttackingEnemy:
                        break;
                }
        }

        public static void EnumTest()
        {
            Stages currentStage = Stages.stage2; ;
            string stateStr = currentStage.ToString();

            Console.WriteLine(Enum.Parse<Stages>(stateStr));
            Console.WriteLine("----------------------------");

            foreach (Stages stage in Enum.GetValues(typeof(Stages)))
            {
                Console.WriteLine(stage.ToString());
            }
        }
    }
}
