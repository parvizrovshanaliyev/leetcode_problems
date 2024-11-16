// See https://aka.ms/new-console-template for more information

using LeetCode.Problems.Problems.Easy;
using LeetCode.Problems.Problems.Medium;

Console.WriteLine("Hello, World! - leetcode problems");

// two sum

TwoSum.SolutionOne(new[] { 2, 7, 11, 15 }, 9);

TwoSum.SolutionTwo(new[] { 2, 7, 11, 15 }, 9);


// add two numbers

var l1 = new AddTwoNumbers.ListNode(2, new AddTwoNumbers.ListNode(4, new AddTwoNumbers.ListNode(3)));

var l2 = new AddTwoNumbers.ListNode(5, new AddTwoNumbers.ListNode(6, new AddTwoNumbers.ListNode(4)));

var result = AddTwoNumbers.AddTwoNumbersSolutionOne(l1, l2);



Console.ReadKey();