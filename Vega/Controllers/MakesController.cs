using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;

namespace Vega.Controllers
{
    [Produces("application/json")]
    [Route("api/makes")]
    public class MakesController : Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        public MakesController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet()]
        public IEnumerable<MakeDto> GetMakes()
        {
            var makes = _context.Makes.ProjectTo<MakeDto>().ToList();
            return makes;
        }

        [HttpGet("{id}")]
        public JsonResult GetMakeById([FromRoute]int id)
        {
            var make = _context.Makes.ProjectTo<MakeDto>().FirstOrDefault(x => x.MakeId == id);
            return Json(make);
        }
    }
}