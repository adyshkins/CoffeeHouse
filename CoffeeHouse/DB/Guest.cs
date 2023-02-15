//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeHouse.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Guest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Guest()
        {
            this.Check = new HashSet<Check>();
        }
    
        public int IDGuest { get; set; }
        public string Name { get; set; } //
        public string Phone { get; set; } //
        public int IDGender { get; set; } //
        public Nullable<System.DateTime> Birthday { get; set; } //
        public string Email { get; set; } //
        public string DiscountCode { get; set; }
        public int IDLevelDiscount { get; set; }
        public decimal Score { get; set; }
        public string Login { get; set; } //
        public string Password { get; set; } //
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Check> Check { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual LevelDiscount LevelDiscount { get; set; }
    }
}
