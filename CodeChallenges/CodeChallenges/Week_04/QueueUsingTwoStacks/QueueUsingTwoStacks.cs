using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges.Week_04.QueueUsingTwoStacks
{
    public class QueueUsingTwoStacks
    {
        public Stack<int> s1 = null;
        public Stack<int> s2 = null;

        public void Enqueue(int n)
        {
            s1.Push(n);
        }

        public int Dequeue()
        {
            int tempDequeue = -1;
            if (s2.Count == 0)
            {
                while (s1.Count != 0)
                {
                    s2.Push(s1.Pop());
                }
            }
            if (s2.Count != 0)
            {
                tempDequeue = s2.Pop();
            }
            return tempDequeue;
        }
    }
}
