//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NetkStaff.AppFiles.DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class DisciplinesTaught
    {
        public int id { get; set; }
        public Nullable<int> Personnel_id { get; set; }
        public string Discipline { get; set; }
    
        public virtual Personnel Personnel { get; set; }
    }
}
