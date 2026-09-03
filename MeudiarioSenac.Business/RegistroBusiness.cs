﻿using DiarioApp.Model.Models;
namespace MeudiarioSenac.Business;

  public class RegistroBusiness
  {
      public const int TituloMaximo = 50;
      public const int ConteudoMaximo = 3000;

      public void ValidarTituloObrigatorio(string? titulo)
      {
          if (string.IsNullOrWhiteSpace(titulo))
              throw new ArgumentException("O título do registro não pode estar vazio.", nameof(titulo));
      }

      public void ValidarTituloMaximo(string? titulo)
      {
          if (titulo is { Length: > TituloMaximo })
              throw new ArgumentException($"O título do registro não pode exceder {TituloMaximo} caracteres.", nameof(titulo));
      }

      public void ValidarData(DateTime data)
      {
          if (data > DateTime.Now)
              throw new ArgumentException("A data do registro não pode ser futura.", nameof(data));
      }

      public void ValidarConteudo(string? conteudo)
      {
          if (string.IsNullOrWhiteSpace(conteudo))
              throw new ArgumentException("O conteúdo do registro não pode estar vazio.", nameof(conteudo));

          if (conteudo.Length > ConteudoMaximo)
              throw new ArgumentException($"O conteúdo do registro deve ter no máximo {ConteudoMaximo} caracteres.", nameof(conteudo));
      }

      public void ValidarRegistro(Registro registro)
      {
          ValidarTituloObrigatorio(registro.Titulo);
          ValidarTituloMaximo(registro.Titulo);
          ValidarData(registro.DataRegistro);
          ValidarConteudo(registro.Conteudo);
      }
  }








