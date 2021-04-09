using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Colaboradix.API.Attributes
{
    public class CommandProducesResponseTypeAttribute : ProducesResponseTypeAttribute
    {
        public CommandProducesResponseTypeAttribute() : base(StatusCodes.Status204NoContent)
        {
        }
    }
    public class QueryProducesResponseTypeAttribute : ProducesResponseTypeAttribute
    {
        public QueryProducesResponseTypeAttribute() : base(StatusCodes.Status200OK)
        {
        }
    }
}
