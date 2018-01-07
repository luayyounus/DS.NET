using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading;

namespace CodeChallenges.NumberIsPrime
{
    class CheckForPrimes
    {
        //Most of these solutions keep iterating through the same multiple unnecessarily(for example, they check 5, 10, and then 15, something that a single % by 5 will test for).
        //A % by 2 will handle all even numbers(all integers ending in 0, 2, 4, 6, or 8).
        //A % by 5 will handle all multiples of 5 (all integers ending in 5).
        //What's left is to test for even divisions by integers ending in 1, 3, 7, or 9. But the beauty is that we can increment by 10 at a time, instead of going up by 2, and I will demonstrate a solution that is threaded out.
        //The other algorithms are not threaded out, so they don't take advantage of your cores as much as I would have hoped.
        //I also needed support for really large primes, so I needed to use the BigInteger data-type instead of int, long, etc.
        public static BigInteger IntegerSquareRoot(BigInteger value)
        {
            if (value > 0)
            {
                int bitLength = value.ToByteArray().Length * 8;
                BigInteger root = BigInteger.One << (bitLength / 2);
                while (!IsSquareRoot(value, root))
                {
                    root += value / root;
                    root /= 2;
                }
                return root;
            }
            else return 0;
        }

        private static Boolean IsSquareRoot(BigInteger n, BigInteger root)
        {
            BigInteger lowerBound = root * root;
            BigInteger upperBound = (root + 1) * (root + 1);
            return (n >= lowerBound && n < upperBound);
        }

        static bool IsPrime(BigInteger value)
        {
            Console.WriteLine("Checking if {0} is a prime number.", value);
            if (value < 3)
            {
                if (value == 2)
                {
                    Console.WriteLine("{0} is a prime number.", value);
                    return true;
                }
                else
                {
                    Console.WriteLine("{0} is not a prime number because it is below 2.", value);
                    return false;
                }
            }
            else
            {
                if (value % 2 == 0)
                {
                    Console.WriteLine("{0} is not a prime number because it is divisible by 2.", value);
                    return false;
                }
                else if (value == 5)
                {
                    Console.WriteLine("{0} is a prime number.", value);
                    return true;
                }
                else if (value % 5 == 0)
                {
                    Console.WriteLine("{0} is not a prime number because it is divisible by 5.", value);
                    return false;
                }
                else
                {
                    // The only way this number is a prime number at this point is if it is divisible by numbers ending with 1, 3, 7, and 9.
                    AutoResetEvent success = new AutoResetEvent(false);
                    AutoResetEvent failure = new AutoResetEvent(false);
                    AutoResetEvent onesSucceeded = new AutoResetEvent(false);
                    AutoResetEvent threesSucceeded = new AutoResetEvent(false);
                    AutoResetEvent sevensSucceeded = new AutoResetEvent(false);
                    AutoResetEvent ninesSucceeded = new AutoResetEvent(false);
                    BigInteger squareRootedValue = IntegerSquareRoot(value);
                    Thread ones = new Thread(() =>
                    {
                        for (BigInteger i = 11; i <= squareRootedValue; i += 10)
                        {
                            if (value % i == 0)
                            {
                                Console.WriteLine("{0} is not a prime number because it is divisible by {1}.", value, i);
                                failure.Set();
                            }
                        }
                        onesSucceeded.Set();
                    });
                    ones.Start();
                    Thread threes = new Thread(() =>
                    {
                        for (BigInteger i = 3; i <= squareRootedValue; i += 10)
                        {
                            if (value % i == 0)
                            {
                                Console.WriteLine("{0} is not a prime number because it is divisible by {1}.", value, i);
                                failure.Set();
                            }
                        }
                        threesSucceeded.Set();
                    });
                    threes.Start();
                    Thread sevens = new Thread(() =>
                    {
                        for (BigInteger i = 7; i <= squareRootedValue; i += 10)
                        {
                            if (value % i == 0)
                            {
                                Console.WriteLine("{0} is not a prime number because it is divisible by {1}.", value, i);
                                failure.Set();
                            }
                        }
                        sevensSucceeded.Set();
                    });
                    sevens.Start();
                    Thread nines = new Thread(() =>
                    {
                        for (BigInteger i = 9; i <= squareRootedValue; i += 10)
                        {
                            if (value % i == 0)
                            {
                                Console.WriteLine("{0} is not a prime number because it is divisible by {1}.", value, i);
                                failure.Set();
                            }
                        }
                        ninesSucceeded.Set();
                    });
                    nines.Start();
                    Thread successWaiter = new Thread(() =>
                    {
                        AutoResetEvent.WaitAll(new WaitHandle[] { onesSucceeded, threesSucceeded, sevensSucceeded, ninesSucceeded });
                        success.Set();
                    });
                    successWaiter.Start();
                    int result = AutoResetEvent.WaitAny(new WaitHandle[] { success, failure });
                    try
                    {
                        successWaiter.Abort();
                    }
                    catch { }
                    try
                    {
                        ones.Abort();
                    }
                    catch { }
                    try
                    {
                        threes.Abort();
                    }
                    catch { }
                    try
                    {
                        sevens.Abort();
                    }
                    catch { }
                    try
                    {
                        nines.Abort();
                    }
                    catch { }
                    if (result == 1)
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("{0} is a prime number.", value);
                        return true;
                    }
                }
            }
        }
    }
}
