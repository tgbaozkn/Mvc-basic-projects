//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class kaynak
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kaynak()
        {
            this.library = new HashSet<library>();
        }
    
        public int kaynak_id { get; set; }
        [Required(ErrorMessage = "Kitap Ad� Girmelisiniz!")]
        [StringLength(10,ErrorMessage ="10 karakterden fazla giremezsin!")]
        public string kaynak_ad { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<library> library { get; set; }
    }
}
