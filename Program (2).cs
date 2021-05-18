using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    
    public class Lab1
    {
        private int Counter_CriticalExceptions { get; set; }

        private int Counter_NonCriticalExceptions { get; set; }

        public void ResetCounters()
        {
            Counter_CriticalExceptions = 0;
            Counter_NonCriticalExceptions = 0;
        }

        public int Get_Counter_Critical_EX() 
        {
            return Counter_CriticalExceptions; 
        }

        public int Get_Counter_NonCritical_EX() 
        { 
            return Counter_NonCriticalExceptions;
        }

        public bool IsCritical(Exception exception)
        {
             List<Type> CriticalException = new List<Type>()
             {
                typeof(DivideByZeroException),
                typeof(OutOfMemoryException),
                typeof(StackOverflowException),
                typeof(InsufficientMemoryException), // Недостатньо памяті
                typeof(InsufficientExecutionStackException) // Недостатнє виконання стеку 
             };

            return CriticalException.Contains(exception.GetType());
        }

        public void CountExceptions(Exception exception)
        {
            if (IsCritical(exception))
            {
                Counter_CriticalExceptions += 1;
            }
            else
            {
                Counter_NonCriticalExceptions += 1;
            }
        }

       
    }
}
