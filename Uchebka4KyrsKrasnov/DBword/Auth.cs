//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uchebka4KyrsKrasnov.DBword
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auth
    {
        public int Id_User { get; set; }
        public int Id_Role { get; set; }
        public string Password { get; set; }
        public string Email_User { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}