using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROJETO.Models
{
    [Table("evento_tbl")]
    public partial class EventoTbl
    {
        [Key]
        [Column("evento_id")]
        public int EventoId { get; set; }
        [Column("evento_nome")]
        [StringLength(100)]
        public string EventoNome { get; set; }
        [Column("evento_data", TypeName = "date")]
        public DateTime? EventoData { get; set; }
        [Column("evento_horario_comeco")]
        [StringLength(50)]
        public string EventoHorarioComeco { get; set; }
        [Column("evento_horario_fim")]
        [StringLength(50)]
        public string EventoHorarioFim { get; set; }
        [Column("evento_descricao", TypeName = "text")]
        public string EventoDescricao { get; set; }
        [Column("evento_categoria_id")]
        public int? EventoCategoriaId { get; set; }
        [Column("evento_espaco_id")]
        public int? EventoEspacoId { get; set; }
        [Column("evento_status_id")]
        public int? EventoStatusId { get; set; }
        [Column("criador_usuario_id")]
        public int? CriadorUsuarioId { get; set; }
        [Column("responsavel_usuario_id")]
        public int? ResponsavelUsuarioId { get; set; }

        [Column("evento_imagem")]
        [StringLength(250)]
        public string EventoImagem{ get; set; }

        [ForeignKey(nameof(CriadorUsuarioId))]
        [InverseProperty(nameof(UsuarioTbl.EventoTblCriadorUsuario))]
        public virtual UsuarioTbl CriadorUsuario { get; set; }
        [ForeignKey(nameof(EventoCategoriaId))]
        [InverseProperty(nameof(EventoCategoriaTbl.EventoTbl))]
        public virtual EventoCategoriaTbl EventoCategoria { get; set; }
        [ForeignKey(nameof(EventoEspacoId))]
        [InverseProperty(nameof(EventoEspacoTbl.EventoTbl))]
        public virtual EventoEspacoTbl EventoEspaco { get; set; }
        [ForeignKey(nameof(EventoStatusId))]
        [InverseProperty(nameof(EventoStatusTbl.EventoTbl))]
        public virtual EventoStatusTbl EventoStatus { get; set; }
        [ForeignKey(nameof(ResponsavelUsuarioId))]
        [InverseProperty(nameof(UsuarioTbl.EventoTblResponsavelUsuario))]
        public virtual UsuarioTbl ResponsavelUsuario { get; set; }
    }
}
