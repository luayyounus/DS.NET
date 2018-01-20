using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonPractice
{
    class AddTwoNumbers
    {
        //public static void Main(string[] args)
        //{
        //    //Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)

        //    ListNode L1 = new ListNode(2) {next = new ListNode(4) {next = new ListNode(3)}};

        //    ListNode L2 = new ListNode(5) {next = new ListNode(6) {next = new ListNode(4)}};

        //    ListNode result = nAddTwoNumbers(L1, L2);
        //}
        //Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static ListNode nAddTwoNumbers(ListNode l1, ListNode l2)
        {
            string num1 = "";
            string num2 = "";

            while (l1 != null)
            {
                num1 = l1.val.ToString() + num1;
                l1 = l1.next;
            }

            while (l2 != null)
            {
                num2 = l2.val.ToString() + num2;
                l2 = l2.next;
            }

            int sum = int.Parse(num1) + int.Parse(num2);
            int firstNum = sum % 10;

            sum = sum / 10;

            ListNode head = new ListNode(firstNum);
            ListNode temp = head;
            while (sum != 0)
            {
                ListNode newNode = new ListNode(sum % 10);
                temp.next = newNode;
                temp = temp.next;
                sum = sum / 10;
            }

            return head;
        }
    }
    
}
