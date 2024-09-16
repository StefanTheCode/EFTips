using BenchmarkDotNet.Running;
using Microsoft.EntityFrameworkCore;

namespace EFTips;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<Benchmarks>();
    }
}