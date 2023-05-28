using System;
namespace UnitTests.Tests
{
	public static class DumbFuncTests
	{
		// Naming Convention - ClassName_MethodName_ExpectedResult
		public static void DumbFunc_ReturnsPikachuIfZero_ReturnsString()
		{
			try
			{
				//Arraange - Go Get your variables, whatever you need, classes, functions etc.
				int num = 0;
                DumbFunc dumbFunc = new DumbFunc();

				//Act - Execute the function
				string result = dumbFunc.ReturnsPikachuIfZero(num);

                //Assert - whatever is returned is it what you want ?
				if(result == "PIKACHU")
				{
					Console.WriteLine("PASSED: DumbFunc_ReturnsPikachuIfZero_ReturnsString");
				}
				else
				{
					Console.WriteLine("FAILED: DumbFunc_ReturnsPikachuIfZero_ReturnsString");
				}

            }
			catch (Exception ex)
			{
				Console.WriteLine(ex);

			}
		}
    }
}

