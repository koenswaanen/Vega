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
    [Route("api/features")]
    public class FeaturesController : Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(VegaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<FeatureDto> GetFeatures()
        {
            var features = _context.Features.ProjectTo<FeatureDto>().ToList();
            return features;
        }
    }
}