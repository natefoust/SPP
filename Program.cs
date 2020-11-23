using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Sum sum = new Sum();
            Umn umn = new Umn();
            MultiPult mPult = new MultiPult();
            mPult.SetCommand(new SumOnCommand(sum));

            //сложение
            mPult.PressButton(0);
            //умножение
            mPult.PressButton(1);
            mPult.PressButton(2);
            mPult.SetCommand(new UmnOnCommand(umn));
            mPult.PressButton(2);

            Console.Read();
        }
    }
    interface ICommand
    {
        void Execute();
    }


    class Sum
    {
        public void On()
        {
            Console.WriteLine("Сложение!");
        }
    }

    class SumOnCommand : ICommand
    {
        Sum sum;
        public SumOnCommand(Sum SumSet)
        {
            sum = SumSet;
        }
        public void Execute()
        {
            sum.On();
        }
    }
    

    class Umn
    {
        public void On()
        {
            Console.WriteLine("Умножение!");
        }
    }

    class UmnOnCommand : ICommand
    {
        Umn umn;
        public UmnOnCommand(Umn UmnSet)
        {
            umn = UmnSet;
        }
        public void Execute()
        {
            umn.On();
        }
    }

    class NoCommand : ICommand
    {
        public void Execute()
        {
        }
    }

    class MultiPult
    {
        ICommand[] buttons;
        Stack<ICommand> commandsHistory;

        Sum sum = new Sum();
        Umn umn = new Umn();
        public MultiPult()
        {
            buttons = new ICommand[3];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new NoCommand();
            }
            commandsHistory = new Stack<ICommand>();
            SetStaticCommand(0, new UmnOnCommand(umn));
            SetStaticCommand(1, new SumOnCommand(sum));

        }

        public void SetCommand(ICommand com)
        {
            buttons[2] = com;
        }

        private void SetStaticCommand(int number, ICommand com)
        {
            buttons[number] = com;
        }


        public void PressButton(int number)
        {
            buttons[number].Execute();
            // добавляем выполненную команду в историю команд
            commandsHistory.Push(buttons[number]);
        }
    }
}
