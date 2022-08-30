using System;

namespace StateMachinePattern
{
    public interface IState
    {
        void Execute();
    }

    public class StateA : IState
    {
        private StateMachine _sm;

        public StateA(StateMachine sm)
        {
            _sm = sm;
        }

        public void Execute()
        {
            Console.WriteLine("State A");
            _sm.Current = new StateB(_sm);
        }
    }

    public class StateB : IState
    {
        private StateMachine _sm;

        public StateB(StateMachine sm)
        {
            _sm = sm;
        }

        public void Execute()
        {
            Console.WriteLine("State B");
            _sm.Current = new StateA(_sm);
        }
    }

    public class StateMachine
    {
        public IState Current { get; set; }

        public void Execute()
        {
            Current.Execute();
        }
    }
}
