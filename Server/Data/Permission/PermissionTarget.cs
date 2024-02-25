namespace Server.Data.Permission
{
    /// <summary>
    /// Enum defining the target of a <see cref="PermissionAction"/>
    /// </summary>
    public enum PermissionTarget
    {
        Category = 0,
        News = 1,
        User = 2,
        Role = 3,
        Permission = 4,
        Account = 5
    }
}
