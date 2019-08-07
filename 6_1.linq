<Query Kind="Program" />

/*
Input: a1, ... , an
Goal: substring with max sum
Subproblem: For i where 0 <= i <= n,
	let S(i) = sum of substring on a1, a2, ..., ai, which includes ai
	S(i) = ai + Max { 0, S(i-1)};
Output: Max S(i)
*/

void Main()
{
  var sequence = new[]{0, 5, 15, -30, 10, -5, 40, 10};
  Console.WriteLine(FindContinuousSubsequenceOfMaxSum(sequence));
}

int FindSumOfContinuousSubsequenceOfMaxSum(int[] a)
{
	if (a.Length == 0) return 0;
	var s = new int[a.Length]; 
	s[0] = a[0];

	for (int i = 1; i < a.Length; ++i)
  	{	
		var maxSum = a[i] + Math.Max(0, s[i-1]);
  		s[i] = maxSum;
  	}
	
	return s.Max();
}

IEnumerable<int> FindContinuousSubsequenceOfMaxSum(int[] a)
{
	if (a.Length == 0) return new int[0];
	var s = new int[a.Length];
	s[0] = a[0];
  
	for (int i = 1; i < a.Length; ++i)
  	{	
		var maxSum = a[i] + Math.Max(0, s[i-1]);
  		s[i] = maxSum;
  	}
	var totalMaxSum = s.Max();
	
	int startIndex = 0;
	int length = 0;
	int count = 0;
	for (int i = a.Length - 1; i > 0; --i)
	{
	  if (length == 0 && s[i] == totalMaxSum || length > 0)
	  {
		++length;
		count += a[i];
	  }
	  
	  if (count == totalMaxSum)
	  {
	  	startIndex = i;
		break;
	  }
	  
	}
	
	return a.Skip(startIndex).Take(length);
}