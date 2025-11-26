using System;
using System.Collections.Generic;
using System.Text;
using CamadaDados;
using.System.Data;

namespace CamadaNegocio
{
    public class NCategoria
    {


        //Metodo Inserir que chama o metodo inserir da camada de dados
        public static string Inserir(string nome, string descricao)
        {
            DCategoria obj = new CamadaDados.DCategoria();
            obj.Nome = nome;
            obj.Descricao = descricao;
            return obj.Inserir(obj);

        }

        //Metodo editar 

        public static string Editar(int idcategoria, string nome, string descricao)
        {
            DCategoria obj = new CamadaDados.DCategoria();
            obj.Idcategoria = idcategoria;
            obj.Nome = nome;
            obj.Descricao = descricao;
            return obj.Editar(obj);

        }


        //Metodo Excluir

        public static string Excluir(int idcategoria)
        {
            DCategoria obj = new CamadaDados.DCategoria();
            obj.Idcategoria = idcategoria;
            return obj.Excluir(obj);

        }


        //Metodo Mostrar

        public static DataTable Mostrar()
        {
            return new DCategoria().Mostrar();
        }


        //Metodo Buscar

        public static DataTable Buscar(string textobuscar)
        {
            DCategoria obj = new CamadaDados.DCategoria();
            obj.Textobuscar = textobuscar;
            return obj.Buscar(obj);
        }






    }
}