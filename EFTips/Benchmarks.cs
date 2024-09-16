using BenchmarkDotNet.Attributes;
using Microsoft.EntityFrameworkCore;

namespace EFTips;

[MemoryDiagnoser]
public class Benchmarks
{
    private MyDbContext _context;

    [GlobalSetup]
    public void Setup()
    {
        _context = new MyDbContext();

        DataSeeder.SeedData(_context, 3000);
        _context.Dispose();
    }

    //[Benchmark]
    public void SelectAllColumns()
    {
        using var context = new MyDbContext();
        
        var results = context.MyEntities.ToList();
    }

    //[Benchmark]
    public void SelectImportantColumns()
    {
        using var context = new MyDbContext();
        
        var results = context.MyEntities.Select(e => new { e.Id, e.Name }).ToList();
    }

    //[Benchmark]
    public void SelectWithTracking()
    {
        using var context = new MyDbContext();
        
        var results = context.MyEntities.ToList();
    }

    //[Benchmark]
    public void SelectWithNoTracking()
    {
        using var context = new MyDbContext();
        
        var results = context.MyEntities.AsNoTracking().ToList();
    }

    //[Benchmark]
    public void QueryInsideLoop()
    {
        using var context = new MyDbContext();

        for (int i = 1; i <= 100; i++)
        {
            var entity = context.MyEntities.FirstOrDefault(e => e.Id == i);
        }
    }

    //[Benchmark]
    public void QueryOutsideLoop()
    {
        using var context = new MyDbContext();
        
        var entities = context.MyEntities
        .Where(e => e.Id <= 100)
        .ToList();

        foreach (var entity in entities)
        {
            var id = entity.Id; // Simulating loop logic
        }
    }

    //[Benchmark]
    public void DefaultSingleQuery()
    {
        using var context = new MyDbContext();
        
        var results = context.MyEntities
        .Include(e => e.RelatedEntities)
        .ToList();
    }

    //[Benchmark]
    public void UsingSplitQuery()
    {
        using var context = new MyDbContext();
        
        var results = context.MyEntities
        .Include(e => e.RelatedEntities)
        .AsSplitQuery()
        .ToList();
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        _context.Dispose();
    }
}