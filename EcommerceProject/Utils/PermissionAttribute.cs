namespace EcommerceProject.Utils
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class PermissionAttribute : Attribute
    {
        public string[] Permissions { get; }

        public PermissionAttribute(params string[] permissions)
        {
            Permissions = permissions;
        }
    }
}
