//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NinjaFactory.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ninja
    {
        public Ninja()
        {
            this.Jobs = new HashSet<Job>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int KillCount { get; set; }
        public string WeaponOfChoice { get; set; }
        public bool IsDeleted { get; set; }
        public int SpecialityId { get; set; }
        public decimal MinimalPersonalPrice { get; set; }
    
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual Speciality Speciality { get; set; }
    }
}
