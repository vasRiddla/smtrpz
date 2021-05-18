using System;
using System.Collections.Generic;
using ConsoleApp1;
using NUnit.Framework;

namespace ConsoleApp1
{
    [TestFixture]
    public class Lab1_Tests
    {
        [TestCase(typeof(DivideByZeroException), true)]
        [TestCase(typeof(StackOverflowException), true)]
        [TestCase(typeof(OutOfMemoryException), true)]
        [TestCase(typeof(InsufficientMemoryException), true)]
        [TestCase(typeof(InsufficientExecutionStackException), true)]

        [TestCase(typeof(ArgumentOutOfRangeException), false)]
        [TestCase(typeof(NullReferenceException), false)]
        [TestCase(typeof(ArgumentNullException), false)]
        [TestCase(typeof(AccessViolationException), false)]
        [TestCase(typeof(IndexOutOfRangeException), false)]



        [Test]
        public void Count_Exceptions_Counter_Values_Correct()
        {

            List<Type> CriticalExceptions = new List<Type>();

            CriticalExceptions.Add(typeof(DivideByZeroException));
            CriticalExceptions.Add(typeof(StackOverflowException));
            CriticalExceptions.Add(typeof(OutOfMemoryException));
            CriticalExceptions.Add(typeof(InsufficientMemoryException));
            CriticalExceptions.Add(typeof(InsufficientExecutionStackException));


            List<Type> nonCriticalExceptions = new List<Type>();

            nonCriticalExceptions.Add(typeof(ArgumentOutOfRangeException));
            nonCriticalExceptions.Add(typeof(ArgumentNullException));
            nonCriticalExceptions.Add(typeof(NullReferenceException));
            nonCriticalExceptions.Add(typeof(AccessViolationException));
            nonCriticalExceptions.Add(typeof(IndexOutOfRangeException));

            var lab1 = new Lab1();

            for (int i = 0; i < CriticalExceptions.Count; i++) 
            {
                var Exception_ekzemplar = (Exception)Activator.CreateInstance(CriticalExceptions[i]);
                lab1.CountExceptions(Exception_ekzemplar);
            }

            for (int i = 0; i < nonCriticalExceptions.Count; i++)
            {
                var Exception_ekzemplar = (Exception)Activator.CreateInstance(nonCriticalExceptions[i]);
                lab1.CountExceptions(Exception_ekzemplar);
            }

            int CC= lab1.Get_Counter_Critical_EX();
            int NCC= lab1.Get_Counter_NonCritical_EX();
            lab1.ResetCounters();
        }

        [Test]
        public void Check_To_Correct_Critical_EX(Type Type_exception, bool Result_expected)
        {

            var ekzemplar = (Exception)Activator.CreateInstance(Type_exception);
            
            try
            {
                throw ekzemplar;
            }
            catch (Exception EX)
            {

                Assert.AreEqual(Result_expected, new Lab1().IsCritical(EX));
                return;
            }
        }

        [Test]
        public void Count_Exceptions_Init_Counters_Zero()
        {
            
            var lab1 = new Lab1();
            lab1.ResetCounters();
        }
    }
}