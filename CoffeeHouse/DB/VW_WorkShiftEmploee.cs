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
    
    public partial class VW_WorkShiftEmploee
    {
        public string ФИО { get; set; }
        public string Персональный_код { get; set; }
        public System.DateTime Начало_смены { get; set; }
        public System.DateTime Конец_смены { get; set; }
        public Nullable<int> Количество_часов { get; set; }
    }
}
