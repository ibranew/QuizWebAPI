using QuizWebAPI.Application.Enums;

namespace QuizWebAPI.Application.CustomAttributes
{
    public class AuthorizeDefinitionAttribute : Attribute
    {
        public string Menu { get; set; } = string.Empty;
        public string Definition { get; set; } = string.Empty;
        public RequestActionType ActionType { get; set; }
    }
}
