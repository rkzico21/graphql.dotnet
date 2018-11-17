namespace GraphqlApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using GraphQL;
    using GraphQL.Types;
    using GraphqlApi.DbContexts;
    using GraphqlApi.Queries;
    using Microsoft.AspNetCore.Mvc;

    [Route("/api/graphql")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly StudentDbContext db;

        public GraphQLController(StudentDbContext db)
        {
            this.db = db;
        }
        

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema()
            {
                Query = new StudentQuery(db)
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            if(result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
       
    }
}
