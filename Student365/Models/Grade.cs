//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Student365.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grade
    {
        public string subject { get; set; }
        public short grade1 { get; set; }
        public string username { get; set; }
        public int id { get; set; }
    
        public virtual Subject Subject1 { get; set; }
        public virtual User User { get; set; }
    }
}
