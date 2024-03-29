﻿namespace InsuranceCore.Models.DTOs.Role
{
    /// <summary>
    /// GET Dto type of <see cref="Role"/>.
    /// </summary>
    public class GetRoleDto : ADto, IRoleDto
    {
        public string Name { get; set; }

        public virtual IEnumerable<int> Users { get; set; }
    }
}
