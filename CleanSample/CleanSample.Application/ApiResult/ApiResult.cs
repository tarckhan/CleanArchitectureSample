using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSample.Application.ApiResult
{
    public class ApiResult<TResponse> 
    {
        public TResponse Output { get; set; } = default(TResponse);
        public List<Error> ErrorList { get; set; } = new List<Error>();
        public bool IsSuccess => !ErrorList.Any();

        public static ApiResult<TResponse> OK(TResponse output)
        {
            return new ApiResult<TResponse>()
            {
                Output = output
            };
        }
        public static ApiResult<TResponse> ERROR(List<Error> errors)
        {
            return new ApiResult<TResponse>()
            {
                ErrorList = errors
            };
        }
    }
}
