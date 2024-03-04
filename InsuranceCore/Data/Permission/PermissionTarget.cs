namespace InsuranceCore.Data.Permission
{
    /// <summary>
    /// Enum defining the target of a <see cref="PermissionAction"/>
    /// </summary>
    public enum PermissionTarget
    {
        Category = 0,
        Comment = 1,
        Like = 2,
        Post = 3,
        Tag = 4,
        User = 5,
        Role = 6,
        Permission = 7,
        Account = 8,
        Address = 9,
        City = 10,
        District = 11,
        Policy = 12,
        Product = 13,
        Location = 14,
    }
}
