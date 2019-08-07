<Query Kind="Program" />

/*
Input: a1 < a2 <  ... < an
Goal: find hotels to stay at that minimize penalty
Subproblem: For 0 < i < n
	let P(i) = minumum penalty if staying at ai
	P(0) = 0;
	P(i) =  min { P(j) + (200 - (ai - aj))^2): j < i & i - j <=200 }

Output: 
  Sequence of hotels stayed out with smallest penalty
*/

void Main()
{
	var hotels1 = new []{ 0, 150, 300, 450}; // 7500
	var hotels2 = new []{ 0, 200, 250, 400, 450, 600 }; //0
	var hotels3 = new []{ 0, 190, 195, 199, 200, 400 }; //0
	var hotels4 = new []{ 0, 100, 175, 210, 400}; // 18200
	Console.WriteLine(CalculatePenalty(hotels4));
}

int CalculatePenalty(int[] h)
{
	if (h.Length == 0) return 0;
	var p = new int[h.Length];
	p[0] = h[0];
	
	for (int i = 1; i < h.Length; ++i)
	{
		int bestj = 0;
		int bestp = int.MaxValue;
		for (int j = 0; j < i; ++j)
		{
			if (CanTravelInADay(h[j], h[i]))
			{
				var pi = p[j] + CalculatePenalty(h[j], h[i]);
				if (pi < bestp)
				{
					bestj = j;
					bestp = pi;
				}
			}
		}
		p[i] = bestp;
	}
	return p.Last();
}

bool CanTravelInADay(int start, int finish)
{
	return finish - start <= 200;
}

int CalculatePenalty(int start, int finish)
{
	int distance = finish - start;
	if (distance > 200) throw new Exception($"Cannot travel more than 200 miles in a day.\n Attempted distance: {distance}");
	return (int) Math.Pow((200 - distance),2);
}