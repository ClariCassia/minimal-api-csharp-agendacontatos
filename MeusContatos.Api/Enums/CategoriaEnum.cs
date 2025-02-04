using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace MeusContatos.Api.Enums
{
    public enum CategoriaEnum
    {
        [Description("Família")]
        Familia = 1,

        [Description("Amigos")]
        Amigos = 2,

        [Description("Trabalho")]
        Trabalho = 3,

        [Description("Outros")]
        Outros = 4,
    }

    public static class CategoriaEnumHelper
    {
        public static Dictionary<int, string> ObterDescricoesDeTodosEnum()
        {
            var valoresEnum = Enum.GetValues(typeof(CategoriaEnum)).Cast<CategoriaEnum>();

            var descricoes = new Dictionary<int, string>();

            foreach (var valor in valoresEnum)
            {
                var campo = valor.GetType().GetField(valor.ToString());

                var atributo = (DescriptionAttribute)Attribute.GetCustomAttribute(campo, typeof(DescriptionAttribute));

                var descricao = atributo == null ? valor.ToString() : atributo.Description;

                descricoes.Add((int)valor, descricao);
            }

            return descricoes;
        }
    }
}
