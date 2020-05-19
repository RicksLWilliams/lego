using System;
using System.Collections.Generic;
using lego.Models;
using lego.Repositories;

namespace lego.Services
{
  public class BlocksService
  {
    private readonly BlocksRepository _repo;

    public BlocksService(BlocksRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Block> GetAll()
    {
      return _repo.GetAll();
    }

    internal Block Create(Block newBlock)
    {
      Block createdBlock = _repo.Create(newBlock);
      return createdBlock;
    }

    internal Block GetById(int id)
    {
      Block foundBlock = _repo.GetById(id);
      if (foundBlock == null)
      {
        throw new Exception("Invalid id.");
      }
      return foundBlock;
    }

    internal Block Delete(int id)
    {
      Block foundBlock = GetById(id);
      if (_repo.Delete(id))
      {
        return foundBlock;
      }
      throw new Exception("Something bad happened...");
    }
  }
}