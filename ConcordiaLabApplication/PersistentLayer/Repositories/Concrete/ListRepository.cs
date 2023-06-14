﻿using Microsoft.EntityFrameworkCore;

using PersistentLayer.Configurations;
using PersistentLayer.Models;
using PersistentLayer.Repositories.Abstract;

namespace PersistentLayer.Repositories.Concrete;

public class ListRepository : IListRepository
{
    private readonly ConcordiaDbContext _dbContext;

    public ListRepository(ConcordiaDbContext dbContext)
        => _dbContext = dbContext;

    public IEnumerable<Column> GetAll()
    {
        var allLists = _dbContext.EntityLists
            .Include(l => l.Experiments!)
                .ThenInclude(e => e.Scientists!)
            .Include(l => l.Experiments!)
                .ThenInclude(l => l.Comments)
            .Include(l => l.Experiments!)
                .ThenInclude(e => e.Label).AsEnumerable();
        return allLists;
    }

    public IEnumerable<Column> GetByScientistId(int scientistId)
    {
        return _dbContext.EntityLists.AsNoTracking()
            .Include(l => l.Experiments!)
                .ThenInclude(e => e.Scientists!)
            .Include(l => l.Experiments!)
                .ThenInclude(l => l.Comments)
            .Include(l => l.Experiments!)
                .ThenInclude(e => e.Label)
            .Where(l => l.Experiments!.Any(e => e.Scientists!.Select(s => s.Id).Contains(scientistId))).AsEnumerable();
    }
}