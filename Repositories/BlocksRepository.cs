using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using lego.Models;

namespace lego.Repositories
{
  public class BlocksRepository
  {
    private readonly IDbConnection _db;

    public BlocksRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Block> GetAll()
    {
      string sql = "SELECT * FROM blocks";
      return _db.Query<Block>(sql);
    }

    internal Block Create(Block newBlock)
    {
      string sql = @"
      INSERT INTO blocks
      (Color, Shape, Size)
      VALUES
      (@Color, @Shape, @Size);
      SELECT LAST_INSERT_ID()";
      newBlock.Id = _db.ExecuteScalar<int>(sql, newBlock);
      return newBlock;
    }

    internal Block GetById(int id)
    {
      string sql = "SELECT * FROM blocks WHERE id = @Id";
      return _db.QueryFirstOrDefault<Block>(sql, new { id });
    }

    internal bool Delete(int id)
    {
      string sql = "DELETE FROM blocks WHERE id = @Id LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id });
      return affectedRows == 1;
    }
  }
}