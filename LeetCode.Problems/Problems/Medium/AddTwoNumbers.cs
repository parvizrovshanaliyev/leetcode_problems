namespace LeetCode.Problems.Problems.Medium;


/// <summary>
/// You are given two non-empty linked lists representing two non-negative integers.
/// The digits are stored in reverse order, and each of their nodes contains a single digit.
/// Add the two numbers and return the sum as a linked list.
/// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
/// </summary>
public class AddTwoNumbers
{
    
    // Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }

        public override string ToString()
        {
            return $"{val} -> {next}";
        }
    }
    
    public static ListNode AddTwoNumbersSolutionOne(ListNode l1, ListNode l2)
    {
        var result = new ListNode();
        var current = result;
        var carry = 0;
        
        while (l1 != null || l2 != null)
        {
            var x = l1?.val ?? 0;
            var y = l2?.val ?? 0;
            var sum = x + y + carry;
            carry = sum / 10;
            current.next = new ListNode(sum % 10);
            current = current.next;
            l1 = l1?.next;
            l2 = l2?.next;
        }

        if (carry > 0)
        {
            current.next = new ListNode(carry);
        }

        return result.next;
    }
    
    public ListNode AddTwoNumbersSolutionTwo(ListNode l1, ListNode l2)
    {
        var result = new ListNode();
        var current = result;
        var carry = 0;
        
        while (l1 != null || l2 != null)
        {
            var x = l1?.val ?? 0;
            var y = l2?.val ?? 0;
            var sum = x + y + carry;
            carry = sum / 10;
            current.next = new ListNode(sum % 10);
            current = current.next;
            l1 = l1?.next;
            l2 = l2?.next;
        }

        if (carry > 0)
        {
            current.next = new ListNode(carry);
        }

        return result.next;
    }
    
    
}