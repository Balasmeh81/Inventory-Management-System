using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    [AutoMap(typeof(IdentityRole))]
    public class RoleModel
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}