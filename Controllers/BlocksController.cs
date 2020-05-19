using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lego.Models;
using lego.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace lego.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BlocksController : ControllerBase
  {
    private readonly BlocksService _bs;

    public BlocksController(BlocksService bs)
    {
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Block>> GetAll()
    {
      try
      {
        return Ok(_bs.GetAll());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Block> GetById(int id)
    {
      try
      {
        return Ok(_bs.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Block> Create([FromBody] Block newBlock)
    {
      try
      {
        return Ok(_bs.Create(newBlock));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Block> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}