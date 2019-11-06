using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJETO.Models
{
    [Table("usuario_tbl")]
    public partial class UsuarioTbl
    {
        public UsuarioTbl()
        {
            EventoTblCriadorUsuario = new HashSet<EventoTbl>();
            EventoTblResponsavelUsuario = new HashSet<EventoTbl>();
        }

        [Key]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }
        
        [Column("usuario_nome")]
        [Required]
        [StringLength(50)]
        public string UsuarioNome { get; set; }
        
        [Column("usuario_email")]
        [Required]
        [StringLength(100)]
        public string UsuarioEmail { get; set; }
        
        // [Column("usuario_rg")]
        // [StringLength(100)]
        // public string UsuarioRg { get; set; }
        
        [Column("usuario_comunidade")]
        [StringLength(100)]
        public string UsuarioComunidade { get; set; }
        
        [Column("usuario_senha")]
        [Required]
        [StringLength(255)]
        public string UsuarioSenha { get; set; }
        
        [Column("usuario_tipo_id")]
        [Required]
        public int? UsuarioTipoId { get; set; }

        [Column("usuario_imagem")]
        [StringLength(250)]
        public string UsuarioImagem{ get; set; }

        [ForeignKey(nameof(UsuarioTipoId))]
        [InverseProperty(nameof(UsuarioTipoTbl.UsuarioTbl))]
        public virtual UsuarioTipoTbl UsuarioTipo { get; set; }
        
        [InverseProperty(nameof(EventoTbl.CriadorUsuario))]
        public virtual ICollection<EventoTbl> EventoTblCriadorUsuario { get; set; }
        
        [InverseProperty(nameof(EventoTbl.ResponsavelUsuario))]
        public virtual ICollection<EventoTbl> EventoTblResponsavelUsuario { get; set; }
    }
}
