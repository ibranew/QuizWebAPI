using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizWebAPI.Application.Features.Base
{
    public abstract class BaseResponse
    {
        public bool Succeed { get; set; }
        public string ResponseMessage { get; set; } = string.Empty;
    }
}
