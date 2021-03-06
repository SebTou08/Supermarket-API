using SuperMarket.API.Domain.Models;

namespace SuperMarket.API.Domain.Services.Communications
{
    public class TagResponse : BaseResponse<Tag>
    {
        public TagResponse(Tag resource) : base(resource)
        {
        }

        public TagResponse(string message) : base(message)
        {
        }
    }
}