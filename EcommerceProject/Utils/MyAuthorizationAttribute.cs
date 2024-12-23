using System.Data;

namespace EcommerceProject.Utils
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class MyAuthorizationAttribute : Attribute
    {
        public string[] Roles { get; }

        public MyAuthorizationAttribute(params string[] roles)
        {
            Roles = roles ?? Array.Empty<string>();
        }
    }
}
