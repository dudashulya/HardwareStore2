//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HardwareStore2.Base
{
    using System;
    using System.Collections.Generic;
    
    public partial class Backet_Product
    {
        public int Id { get; set; }
        public Nullable<int> BacketId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> Count { get; set; }
        public Nullable<decimal> LastCost { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Backet Backet { get; set; }
    }
}