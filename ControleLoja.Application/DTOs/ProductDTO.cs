using ControleLoja.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace ControleLoja.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Nome is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "The Descrição is Required")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string Descrição { get; set; }

        [Required(ErrorMessage = "The Preço is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Preço { get; set; }

        [Required(ErrorMessage = "The Estoque is Required")]
        [Range(1, 9999)]
        [DisplayName("Estoque")]
        public int Estoque { get; set; }

        [MaxLength(250)]
        [DisplayName("Product Imagem")]
        public string Imagem { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }

        [DisplayName("Categories")]
        public int CategoriaId { get; set; }
    }
}
