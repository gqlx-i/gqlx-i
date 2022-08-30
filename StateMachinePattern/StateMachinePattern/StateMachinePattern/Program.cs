using System.Threading;

namespace StateMachinePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            StateMachine sm = new StateMachine();
            StateA s = new StateA(sm);
            sm.Current = s;
            while(true)
            {
                sm.Execute();
                Thread.Sleep(1000);
            }
        }
    }
}
